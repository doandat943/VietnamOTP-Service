using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace VietnamOTP_Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            this.Size = new Size(316, 232);

            if (File.Exists(id_path))
            {
                textBox1.Text = File.ReadAllText(id_path);
            }
        }

        WebClient client = new WebClient();

        string status_exam = "Status:  ";
        string id_path = Path.GetTempPath() + "uuid.otp";

        ArrayList service_list = new ArrayList();
        int selected_service = 0;
        string user_id = "";
        bool user_id_status = false;

        string request_id = "";
        string status = "0";
        string otp_code = "";
        int my_balance = 0;
        int timer = 0;
        int dot_counter = 0;
        string dot = "";

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread updater = new Thread(update_1);
            updater.SetApartmentState(ApartmentState.STA);
            updater.IsBackground = true;
            updater.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread updater = new Thread(update_2);
            updater.SetApartmentState(ApartmentState.STA);
            updater.IsBackground = true;
            updater.Start();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            Thread updater = new Thread(login);
            updater.SetApartmentState(ApartmentState.STA);
            updater.IsBackground = true;
            updater.Start();
        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            Thread updater = new Thread(generate);
            updater.SetApartmentState(ApartmentState.STA);
            updater.IsBackground = true;
            updater.Start();
        }

        private string request(string link, bool mode)
        {
            string request_ = "";

            if (user_id != "")
            {
                try
                {
                    request_ = client.DownloadString(link);
                    Match match = Regex.Match(request_, "code\":(.*),\"message");
                    string status_code = match.Groups[1].Value;

                    if (status_code != "200")
                    {
                        if (status_code == "-3")
                        {
                            status_label.Text = status_exam + "Out of stock";
                            if (mode == true)
                            {
                                request_ = request(link, mode);
                                status_label.Text = status_exam + "Connecting...";
                            }
                        }
                        else
                        {
                            request_ = "";

                            if (status_code == "401")
                            {
                                user_id = "";
                                status_label.Text = status_exam + "Your id cannot be authenticated";
                            }
                            else if (status_code == "-30")
                            {
                                user_id = "";
                                generate_button.Enabled = false;
                                status_label.Text = status_exam + "Your id has been blocked";
                            }
                            else if (status_code == "-4")
                            {
                                checkBox6.Checked = false;
                                status_label.Text = status_exam + "This phone number is not available";
                            }
                            else if (status_code == "-101")
                            {
                                status_label.Text = status_exam + "You can't rent this phone number";
                            }
                            else
                            {
                                status_label.Text = status_exam + "Something went wrong (Code: " + status_code + ")";
                            }
                        }
                    }
                }
                catch
                {
                    if (mode == true)
                    {
                        request_ = request(link, mode);
                        status_label.Text = status_exam + "Connecting...";
                    }
                }
            }

            return request_;
        }

        private void update_1() // full return data
        {
            string request_ = "";

            // get code

            if (request_id != "")
            {
                request_ = request("https://api.viotp.com/session/getv2?token=" + user_id + "&requestId=" + request_id, false);
                if (request_ != "")
                {
                    Match match1 = Regex.Match(request_, "Status\":(.*),\"CreatedTime");
                    status = match1.Groups[1].Value;
                    Match match2 = Regex.Match(request_, "Code\":\"(.*)\",\"PhoneOriginal");
                    otp_code = match2.Groups[1].Value;
                }
                else
                {
                    status = "";
                    otp_code = "";
                }
            }

            // get balance

            if (user_id != "")
            {
                request_ = request("https://api.viotp.com/users/balance?token=" + user_id, false);
                if (request_ != "")
                {
                    Match match1 = Regex.Match(request_, "balance\":(.*)}}");
                    string balance = match1.Groups[1].Value;

                    if (Int32.TryParse(balance, out my_balance))
                    {
                        balance_label.Text = String.Format("{0:n0}", Convert.ToInt64(my_balance)) + " VND";

                        if (request_id == "")
                        {
                            if (my_balance >= 1000)
                            {
                                user_id_status = true;
                            }
                            else if (my_balance < 1000)
                            {
                                user_id_status = false;
                            }
                        }
                    }

                    
                }
            }
            else
            {
                user_id_status = false;
            }
        }

        private void update_2()
        {
            // check account status

            if (user_id_status == true)
            {
                generate_button.Enabled = true;
                textBox1.Enabled = false;
                login_button.Enabled = false;
            }
            else if (user_id_status == false)
            {
                generate_button.Enabled = false;
                textBox1.Enabled = true;
                login_button.Enabled = true;
            }

            // check re number textbox

            if (textBox4.Text == "")
            {
                checkBox6.Checked = false;
                checkBox6.Enabled = false;
            }
            else
            {
                checkBox6.Enabled = true;
            }

            // check otp code coming

            if (request_id != "")
            {
                string status_title = "";

                if (status == "1")
                {
                    textBox3.BackColor = Color.FromArgb(255, 192, 192);
                    textBox3.Text = otp_code;

                    Clipboard.SetText(textBox3.Text);

                    request_id = "";
                    status = "0";
                    otp_code = "";
                    dot_counter = 0;
                    dot = "";

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Print complete.wav");
                    player.Play();
                    status_title = "Success";
                }
                else if (status == "2")
                {
                    textBox2.BackColor = SystemColors.Window;
                    textBox2.Text = "Number";

                    request_id = "";
                    status = "0";
                    otp_code = "";
                    dot_counter = 0;
                    dot = "";

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Speech On.wav");
                    player.Play();
                    status_title = "Expired";
                }
                else
                {
                    timer++;

                    if (status == "0")
                    {
                        status_title = "Waiting ";
                    }
                    else
                    {
                        status_title = "Connecting ";
                    }

                    if (dot_counter++ < 3)
                    {
                        dot += ".";
                    }
                    else
                    {
                        dot = "";
                        dot_counter = 0;
                    }
                    status_title += dot;
                }

                TimeSpan time = TimeSpan.FromSeconds(timer);

                status_label.Text = status_exam + time.ToString() + "  |  ID" + (selected_service + 1).ToString("00") + "  |  " + status_title;
            }
        }

        private void login()
        {
            login_button.Enabled = false;
            user_id = textBox1.Text;

            update_1();

            if (comboBox1.Items.Count == 0 && user_id != "")
            {
                string request_ = request("https://api.viotp.com/service/getv2?token=" + user_id + "&country=vn", true);
                if (request_ != "")
                {
                    request_ = Regex.Replace(request_, "{.*\\[", "").Replace("},{", "|").Replace("{", "").Replace("}]}", "");
                    string[] service_list_raw = request_.Split('|');
                    string[] a = {
                        "ShopeePay", "ShopeeFood", "Lazada", "Tiki", "Fahasa", "Toss", "Alibaba",
                        "Telegram", "Tiktok", "Discord", "Gmail", "Facebook", "Zalopay", "ShopBack", "Hao Hao"
                    };

                    foreach (string service_info in service_list_raw)
                    {
                        if (a.Any(service_info.Contains))
                        {
                            Match match1 = Regex.Match(service_info, "name\":\"(.*)\",\"price");
                            string service_name = match1.Groups[1].Value;
                            Match match2 = Regex.Match(service_info, "price\":(.*)");
                            string service_price = match2.Groups[1].Value;
                            service_list.Add(service_info);

                            comboBox1.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + String.Format("{0:n0}", Convert.ToInt64(service_price)) + " VND  |  " + service_name);
                        }
                    }

                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    status_label.Text = status_exam + "Welcome to VietnamOTP";
                    File.WriteAllText(id_path, user_id);
                }
            }
        }

        private void generate()
        {
            generate_button.Enabled = false;
            timer = 0;

            // get selected service

            selected_service = comboBox1.SelectedIndex;
            string service_info = service_list[selected_service].ToString();
            Match match0 = Regex.Match(service_info, "id\":(.*),\"name");
            string service_id = match0.Groups[1].Value;

            string request_ = "https://api.viotp.com/request/getv2?token=" + user_id + "&serviceId=" + service_id;

            if (checkBox6.Checked == true)
            {
                request_ = request(request_ + "&number=" + textBox4.Text.Replace("-", ""), true);
            }
            else
            {
                request_ = request(request_ + "&network=" + network, true);
            }

            if (request_ != "")
            {
                Match match1 = Regex.Match(request_, "re_phone_number\":\"(.*)\",\"countryISO");
                string number = match1.Groups[1].Value;
                Match match2 = Regex.Match(request_, "request_id\":(.*),\"balance");
                request_id = match2.Groups[1].Value;

                Clipboard.SetText(number);

                number = "0" + String.Format("{0:####-###-###}", Convert.ToInt64(number));

                textBox2.BackColor = Color.FromArgb(255, 224, 192);
                textBox2.Text = number;
                textBox4.Text = number;

                textBox3.BackColor = SystemColors.Window;
                textBox3.Text = "OTP Code";
            }
        }

        string network = "";

        int check1 = 0;
        int check2 = 0;
        int check3 = 0;
        int check4 = 0;
        int check5 = 0;

        private int CheckBoxMOD(CheckBox a, int b)
        {
            if (a.CheckState == CheckState.Unchecked && b == 0)
            {
                b = 1;
                a.CheckState = CheckState.Indeterminate;
            }
            else if (a.CheckState == CheckState.Unchecked && b == 1)
            {
                b = 0;
                a.CheckState = CheckState.Checked;
            }

            network = "";
            if (checkBox1.CheckState == CheckState.Checked)
            {
                network += "VIETTEL|";
            }
            else if (checkBox2.CheckState == CheckState.Checked)
            {
                network += "VINAPHONE|";
            }
            else if (checkBox3.CheckState == CheckState.Checked)
            {
                network += "MOBIFONE|";
            }
            else if (checkBox4.CheckState == CheckState.Checked)
            {
                network += "VIETNAMOBILE|";
            }
            else if (checkBox5.CheckState == CheckState.Checked)
            {
                network += "ITELECOM|";
            }
            return b;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Indeterminate && checkBox3.CheckState == CheckState.Indeterminate && checkBox4.CheckState == CheckState.Indeterminate && checkBox5.CheckState == CheckState.Indeterminate)
            {
                checkBox1.Checked = true;
            }
            else
            {
                check1 = CheckBoxMOD(checkBox1, check1);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Indeterminate && checkBox3.CheckState == CheckState.Indeterminate && checkBox4.CheckState == CheckState.Indeterminate && checkBox5.CheckState == CheckState.Indeterminate)
            {
                checkBox2.Checked = true;
            }
            else
            {
                check2 = CheckBoxMOD(checkBox2, check2);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Indeterminate && checkBox2.CheckState == CheckState.Indeterminate && checkBox4.CheckState == CheckState.Indeterminate && checkBox5.CheckState == CheckState.Indeterminate)
            {
                checkBox3.Checked = true;
            }
            else
            {
                check3 = CheckBoxMOD(checkBox3, check3);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Indeterminate && checkBox2.CheckState == CheckState.Indeterminate && checkBox3.CheckState == CheckState.Indeterminate && checkBox5.CheckState == CheckState.Indeterminate)
            {
                checkBox4.Checked = true;
            }
            else
            {
                check4 = CheckBoxMOD(checkBox4, check4);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Indeterminate && checkBox2.CheckState == CheckState.Indeterminate && checkBox3.CheckState == CheckState.Indeterminate && checkBox4.CheckState == CheckState.Indeterminate)
            {
                checkBox5.Checked = true;
            }
            else
            {
                check5 = CheckBoxMOD(checkBox5, check5);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Size == new Size(316, 232))
            {
                button3.Text = "<";
                this.Size = new Size(418, 232);
            }
            else
            {
                button3.Text = ">";
                this.Size = new Size(316, 232);
            }
        }
    }
}
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

            if (File.Exists(uuid_path))
            {
                textBox1.Text = File.ReadAllText(uuid_path);
            }
        }

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
        private void timer3_Tick(object sender, EventArgs e)
        {
            Thread updater = new Thread(update_3);
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

        WebClient client = new WebClient();
        ArrayList service_list = new ArrayList();

        string exam_status = "Status:  ";
        string uuid_path = Path.GetTempPath() + "token.otp";

        string user_id = "";
        bool user_status = false;
        int user_balance = 0;

        int session_service = 0;
        string session_id = "";
        string session_number = "";
        string session_status = "0";
        string session_code = "";

        int timer = 0;
        int dot_counter = 0;
        string dot = "";

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
                            status_label.Text = exam_status + "Out of stock";
                            if (mode == true)
                            {
                                request_ = request(link, mode);
                                status_label.Text = exam_status + "Connecting...";
                            }
                        }
                        else
                        {
                            request_ = "";

                            if (status_code == "401")
                            {
                                user_id = "";
                                user_status = false;
                                status_label.Text = exam_status + "Your id cannot be authenticated";
                            }
                            else if (status_code == "-30")
                            {
                                user_id = "";
                                user_status = false;
                                status_label.Text = exam_status + "Your id has been blocked";
                            }
                            else if (status_code == "-4")
                            {
                                checkBox.Checked = false;
                                status_label.Text = exam_status + "This phone number is not available";
                            }
                            else if (status_code == "-101")
                            {
                                checkBox.Checked = false;
                                status_label.Text = exam_status + "You can't rent this phone number";
                            }
                            else
                            {
                                status_label.Text = exam_status + "Something went wrong (Code: " + status_code + ")";
                            }
                        }
                    }
                }
                catch
                {
                    if (mode == true)
                    {
                        request_ = request(link, mode);
                        status_label.Text = exam_status + "Connecting...";
                    }
                }
            }

            return request_;
        }

        private void update_1()
        {
            string request_ = "";

            // get balance

            if (user_id != "")
            {
                request_ = request("https://api.viotp.com/users/balance?token=" + user_id, false);
                if (request_ != "")
                {
                    Match match1 = Regex.Match(request_, "balance\":(.*)}}");
                    string balance = match1.Groups[1].Value;

                    if (Int32.TryParse(balance, out user_balance))
                    {
                        balance_label.Text = String.Format("{0:n0}", Convert.ToInt64(user_balance)) + " VND";

                        if (user_balance >= 1000)
                        {
                            user_status = true;
                        }
                        else if (user_balance < 1000)
                        {
                            user_status = false;
                        }
                    }
                }
            }

            // get code

            if (session_id != "")
            {
                request_ = request("https://api.viotp.com/session/getv2?token=" + user_id + "&requestId=" + session_id, false);
                if (request_ != "")
                {
                    Match match1 = Regex.Match(request_, "Status\":(.*),\"CreatedTime");
                    session_status = match1.Groups[1].Value;
                    Match match2 = Regex.Match(request_, "Code\":\"(.*)\",\"PhoneOriginal");
                    session_code = match2.Groups[1].Value;
                }
                else
                {
                    session_status = "";
                    session_code = "";
                }
            }
        }

        private void update_2()
        {
            // check otp code coming

            if (session_id != "")
            {
                string status_title = "";

                if (session_status == "1")
                {
                    textBox3.BackColor = Color.FromArgb(255, 192, 192);
                    textBox3.Text = session_code;

                    Clipboard.SetText(session_code);

                    new_session();

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Print complete.wav");
                    player.Play();
                    status_title = "Success";
                }
                else if (session_status == "2")
                {
                    textBox2.BackColor = SystemColors.Window;
                    textBox2.Text = "Number";

                    new_session();

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Speech On.wav");
                    player.Play();
                    status_title = "Expired";
                }
                else
                {
                    timer++;

                    if (session_status == "0")
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

                status_label.Text = exam_status + time.ToString() + "  |  ID" + (session_service + 1).ToString("00") + "  |  " + status_title;
            }
        }

        private void update_3()
        {
            // check account status

            if (user_status == true)
            {
                generate_button.Enabled = true;
                textBox1.Enabled = false;
                login_button.Enabled = false;
            }
            else
            {
                if (session_id == "")
                {
                    generate_button.Enabled = false;
                    textBox1.Enabled = true;
                    login_button.Enabled = true;
                }
                else
                {
                    generate_button.Enabled = false;
                    textBox1.Enabled = false;
                    login_button.Enabled = false;
                }
            }
        }

        private void new_session()
        {
            session_id = "";
            session_number = "";
            session_status = "0";
            session_code = "";

            dot_counter = 0;
            dot = "";
        }

        private void login()
        {
            user_id = textBox1.Text;

            update_1();

            if (comboBox1.Items.Count == 0)
            {
                string request_ = request("https://api.viotp.com/service/getv2?token=" + user_id + "&country=vn", true);
                if (request_ != "")
                {
                    request_ = Regex.Replace(request_, "{.*\\[", "").Replace("},{", "|").Replace("{", "").Replace("}]}", "");
                    string[] service_list_raw = request_.Split('|');
                    string[] a =
                    {
                        "ShopeePay", "ShopeeFood", "Lazada", "Tiki", "Fahasa", "Toss", "Alibaba", "Uber", "Viber", "Paypal", "Zoho", "Lotteria", "Microsoft", 
                        "Telegram", "Tiktok", "Discord", "Gmail", "Facebook", "Zalopay", "ShopBack", "Hao Hao", "VinID", "Gojek", "Grab", "Amazon", "Instagram",
                        "WhatsApp", "Twitter", "Apple ID"
                    };
                    string[] b =
                    {
                        "OTHER"
                    };

                    foreach (string service_info in service_list_raw)
                    {
                        if (a.Any(service_info.Contains))
                        {
                            service_list.Add(service_info);

                            Match match1 = Regex.Match(service_info, "name\":\"(.*)\",\"price");
                            string service_name = match1.Groups[1].Value;
                            Match match2 = Regex.Match(service_info, "price\":(.*)");
                            string service_price = String.Format("{0:n0}", Convert.ToDecimal(match2.Groups[1].Value));
                            if (service_price.Count() <= 3) service_price = "   " + service_price;

                            comboBox1.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + service_price + " VND  |  " + service_name);
                        }
                    }
                    foreach (string service_info in service_list_raw)
                    {
                        if (b.Any(service_info.Contains))
                        {
                            service_list.Add(service_info);

                            Match match1 = Regex.Match(service_info, "name\":\"(.*)\",\"price");
                            string service_name = match1.Groups[1].Value;
                            if (service_name.Contains("OTHER"))
                            {
                                service_name = "------          Other Service          ------";
                            }
                            Match match2 = Regex.Match(service_info, "price\":(.*)");
                            string service_price = String.Format("{0:n0}", Convert.ToDecimal(match2.Groups[1].Value));
                            if (service_price.Count() <= 3) service_price = "   " + service_price;

                            comboBox1.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + service_price + " VND  |  " + service_name);
                        }
                    }

                    if (comboBox1.Items.Count != 0)
                    {
                        comboBox1.SelectedIndex = session_service;
                    }

                    status_label.Text = exam_status + "Welcome to VietnamOTP";
                    File.WriteAllText(uuid_path, user_id);
                }
            }
        }

        private void generate()
        {
            timer = -1;

            // get selected service

            session_service = comboBox1.SelectedIndex;
            string service_info = service_list[session_service].ToString();
            Match match0 = Regex.Match(service_info, "id\":(.*),\"name");
            string service_id = match0.Groups[1].Value;

            string request_ = "https://api.viotp.com/request/getv2?token=" + user_id + "&serviceId=" + service_id;

            if (checkBox.Checked == true)
            {
                request_ = request(request_ + "&number=" + textBox2.Text.Replace("-", ""), true);
            }
            else
            {
                request_ = request(request_ + "&network=" + network, true);
            }

            update_1();

            if (request_ != "")
            {
                Match match1 = Regex.Match(request_, "re_phone_number\":\"(.*)\",\"countryISO");
                session_number = match1.Groups[1].Value;
                Match match2 = Regex.Match(request_, "request_id\":(.*),\"balance");
                session_id = match2.Groups[1].Value;

                Clipboard.SetText(session_number);

                session_number = "0" + String.Format("{0:####-###-###}", Convert.ToInt64(session_number));

                textBox2.BackColor = Color.FromArgb(255, 224, 192);
                textBox2.Text = session_number;

                textBox3.BackColor = SystemColors.Window;
                textBox3.Text = "OTP Code";
            }
            else
            {
                new_session();
            }
        }

        private void expand_button_Click(object sender, EventArgs e)
        {
            if (this.Size == new Size(316, 232))
            {
                expand_button.Text = "<";
                this.Size = new Size(418, 232);
            }
            else
            {
                expand_button.Text = ">";
                this.Size = new Size(316, 232);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        string network = "";

        int check1 = 0;
        int check2 = 0;
        int check3 = 0;
        int check4 = 0;
        int check5 = 0;
        int check6 = 0;

        private int checkBoxMOD(CheckBox a, int b)
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

            if (network1.CheckState == CheckState.Checked)
            {
                network += "VIETTEL|";
            }
            else if (network2.CheckState == CheckState.Checked)
            {
                network += "VINAPHONE|";
            }
            else if (network3.CheckState == CheckState.Checked)
            {
                network += "MOBIFONE|";
            }
            else if (network4.CheckState == CheckState.Checked)
            {
                network += "VIETNAMOBILE|";
            }
            else if (network5.CheckState == CheckState.Checked)
            {
                network += "ITELECOM|";
            }
            else if (network6.CheckState == CheckState.Checked)
            {
                network += "VODAFONE|";
            }
            return b;
        }

        private void network1_CheckedChanged(object sender, EventArgs e)
        {
            if (network2.CheckState == CheckState.Indeterminate && network3.CheckState == CheckState.Indeterminate && network4.CheckState == CheckState.Indeterminate && network5.CheckState == CheckState.Indeterminate && network6.CheckState == CheckState.Indeterminate)
            {
                network1.Checked = true;
            }
            else
            {
                check1 = checkBoxMOD(network1, check1);
            }
        }

        private void network2_CheckedChanged(object sender, EventArgs e)
        {
            if (network1.CheckState == CheckState.Indeterminate && network3.CheckState == CheckState.Indeterminate && network4.CheckState == CheckState.Indeterminate && network5.CheckState == CheckState.Indeterminate && network6.CheckState == CheckState.Indeterminate)
            {
                network2.Checked = true;
            }
            else
            {
                check2 = checkBoxMOD(network2, check2);
            }
        }

        private void network3_CheckedChanged(object sender, EventArgs e)
        {
            if (network1.CheckState == CheckState.Indeterminate && network2.CheckState == CheckState.Indeterminate && network4.CheckState == CheckState.Indeterminate && network5.CheckState == CheckState.Indeterminate && network6.CheckState == CheckState.Indeterminate)
            {
                network3.Checked = true;
            }
            else
            {
                check3 = checkBoxMOD(network3, check3);
            }
        }

        private void network4_CheckedChanged(object sender, EventArgs e)
        {
            if (network1.CheckState == CheckState.Indeterminate && network2.CheckState == CheckState.Indeterminate && network3.CheckState == CheckState.Indeterminate && network5.CheckState == CheckState.Indeterminate && network6.CheckState == CheckState.Indeterminate)
            {
                network4.Checked = true;
            }
            else
            {
                check4 = checkBoxMOD(network4, check4);
            }
        }

        private void network5_CheckedChanged(object sender, EventArgs e)
        {
            if (network1.CheckState == CheckState.Indeterminate && network2.CheckState == CheckState.Indeterminate && network3.CheckState == CheckState.Indeterminate && network4.CheckState == CheckState.Indeterminate && network6.CheckState == CheckState.Indeterminate)
            {
                network5.Checked = true;
            }
            else
            {
                check5 = checkBoxMOD(network5, check5);
            }
        }

        private void network6_CheckedChanged(object sender, EventArgs e)
        {
            if (network1.CheckState == CheckState.Indeterminate && network2.CheckState == CheckState.Indeterminate && network3.CheckState == CheckState.Indeterminate && network4.CheckState == CheckState.Indeterminate && network5.CheckState == CheckState.Indeterminate)
            {
                network6.Checked = true;
            }
            else
            {
                check6 = checkBoxMOD(network6, check6);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }
    }
}
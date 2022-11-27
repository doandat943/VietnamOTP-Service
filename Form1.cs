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
            Thread updater = new Thread(main_update);
            updater.SetApartmentState(ApartmentState.STA);
            updater.IsBackground = true;
            updater.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread updater = new Thread(ui_update);
            updater.SetApartmentState(ApartmentState.STA);
            updater.IsBackground = true;
            updater.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (session_id != "")
            {
                session_timer++;
            }
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

        WebClient client = new WebClient();
        ArrayList service_list = new ArrayList();

        static string exam_status = "Status:  ";
        static string uuid_path = Path.GetTempPath() + "token.otp";

        string user_id = "";
        bool user_status = false;
        int user_balance = 0;
        int lowest_price = 0;

        int session_timer = 0;
        int session_service = 0;
        string session_id = "";
        string session_number = "";
        string session_country = "";
        string session_network = "";
        string session_status = "";
        string session_code = "";

        int dot_counter = 0;
        string dot = "";

        private void new_session()
        {
            session_timer = 0;
            session_service = 0;
            session_id = "";
            session_number = "";
            session_country = "";
            session_network = "";
            session_status = "";
            session_code = "";

            dot_counter = 0;
            dot = "";

            network1.ForeColor = network2.ForeColor = network3.ForeColor = network4.ForeColor = network5.ForeColor = network6.ForeColor = SystemColors.ControlText;
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
                            status_label.Text = exam_status + "Out of stock";
                            if (mode == true)
                            {
                                request_ = request(link, mode);
                            }
                        }
                        else
                        {
                            request_ = "";

                            if (status_code == "401")
                            {
                                user_id = "";
                                user_status = false;
                                status_label.Text = exam_status + "Your ID cannot be authenticated";
                            }
                            else if (status_code == "-30")
                            {
                                user_id = "";
                                user_status = false;
                                status_label.Text = exam_status + "Your ID has been blocked";
                            }
                            else if (status_code == "-4")
                            {
                                checkBox.Checked = false;
                                status_label.Text = exam_status + "Phone number is not available";
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
                    }
                }
            }

            return request_;
        }

        private void main_update()
        {
            string request_ = "";

            // get balance
            if (user_id != "")
            {
                request_ = request("https://api.viotp.com/users/balance?token=" + user_id, false);
                if (request_ != "")
                {
                    Match match = Regex.Match(request_, "balance\":(.*)}}");
                    user_balance = Convert.ToInt32(match.Groups[1].Value);

                    balance_label.Text = String.Format("{0:n0}", user_balance) + " VND";

                    if (user_balance >= lowest_price)
                    {
                        user_status = true;
                    }
                    else
                    {
                        user_status = false;
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
            }
        }

        private void ui_update()
        {
            // check checkbox status
            check1 = check(network1);
            check2 = check(network2);
            check3 = check(network3);
            check4 = check(network4);
            check5 = check(network5);
            check6 = check(network6);

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

            // check session status
            if (session_id != "")
            {
                string status_title = "";

                if (session_status == "1")
                {
                    textBox3.BackColor = Color.FromArgb(255, 192, 192);
                    textBox3.Text = session_code;

                    Clipboard.SetText(textBox3.Text);

                    session_id = "";

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Print complete.wav");
                    player.Play();
                    status_title = "Success";
                }
                else if (session_status == "2")
                {
                    textBox2.BackColor = SystemColors.Window;
                    textBox2.Text = "Number";

                    session_id = "";

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Speech On.wav");
                    player.Play();
                    status_title = "Expired";
                }
                else
                {
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

                TimeSpan time = TimeSpan.FromSeconds(session_timer);

                status_label.Text = exam_status + time.ToString() + "  |  ID" + (session_service + 1).ToString("00") + "  |  " + status_title;
            }
        }

        private void login()
        {
            user_id = textBox1.Text;

            main_update();

            if (comboBox1.Items.Count == 0)
            {
                string request_ = request("https://api.viotp.com/service/getv2?token=" + user_id, true);
                if (request_ != "")
                {
                    request_ = Regex.Replace(request_, "{.*\\[", "").Replace("},{", "|").Replace("{", "").Replace("}]}", "");
                    string[] service_list_raw = request_.Split('|');
                    string[] a =
                    {
                        "ShopeePay", "ShopeeFood", "Lazada", "Tiki", "Fahasa", "Toss", "Alibaba", "Uber", "Viber", "Paypal", "Zoho", "Lotteria", "Microsoft",
                        "Telegram", "Tiktok", "Discord", "Gmail", "Facebook", "Zalopay", "ShopBack", "Hao Hao", "VinID", "Gojek", "Grab", "Amazon", "Instagram",
                        "WhatsApp", "Twitter", "Apple ID", "Ebay", "Tinder", "Wechat", "WhatsApp"
                    };

                    foreach (string service_info in service_list_raw)
                    {
                        if (a.Any(service_info.Contains))
                        {
                            service_list.Add(service_info);

                            // get service info
                            Match match1 = Regex.Match(service_info, "name\":\"(.*)\",\"price");
                            string service_name = match1.Groups[1].Value;
                            Match match2 = Regex.Match(service_info, "price\":(.*)");
                            string service_price = match2.Groups[1].Value;

                            // get lowest price
                            int price = Convert.ToInt32(service_price);
                            if (lowest_price == 0) lowest_price = price;
                            else if (price < lowest_price) lowest_price = price;

                            // format price
                            service_price = String.Format("{0:n0}", price);
                            if (service_price.Count() <= 3) service_price = "   " + service_price;

                            comboBox1.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + service_price + " VND  |  " + service_name);
                        }
                    }
                    foreach (string service_info in service_list_raw)
                    {
                        if (service_info.Contains("OTHER"))
                        {
                            service_list.Add(service_info);

                            // get service info
                            string service_name = "------         Other Service         ------";
                            Match match = Regex.Match(service_info, "price\":(.*)");
                            string service_price = match.Groups[1].Value;

                            // format price
                            service_price = String.Format("{0:n0}", Convert.ToInt32(service_price));
                            if (service_price.Count() <= 3) service_price = "   " + service_price;

                            comboBox1.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + service_price + " VND  |  " + service_name);
                        }
                    }

                    if (comboBox1.Items.Count != 0)
                    {
                        comboBox1.SelectedIndex = session_service;
                    }
                }
            }
            status_label.Text = exam_status + "Welcome to VietnamOTP";
            File.WriteAllText(uuid_path, user_id);
        }

        private void generate()
        {
            // start new

            new_session();

            // get selected service

            session_service = comboBox1.SelectedIndex;
            if (check6 == false) session_country = "vn";
            else session_country = "ro";

            string service_info = service_list[session_service].ToString();
            Match match = Regex.Match(service_info, "id\":(.*),\"name");
            string service_id = match.Groups[1].Value;

            string request_ = "https://api.viotp.com/request/getv2?token=" + user_id + "&serviceId=" + service_id;

            if (checkBox.Checked == true)
            {
                request_ = request(request_ + "&number=" + textBox2.Text.Replace("-", ""), true);
            }
            else
            {
                if (session_country == "vn")
                {
                    request_ = request(request_ + "&network=" + session_network + "&country=" + session_country, true);
                }
                else
                {
                    request_ = request(request_ + "&country=" + session_country, true);
                }
            }

            main_update();

            if (request_ != "")
            {
                Match match1 = Regex.Match(request_, "re_phone_number\":\"(.*)\",\"countryISO");
                session_number = match1.Groups[1].Value;
                Match match2 = Regex.Match(request_, "request_id\":(.*),\"balance");
                session_id = match2.Groups[1].Value;

                session_number = "0" + String.Format("{0:####-###-###}", Convert.ToInt32(session_number));
                textBox2.BackColor = Color.FromArgb(255, 224, 192);
                textBox2.Text = session_number;

                Clipboard.SetText(textBox2.Text);
                color_network(session_number);
            }
            else
            {
                textBox2.BackColor = textBox3.BackColor = SystemColors.Window;
                textBox2.Text = "Number";
                textBox3.Text = "OTP Code";
            }
        }

        private void color_network(string number)
        {
            if (session_country == "vn")
            {
                string prefix = number.Substring(0, 3);

                if (network1_prefix.Any(prefix.Contains)) network1.ForeColor = Color.FromArgb(236, 38, 43);
                if (network2_prefix.Any(prefix.Contains)) network2.ForeColor = Color.FromArgb(236, 38, 43);
                if (network3_prefix.Any(prefix.Contains)) network3.ForeColor = Color.FromArgb(236, 38, 43);
                if (network4_prefix.Any(prefix.Contains)) network4.ForeColor = Color.FromArgb(236, 38, 43);
                if (network5_prefix.Any(prefix.Contains)) network5.ForeColor = Color.FromArgb(236, 38, 43);
            }
            else network6.ForeColor = Color.FromArgb(236, 38, 43);
        }

        string[] network1_prefix = { "096", "097", "098", "086", "032", "033", "034", "035", "036", "037", "038", "039" };
        string[] network2_prefix = { "088", "091", "094", "081", "082", "083", "084", "085" };
        string[] network3_prefix = { "090", "093", "089", "070", "079", "078", "077", "076" };
        string[] network4_prefix = { "052", "056", "058", "092" };
        string[] network5_prefix = { "087" };

        bool check1;
        bool check2;
        bool check3;
        bool check4;
        bool check5;
        bool check6;

        private bool check(CheckBox checkBox)
        {
            bool b;
            if (checkBox.CheckState == CheckState.Checked) b = true;
            else b = false;
            return b;
        }

        private bool checkBoxVN(CheckBox checkBox, bool b)
        {
            if (checkBox.CheckState == CheckState.Unchecked)
            {
                if (b == true)
                {
                    b = false;
                    checkBox.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    b = true;
                    checkBox.CheckState = CheckState.Checked;
                    if (network6.Checked) network6.CheckState = CheckState.Indeterminate;
                }
            }

            session_network = "";

            if (network1.CheckState == CheckState.Checked)
            {
                session_network += "VIETTEL|";
            }
            if (network2.CheckState == CheckState.Checked)
            {
                session_network += "VINAPHONE|";
            }
            if (network3.CheckState == CheckState.Checked)
            {
                session_network += "MOBIFONE|";
            }
            if (network4.CheckState == CheckState.Checked)
            {
                session_network += "VIETNAMOBILE|";
            }
            if (network5.CheckState == CheckState.Checked)
            {
                session_network += "ITELECOM|";
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
                check1 = checkBoxVN(network1, check1);
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
                check2 = checkBoxVN(network2, check2);
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
                check3 = checkBoxVN(network3, check3);
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
                check4 = checkBoxVN(network4, check4);
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
                check5 = checkBoxVN(network5, check5);
            }
        }

        private void network6_CheckedChanged(object sender, EventArgs e)
        {
            if (network6.CheckState == CheckState.Unchecked && check6 == true)
            {
                check6 = false;
                network6.CheckState = CheckState.Indeterminate;
                network1.CheckState = network2.CheckState = network3.CheckState = network4.CheckState = network5.CheckState = CheckState.Checked;
            }
            else if (network6.CheckState == CheckState.Unchecked && check6 == false)
            {
                check6 = true;
                network6.CheckState = CheckState.Checked;
                network1.CheckState = network2.CheckState = network3.CheckState = network4.CheckState = network5.CheckState = CheckState.Indeterminate;
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
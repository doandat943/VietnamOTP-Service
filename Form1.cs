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

            this.Size = new Size(this.Size.Width - 100, this.Size.Height);
            Close_Button.Location = new Point(Close_Button.Location.X - 100, Close_Button.Location.Y);
            Minimize_Button.Location = new Point(Minimize_Button.Location.X - 100, Close_Button.Location.Y);

            if (File.Exists(uuid_path)) textBox1.Text = File.ReadAllText(uuid_path);
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
            if (session_id != "") session_timer++;
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

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void expand_button_Click(object sender, EventArgs e)
        {
            if (this.Size != new Size(402, 222))
            {
                expand_button.Text = "<";
                this.Size = new Size(this.Size.Width + 100, this.Size.Height);
                Close_Button.Location = new Point(Close_Button.Location.X + 100, Close_Button.Location.Y);
                Minimize_Button.Location = new Point(Minimize_Button.Location.X + 100, Close_Button.Location.Y);
            }
            else
            {
                expand_button.Text = ">";
                this.Size = new Size(this.Size.Width - 100, this.Size.Height);
                Close_Button.Location = new Point(Close_Button.Location.X - 100, Close_Button.Location.Y);
                Minimize_Button.Location = new Point(Minimize_Button.Location.X - 100, Close_Button.Location.Y);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (session_number != "") Clipboard.SetText(session_number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (session_code != "") Clipboard.SetText(session_code);
        }

        WebClient client = new WebClient();
        ArrayList service_list = new ArrayList();

        static string exam_status = "Status:  ";
        static string uuid_path = Path.GetTempPath() + "token.otp";

        string user_id = "";
        int user_balance = -1;
        int lowest_price = 0;

        int session_timer = 0;
        int session_service = 0;
        string session_id = "";
        string session_number = "";
        string session_network = "";
        string session_status = "";
        string session_code = "";

        int dot_counter = 0;
        string dot = "";

        private string request(string link, bool mode = false)
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
                            if (mode == true) request_ = request(link, mode);
                        }
                        else
                        {
                            request_ = "";

                            if (status_code == "401")
                            {
                                user_id = "";
                                status_label.Text = exam_status + "Your ID cannot be authenticated";
                            }
                            else if (status_code == "-30")
                            {
                                user_id = "";
                                status_label.Text = exam_status + "Your ID has been blocked";
                            }
                            else if (status_code == "-4")
                            {
                                checkBox.Checked = false;
                                status_label.Text = exam_status + "This number is not available";
                            }
                            else if (status_code == "-101")
                            {
                                checkBox.Checked = false;
                                status_label.Text = exam_status + "You can't rent this number";
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
                    if (mode == true) request_ = request(link, mode);
                }
            }

            return request_;
        }

        private void generate()
        {
            // start new session

            session_timer = 0;
            session_service = 0;
            session_id = "";
            session_number = "";
            session_network = "";
            session_status = "";
            session_code = "";

            dot_counter = 0;
            dot = "";

            cb_viettel.ForeColor = cb_vinaphone.ForeColor = cb_mobifone.ForeColor = cb_vietnamobile.ForeColor = cb_itelecom.ForeColor = cb_wintel.ForeColor = SystemColors.ControlText;

            // get selected service

            session_service = comboBox1.SelectedIndex;
            string service_info = service_list[session_service].ToString();

            Match match = Regex.Match(service_info, "id\":(.*),\"name");
            string service_id = match.Groups[1].Value;

            // request number

            string request_ = "https://api.viotp.com/request/getv2?token=" + user_id + "&serviceId=" + service_id;
            if (checkBox.Checked == true)
            {
                request_ = request(request_ + "&number=" + textBox2.Text.Replace("-", ""), true);
            }
            else
            {
                request_ = request(request_ + "&network=" + session_network, true);
            }

            // get balance and number

            main_update();

            if (request_ != "")
            {
                Match match1 = Regex.Match(request_, "re_phone_number\":\"(.*)\",\"countryISO");
                session_number = match1.Groups[1].Value;
                Match match2 = Regex.Match(request_, "request_id\":(.*),\"balance");
                session_id = match2.Groups[1].Value;

                Clipboard.SetText(session_number);
                color_network(session_number);

                textBox2.BackColor = Color.FromArgb(255, 224, 192);
                textBox2.Text = "0" + String.Format("{0:####-###-###}", Convert.ToInt32(session_number));
            }
            else
            {
                textBox2.BackColor = SystemColors.Window;
                textBox2.Text = "Number";
            }
            textBox3.BackColor = SystemColors.Window;
            textBox3.Text = "OTP Code";
        }

        private void main_update()
        {
            string request_ = "";

            // get balance
            if (user_id != "")
            {
                request_ = request("https://api.viotp.com/users/balance?token=" + user_id);
                if (request_ != "")
                {
                    Match match = Regex.Match(request_, "balance\":(.*)}}");
                    user_balance = Convert.ToInt32(match.Groups[1].Value);

                    balance_label.Text = String.Format("{0:n0}", user_balance) + " VND";
                }
            }

            // get code
            if (session_id != "")
            {
                request_ = request("https://api.viotp.com/session/getv2?token=" + user_id + "&requestId=" + session_id);
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
            check1 = check_state(cb_viettel);
            check2 = check_state(cb_vinaphone);
            check3 = check_state(cb_mobifone);
            check4 = check_state(cb_vietnamobile);
            check5 = check_state(cb_itelecom);
            check6 = check_state(cb_wintel);

            // check account status
            if (user_id != "")
            {
                if (user_balance >= lowest_price)
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

                if (session_id != "")
                {
                    string status_title = "";

                    if (session_status == "1")
                    {
                        textBox3.BackColor = Color.FromArgb(255, 192, 192);
                        textBox3.Text = session_code;
                        Clipboard.SetText(session_code);

                        session_id = "";

                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Print complete.wav");
                        player.Play();
                        status_title = "Success";
                    }
                    else if (session_status == "2")
                    {
                        session_id = "";

                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Speech On.wav");
                        player.Play();
                        status_title = "Expired";
                    }
                    else
                    {
                        if (session_status == "0") status_title = "Waiting ";
                        else status_title = "Connecting ";

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
        }

        private void login()
        {
            user_id = textBox1.Text;

            main_update();

            if (user_id != "")
            {
                if (comboBox1.Items.Count == 0)
                {
                    get_service(comboBox1, service_list, "vn");
                }
                status_label.Text = exam_status + "Welcome to VietnamOTP";
                File.WriteAllText(uuid_path, user_id);
            }
        }

        private void get_service(ComboBox comboBox, ArrayList service_list, string country)
        {
            string request_ = request("https://api.viotp.com/service/getv2?token=" + user_id + "&country=" + country, true);
            if (request_ != "")
            {
                request_ = Regex.Replace(request_, "{.*\\[", "").Replace("},{", "|").Replace("{", "").Replace("}]}", "");
                string[] service_list_raw = request_.Split('|');
                string[] a = {
                        "ShopeePay", "ShopeeFood", "Lazada", "Tiki", "Fahasa", "Toss", "Alibaba", "Uber", "Viber", "Paypal", "Zoho", "Lotteria", "Microsoft",
                        "Telegram", "Tiktok", "Discord", "Gmail", "Facebook", "Zalopay", "ShopBack", "Hao Hao", "VinID", "Gojek", "Grab", "Amazon", "Instagram",
                        "WhatsApp", "Twitter", "Apple ID", "Ebay", "Tinder", "Wechat", "WhatsApp"
                };

                foreach (string service_info in service_list_raw)
                {
                    if (a.Any(service_info.Contains))
                    {
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

                        // add service to list
                        service_list.Add(service_info);
                        comboBox.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + service_price + " VND  |  " + service_name);
                    }
                }
                foreach (string service_info in service_list_raw)
                {
                    if (service_info.Contains("OTHER"))
                    {
                        // get service info
                        string service_name = "------         Other Service         ------";
                        Match match = Regex.Match(service_info, "price\":(.*)");
                        string service_price = match.Groups[1].Value;

                        // format price
                        service_price = String.Format("{0:n0}", Convert.ToInt32(service_price));
                        if (service_price.Count() <= 3) service_price = "   " + service_price;

                        // add service to list
                        service_list.Add(service_info);
                        comboBox.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + service_price + " VND  |  " + service_name);
                    }
                }

                if (comboBox.Items.Count != 0)
                {
                    comboBox.SelectedIndex = session_service;
                }
            }
        }

        private void color_network(string number)
        {
            string prefix = number.Substring(0, 3);

            if (prefix_viettel.Any(prefix.Contains)) cb_viettel.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_vinaphone.Any(prefix.Contains)) cb_vinaphone.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_mobifone.Any(prefix.Contains)) cb_mobifone.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_vietnamobile.Any(prefix.Contains)) cb_vietnamobile.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_itelecom.Any(prefix.Contains)) cb_itelecom.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_wintel.Any(prefix.Contains)) cb_wintel.ForeColor = Color.FromArgb(236, 38, 43);
        }

        string[] prefix_viettel = { "032", "033", "034", "035", "036", "037", "038", "039", "086", "096", "097", "098" };
        string[] prefix_vinaphone = { "081", "082", "083", "084", "085", "088", "091", "094" };
        string[] prefix_mobifone = { "070", "076", "077", "078", "079", "089", "090", "093" };
        string[] prefix_vietnamobile = { "052", "056", "058", "092" };
        string[] prefix_itelecom = { "087" };
        string[] prefix_wintel = { "055" };

        bool check1;
        bool check2;
        bool check3;
        bool check4;
        bool check5;
        bool check6;

        private bool check_state(CheckBox checkBox)
        {
            bool b;
            if (checkBox.CheckState == CheckState.Checked) b = true;
            else b = false;
            return b;
        }

        private bool CheckBoxMOD(CheckBox checkBox, bool b)
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
                }
            }

            session_network = "";

            if (cb_viettel.CheckState == CheckState.Checked)
            {
                session_network += "VIETTEL|";
            }
            if (cb_vinaphone.CheckState == CheckState.Checked)
            {
                session_network += "VINAPHONE|";
            }
            if (cb_mobifone.CheckState == CheckState.Checked)
            {
                session_network += "MOBIFONE|";
            }
            if (cb_vietnamobile.CheckState == CheckState.Checked)
            {
                session_network += "VIETNAMOBILE|";
            }
            if (cb_itelecom.CheckState == CheckState.Checked)
            {
                session_network += "ITELECOM|";
            }
            if (cb_wintel.CheckState == CheckState.Checked)
            {
                session_network += "WINTEL|";
            }
            return b;
        }

        private void cb_viettel_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_vinaphone.CheckState == CheckState.Indeterminate && cb_mobifone.CheckState == CheckState.Indeterminate && cb_vietnamobile.CheckState == CheckState.Indeterminate && cb_itelecom.CheckState == CheckState.Indeterminate && cb_wintel.CheckState == CheckState.Indeterminate)
            {
                cb_viettel.Checked = true;
            }
            else
            {
                check1 = CheckBoxMOD(cb_viettel, check1);
            }
        }

        private void cb_vinaphone_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_viettel.CheckState == CheckState.Indeterminate && cb_mobifone.CheckState == CheckState.Indeterminate && cb_vietnamobile.CheckState == CheckState.Indeterminate && cb_itelecom.CheckState == CheckState.Indeterminate && cb_wintel.CheckState == CheckState.Indeterminate)
            {
                cb_vinaphone.Checked = true;
            }
            else
            {
                check2 = CheckBoxMOD(cb_vinaphone, check2);
            }
        }

        private void cb_mobifone_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_viettel.CheckState == CheckState.Indeterminate && cb_vinaphone.CheckState == CheckState.Indeterminate && cb_vietnamobile.CheckState == CheckState.Indeterminate && cb_itelecom.CheckState == CheckState.Indeterminate && cb_wintel.CheckState == CheckState.Indeterminate)
            {
                cb_mobifone.Checked = true;
            }
            else
            {
                check3 = CheckBoxMOD(cb_mobifone, check3);
            }
        }

        private void cb_vietnamobile_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_viettel.CheckState == CheckState.Indeterminate && cb_vinaphone.CheckState == CheckState.Indeterminate && cb_mobifone.CheckState == CheckState.Indeterminate && cb_itelecom.CheckState == CheckState.Indeterminate && cb_wintel.CheckState == CheckState.Indeterminate)
            {
                cb_vietnamobile.Checked = true;
            }
            else
            {
                check4 = CheckBoxMOD(cb_vietnamobile, check4);
            }
        }

        private void cb_itelecom_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_viettel.CheckState == CheckState.Indeterminate && cb_vinaphone.CheckState == CheckState.Indeterminate && cb_mobifone.CheckState == CheckState.Indeterminate && cb_vietnamobile.CheckState == CheckState.Indeterminate && cb_wintel.CheckState == CheckState.Indeterminate)
            {
                cb_itelecom.Checked = true;
            }
            else
            {
                check5 = CheckBoxMOD(cb_itelecom, check5);
            }
        }

        private void cb_wintel_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_viettel.CheckState == CheckState.Indeterminate && cb_vinaphone.CheckState == CheckState.Indeterminate && cb_mobifone.CheckState == CheckState.Indeterminate && cb_vietnamobile.CheckState == CheckState.Indeterminate && cb_itelecom.CheckState == CheckState.Indeterminate)
            {
                cb_wintel.Checked = true;
            }
            else
            {
                check6 = CheckBoxMOD(cb_wintel, check6);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                if (textBox2.Text == "Number") textBox2.Text = "";
                textBox2.Enabled = true;
            }
            else
            {
                if (session_id == "") textBox2.Text = "Number";
                else textBox2.Text = "0" + String.Format("{0:####-###-###}", Convert.ToInt32(session_number));
                textBox2.Enabled = false;
            }
        }

        Bitmap vietnam_flag = Properties.Resources.vietnam_480px;
        Bitmap vietnam_government_flag = Properties.Resources.vietnam_government_480px;

        private void Country_Icon_Click(object sender, EventArgs e)
        {
            if (Country_Icon.Image == vietnam_flag)
            {
                Country_Icon.Image = vietnam_government_flag;
            }
            else
            {
                Country_Icon.Image = vietnam_flag;
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace VietnamOTP_Service
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            //
            this.Size = new Size(this.Size.Width - 100, this.Size.Height);
            btn_Close.Location = new Point(btn_Close.Location.X - 100, btn_Close.Location.Y);
            btn_Minimize.Location = new Point(btn_Minimize.Location.X - 100, btn_Close.Location.Y);

            checkBoxDict.Add(cb_Viettel, true);
            checkBoxDict.Add(cb_Vinaphone, true);
            checkBoxDict.Add(cb_Mobifone, true);
            checkBoxDict.Add(cb_Vietnamobile, true);
            checkBoxDict.Add(cb_Itelecom, true);
            checkBoxDict.Add(cb_Wintel, true);

            //
            if (File.Exists(token_path)) txt_ID.Text = File.ReadAllText(token_path);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunTask(main_update);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            RunTask(ui_update);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (session_id != "") session_timer++;
            if (flag_animation == true)
            {
                if (pb_Flag.Image == vietnam_flag) pb_Flag.Image = vietnam_government_flag;
                else pb_Flag.Image = vietnam_flag;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            RunTask(login);
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            RunTask(generate);
        }

        private void pb_Flag_Click(object sender, EventArgs e)
        {
            if (flag_animation == true) flag_animation = false;
            else flag_animation = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Expand_Click(object sender, EventArgs e)
        {
            if (this.Size != new Size(402, 222))
            {
                btn_Expand.Text = "<";
                this.Size = new Size(this.Size.Width + 100, this.Size.Height);
                btn_Close.Location = new Point(btn_Close.Location.X + 100, btn_Close.Location.Y);
                btn_Minimize.Location = new Point(btn_Minimize.Location.X + 100, btn_Close.Location.Y);
            }
            else
            {
                btn_Expand.Text = ">";
                this.Size = new Size(this.Size.Width - 100, this.Size.Height);
                btn_Close.Location = new Point(btn_Close.Location.X - 100, btn_Close.Location.Y);
                btn_Minimize.Location = new Point(btn_Minimize.Location.X - 100, btn_Close.Location.Y);
            }
        }

        private void txt_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_Copy_Number_Click(object sender, EventArgs e)
        {
            if (session_number != "") Clipboard.SetText(session_number);
        }

        private void btn_Copy_OTPCode_Click(object sender, EventArgs e)
        {
            if (session_code != "") Clipboard.SetText(session_code);
        }

        Bitmap vietnam_flag = Properties.Resources.vietnam_480px;
        Bitmap vietnam_government_flag = Properties.Resources.vietnam_government_480px;
        bool flag_animation = true;

        WebClient client = new WebClient();
        ArrayList service_list = new ArrayList();
        Match match;

        static string exam_status = "Status:  ";
        static string token_path = Path.GetTempPath() + "token.otp";

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

        void RunTask(ThreadStart task)
        {
            Thread updater = new Thread(task);
            updater.SetApartmentState(ApartmentState.STA);
            updater.IsBackground = true;
            updater.Start();
        }

        string request(string link, bool mode = false)
        {
            string request_ = "";

            if (user_id != "")
            {
                try
                {
                    request_ = client.DownloadString(link);
                    match = Regex.Match(request_, "code\":(.*),\"message");
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
                                cb_CustomNumber.Checked = false;
                                status_label.Text = exam_status + "This number is not available";
                            }
                            else if (status_code == "-101")
                            {
                                cb_CustomNumber.Checked = false;
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

        void generate()
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

            cb_Viettel.ForeColor = cb_Vinaphone.ForeColor = cb_Mobifone.ForeColor = cb_Vietnamobile.ForeColor = cb_Itelecom.ForeColor = cb_Wintel.ForeColor = SystemColors.ControlText;

            // get selected service
            session_service = comboBox1.SelectedIndex;
            string service_info = service_list[session_service].ToString();

            match = Regex.Match(service_info, "id\":(.*),\"name");
            string service_id = match.Groups[1].Value;

            // request number
            string request_ = "https://api.viotp.com/request/getv2?token=" + user_id + "&serviceId=" + service_id;
            if (cb_CustomNumber.Checked == true)
            {
                request_ = request(request_ + "&number=" + txt_Number.Text.Replace("-", ""), true);
            }
            else
            {
                // get selected network
                foreach (KeyValuePair<CheckBox, bool> entry in checkBoxDict)
                {
                    if (entry.Key.CheckState == CheckState.Checked)
                    {
                        session_network += entry.Key.Text.ToUpper() + "|";
                    }
                }

                request_ = request(request_ + "&network=" + session_network, true);
            }

            // get balance and number
            main_update();

            if (request_ != "")
            {
                match = Regex.Match(request_, "re_phone_number\":\"(.*)\",\"countryISO");
                session_number = match.Groups[1].Value;
                match = Regex.Match(request_, "request_id\":(.*),\"balance");
                session_id = match.Groups[1].Value;

                Clipboard.SetText(session_number);
                color_network(session_number);

                txt_Number.BackColor = Color.FromArgb(255, 224, 192);
                txt_Number.Text = "0" + String.Format("{0:####-###-###}", Convert.ToInt32(session_number));
            }
            else
            {
                txt_Number.BackColor = SystemColors.Window;
                txt_Number.Text = "Number";
            }
            txt_OTPCode.BackColor = SystemColors.Window;
            txt_OTPCode.Text = "OTP Code";
        }

        void main_update()
        {
            string request_ = "";

            // get balance
            if (user_id != "")
            {
                request_ = request("https://api.viotp.com/users/balance?token=" + user_id);
                if (request_ != "")
                {
                    match = Regex.Match(request_, "balance\":(.*)}}");
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
                    match = Regex.Match(request_, "Status\":(.*),\"CreatedTime");
                    session_status = match.Groups[1].Value;
                    match = Regex.Match(request_, "Code\":\"(.*)\",\"PhoneOriginal");
                    session_code = match.Groups[1].Value;
                }
            }
        }

        void ui_update()
        {
            // check account status
            if (user_id != "")
            {
                if (user_balance >= lowest_price)
                {
                    btn_Generate.Enabled = true;
                    txt_ID.Enabled = false;
                    btn_Login.Enabled = false;
                }
                else
                {
                    if (session_id == "")
                    {
                        btn_Generate.Enabled = false;
                        txt_ID.Enabled = true;
                        btn_Login.Enabled = true;
                    }
                    else
                    {
                        btn_Generate.Enabled = false;
                        txt_ID.Enabled = false;
                        btn_Login.Enabled = false;
                    }
                }

                if (session_id != "")
                {
                    string status_title = "";

                    if (session_status == "1")
                    {
                        txt_OTPCode.BackColor = Color.FromArgb(255, 192, 192);
                        txt_OTPCode.Text = session_code;
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

        void login()
        {
            user_id = txt_ID.Text;

            main_update();

            if (user_id != "")
            {
                if (comboBox1.Items.Count == 0)
                {
                    get_service(comboBox1, service_list, "vn");
                }
                status_label.Text = exam_status + "Welcome to VietnamOTP";
                File.WriteAllText(token_path, user_id);
            }
        }

        void get_service(ComboBox comboBox, ArrayList service_list, string country)
        {
            string request_ = request("https://api.viotp.com/service/getv2?token=" + user_id + "&country=" + country, true);
            if (request_ != "")
            {
                request_ = Regex.Replace(request_, "{.*\\[", "").Replace("},{", "|").Replace("{", "").Replace("}]}", "");
                string[] raw_service_list = request_.Split('|');
                string[] a = {
                        "ShopeePay", "ShopeeFood", "Lazada", "Tiki", "Fahasa", "Toss", "Alibaba", "Uber", "Viber", "Paypal", "Zoho", "Lotteria", "Microsoft",
                        "Telegram", "Tiktok", "Discord", "Gmail", "Facebook", "Zalopay", "ShopBack", "Hao Hao", "VinID", "Gojek", "Grab", "Amazon", "Instagram",
                        "WhatsApp", "Twitter", "Apple ID", "Ebay", "Tinder", "Wechat", "WhatsApp"
                };
                string other_service_info = "";

                foreach (string service_info in raw_service_list)
                {
                    if (a.Any(service_info.Contains))
                    {
                        // get service info
                        match = Regex.Match(service_info, "name\":\"(.*)\",\"price");
                        string service_name = match.Groups[1].Value;
                        match = Regex.Match(service_info, "price\":(.*)");
                        string service_price = match.Groups[1].Value;

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
                    else if (service_info.Contains("OTHER"))
                    {
                        other_service_info = service_info;
                    }
                }

                if (other_service_info != null)
                {
                    // get service info
                    string service_name = "------         Other Service         ------";
                    match = Regex.Match(other_service_info, "price\":(.*)");
                    string service_price = match.Groups[1].Value;

                    // format price
                    service_price = String.Format("{0:n0}", Convert.ToInt32(service_price));
                    if (service_price.Count() <= 3) service_price = "   " + service_price;

                    // add service to list
                    service_list.Add(other_service_info);
                    comboBox.Items.Add("ID" + service_list.Count.ToString("00") + ":    " + service_price + " VND  |  " + service_name);
                }

                if (comboBox.Items.Count != 0)
                {
                    comboBox.SelectedIndex = session_service;
                }
            }
        }

        void color_network(string number)
        {
            string prefix = number.Substring(0, 3);

            if (prefix_viettel.Any(prefix.Contains)) cb_Viettel.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_vinaphone.Any(prefix.Contains)) cb_Vinaphone.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_mobifone.Any(prefix.Contains)) cb_Mobifone.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_vietnamobile.Any(prefix.Contains)) cb_Vietnamobile.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_itelecom.Any(prefix.Contains)) cb_Itelecom.ForeColor = Color.FromArgb(236, 38, 43);
            if (prefix_wintel.Any(prefix.Contains)) cb_Wintel.ForeColor = Color.FromArgb(236, 38, 43);
        }

        string[] prefix_viettel = { "032", "033", "034", "035", "036", "037", "038", "039", "086", "096", "097", "098" };
        string[] prefix_vinaphone = { "081", "082", "083", "084", "085", "088", "091", "094" };
        string[] prefix_mobifone = { "070", "076", "077", "078", "079", "089", "090", "093" };
        string[] prefix_vietnamobile = { "052", "056", "058", "092" };
        string[] prefix_itelecom = { "087" };
        string[] prefix_wintel = { "055" };

        Dictionary<CheckBox, bool> checkBoxDict = new Dictionary<CheckBox, bool>();
        int checkedCount = 6;

        void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            bool checkState = checkBoxDict[checkBox];
            if (checkBox.CheckState == CheckState.Unchecked)
            {
                if (checkState)
                {
                    checkState = false;
                    checkBox.CheckState = CheckState.Indeterminate;
                    checkedCount--;
                }
                else
                {
                    checkState = true;
                    checkBox.CheckState = CheckState.Checked;
                    checkedCount++;
                }
            }
            checkBoxDict[checkBox] = checkState;

            if (checkedCount == 0)
            {
                checkBoxDict[checkBox] = true;
                checkBox.CheckState = CheckState.Checked;
                checkedCount++;
            }
        }

        private void cb_CustomNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_CustomNumber.Checked == true)
            {
                if (txt_Number.Text == "Number") txt_Number.Text = "";
                txt_Number.Enabled = true;
            }
            else
            {
                if (session_id == "") txt_Number.Text = "Number";
                else txt_Number.Text = "0" + String.Format("{0:####-###-###}", Convert.ToInt32(session_number));
                txt_Number.Enabled = false;
            }
        }
    }
}
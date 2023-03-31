namespace VietnamOTP_Service
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.btn_Copy_Number = new System.Windows.Forms.Button();
            this.txt_OTPCode = new System.Windows.Forms.TextBox();
            this.btn_Copy_OTPCode = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.status_label = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.balance_label = new System.Windows.Forms.Label();
            this.btn_Expand = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cb_Viettel = new System.Windows.Forms.CheckBox();
            this.cb_Vinaphone = new System.Windows.Forms.CheckBox();
            this.cb_Mobifone = new System.Windows.Forms.CheckBox();
            this.cb_Vietnamobile = new System.Windows.Forms.CheckBox();
            this.cb_Itelecom = new System.Windows.Forms.CheckBox();
            this.cb_Wintel = new System.Windows.Forms.CheckBox();
            this.cb_CustomNumber = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ElipseControl = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.DragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.ControlPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pb_Flag = new System.Windows.Forms.PictureBox();
            this.pb_Logo = new System.Windows.Forms.PictureBox();
            this.btn_Minimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_Close = new Bunifu.Framework.UI.BunifuImageButton();
            this.DragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(32, 40);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(192, 20);
            this.txt_ID.TabIndex = 0;
            // 
            // btn_Generate
            // 
            this.btn_Generate.Enabled = false;
            this.btn_Generate.Location = new System.Drawing.Point(214, 159);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(75, 23);
            this.btn_Generate.TabIndex = 3;
            this.btn_Generate.Text = "Generate";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(13, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Balance";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(230, 39);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(59, 23);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Number
            // 
            this.txt_Number.Enabled = false;
            this.txt_Number.Location = new System.Drawing.Point(12, 71);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Size = new System.Drawing.Size(190, 20);
            this.txt_Number.TabIndex = 9;
            this.txt_Number.Text = "Number";
            this.txt_Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Number_KeyPress);
            // 
            // btn_Copy_Number
            // 
            this.btn_Copy_Number.Location = new System.Drawing.Point(208, 70);
            this.btn_Copy_Number.Name = "btn_Copy_Number";
            this.btn_Copy_Number.Size = new System.Drawing.Size(59, 23);
            this.btn_Copy_Number.TabIndex = 4;
            this.btn_Copy_Number.Text = "Copy";
            this.btn_Copy_Number.UseVisualStyleBackColor = true;
            this.btn_Copy_Number.Click += new System.EventHandler(this.btn_Copy_Number_Click);
            // 
            // txt_OTPCode
            // 
            this.txt_OTPCode.Enabled = false;
            this.txt_OTPCode.Location = new System.Drawing.Point(12, 102);
            this.txt_OTPCode.Name = "txt_OTPCode";
            this.txt_OTPCode.Size = new System.Drawing.Size(190, 20);
            this.txt_OTPCode.TabIndex = 0;
            this.txt_OTPCode.Text = "OTP Code";
            // 
            // btn_Copy_OTPCode
            // 
            this.btn_Copy_OTPCode.Location = new System.Drawing.Point(208, 101);
            this.btn_Copy_OTPCode.Name = "btn_Copy_OTPCode";
            this.btn_Copy_OTPCode.Size = new System.Drawing.Size(59, 23);
            this.btn_Copy_OTPCode.TabIndex = 5;
            this.btn_Copy_OTPCode.Text = "Copy";
            this.btn_Copy_OTPCode.UseVisualStyleBackColor = true;
            this.btn_Copy_OTPCode.Click += new System.EventHandler(this.btn_Copy_OTPCode_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // status_label
            // 
            this.status_label.BackColor = System.Drawing.Color.Gainsboro;
            this.status_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_label.Location = new System.Drawing.Point(13, 135);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(275, 20);
            this.status_label.TabIndex = 0;
            this.status_label.Text = "Status:  Welcome to VietnamOTP";
            this.status_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 187);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // balance_label
            // 
            this.balance_label.BackColor = System.Drawing.Color.Gainsboro;
            this.balance_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balance_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balance_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.balance_label.Location = new System.Drawing.Point(71, 162);
            this.balance_label.Name = "balance_label";
            this.balance_label.Size = new System.Drawing.Size(138, 18);
            this.balance_label.TabIndex = 0;
            this.balance_label.Text = "VND";
            this.balance_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Expand
            // 
            this.btn_Expand.Location = new System.Drawing.Point(271, 70);
            this.btn_Expand.Name = "btn_Expand";
            this.btn_Expand.Size = new System.Drawing.Size(18, 54);
            this.btn_Expand.TabIndex = 6;
            this.btn_Expand.Text = ">";
            this.btn_Expand.UseVisualStyleBackColor = true;
            this.btn_Expand.Click += new System.EventHandler(this.btn_Expand_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.cb_Viettel);
            this.flowLayoutPanel1.Controls.Add(this.cb_Vinaphone);
            this.flowLayoutPanel1.Controls.Add(this.cb_Mobifone);
            this.flowLayoutPanel1.Controls.Add(this.cb_Vietnamobile);
            this.flowLayoutPanel1.Controls.Add(this.cb_Itelecom);
            this.flowLayoutPanel1.Controls.Add(this.cb_Wintel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(301, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(88, 140);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // cb_Viettel
            // 
            this.cb_Viettel.AutoSize = true;
            this.cb_Viettel.Checked = true;
            this.cb_Viettel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Viettel.Location = new System.Drawing.Point(3, 3);
            this.cb_Viettel.Name = "cb_Viettel";
            this.cb_Viettel.Size = new System.Drawing.Size(55, 17);
            this.cb_Viettel.TabIndex = 0;
            this.cb_Viettel.Text = "Viettel";
            this.toolTip1.SetToolTip(this.cb_Viettel, "Vietnam");
            this.cb_Viettel.UseVisualStyleBackColor = true;
            this.cb_Viettel.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cb_Vinaphone
            // 
            this.cb_Vinaphone.AutoSize = true;
            this.cb_Vinaphone.Checked = true;
            this.cb_Vinaphone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Vinaphone.Location = new System.Drawing.Point(3, 26);
            this.cb_Vinaphone.Name = "cb_Vinaphone";
            this.cb_Vinaphone.Size = new System.Drawing.Size(77, 17);
            this.cb_Vinaphone.TabIndex = 1;
            this.cb_Vinaphone.Text = "Vinaphone";
            this.toolTip1.SetToolTip(this.cb_Vinaphone, "Vietnam");
            this.cb_Vinaphone.UseVisualStyleBackColor = true;
            this.cb_Vinaphone.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cb_Mobifone
            // 
            this.cb_Mobifone.AutoSize = true;
            this.cb_Mobifone.Checked = true;
            this.cb_Mobifone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Mobifone.Location = new System.Drawing.Point(3, 49);
            this.cb_Mobifone.Name = "cb_Mobifone";
            this.cb_Mobifone.Size = new System.Drawing.Size(70, 17);
            this.cb_Mobifone.TabIndex = 2;
            this.cb_Mobifone.Text = "Mobifone";
            this.toolTip1.SetToolTip(this.cb_Mobifone, "Vietnam");
            this.cb_Mobifone.UseVisualStyleBackColor = true;
            this.cb_Mobifone.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cb_Vietnamobile
            // 
            this.cb_Vietnamobile.AutoSize = true;
            this.cb_Vietnamobile.Checked = true;
            this.cb_Vietnamobile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Vietnamobile.Location = new System.Drawing.Point(3, 72);
            this.cb_Vietnamobile.Name = "cb_Vietnamobile";
            this.cb_Vietnamobile.Size = new System.Drawing.Size(86, 17);
            this.cb_Vietnamobile.TabIndex = 3;
            this.cb_Vietnamobile.Text = "Vietnamobile";
            this.toolTip1.SetToolTip(this.cb_Vietnamobile, "Vietnam");
            this.cb_Vietnamobile.UseVisualStyleBackColor = true;
            this.cb_Vietnamobile.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cb_Itelecom
            // 
            this.cb_Itelecom.AutoSize = true;
            this.cb_Itelecom.Checked = true;
            this.cb_Itelecom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Itelecom.Location = new System.Drawing.Point(3, 95);
            this.cb_Itelecom.Name = "cb_Itelecom";
            this.cb_Itelecom.Size = new System.Drawing.Size(66, 17);
            this.cb_Itelecom.TabIndex = 4;
            this.cb_Itelecom.Text = "Itelecom";
            this.toolTip1.SetToolTip(this.cb_Itelecom, "Vietnam");
            this.cb_Itelecom.UseVisualStyleBackColor = true;
            this.cb_Itelecom.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cb_Wintel
            // 
            this.cb_Wintel.AutoSize = true;
            this.cb_Wintel.Checked = true;
            this.cb_Wintel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Wintel.Location = new System.Drawing.Point(3, 118);
            this.cb_Wintel.Name = "cb_Wintel";
            this.cb_Wintel.Size = new System.Drawing.Size(56, 17);
            this.cb_Wintel.TabIndex = 5;
            this.cb_Wintel.Text = "Wintel";
            this.toolTip1.SetToolTip(this.cb_Wintel, "Vietnam");
            this.cb_Wintel.UseVisualStyleBackColor = true;
            this.cb_Wintel.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cb_CustomNumber
            // 
            this.cb_CustomNumber.AutoSize = true;
            this.cb_CustomNumber.Location = new System.Drawing.Point(301, 190);
            this.cb_CustomNumber.Name = "cb_CustomNumber";
            this.cb_CustomNumber.Size = new System.Drawing.Size(97, 17);
            this.cb_CustomNumber.TabIndex = 8;
            this.cb_CustomNumber.Text = "Phone Number";
            this.toolTip1.SetToolTip(this.cb_CustomNumber, "Check here to use custom number generator function, see detailed instructions on " +
        "github");
            this.cb_CustomNumber.UseVisualStyleBackColor = true;
            this.cb_CustomNumber.CheckedChanged += new System.EventHandler(this.cb_CustomNumber_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // ElipseControl
            // 
            this.ElipseControl.ElipseRadius = 10;
            this.ElipseControl.TargetControl = this;
            // 
            // DragControl1
            // 
            this.DragControl1.Fixed = true;
            this.DragControl1.Horizontal = true;
            this.DragControl1.TargetControl = this.ControlPanel;
            this.DragControl1.Vertical = true;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ControlPanel.BackgroundImage")));
            this.ControlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ControlPanel.Controls.Add(this.pb_Flag);
            this.ControlPanel.Controls.Add(this.pb_Logo);
            this.ControlPanel.Controls.Add(this.btn_Minimize);
            this.ControlPanel.Controls.Add(this.btn_Close);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlPanel.GradientBottomLeft = System.Drawing.Color.LightGray;
            this.ControlPanel.GradientBottomRight = System.Drawing.Color.LightYellow;
            this.ControlPanel.GradientTopLeft = System.Drawing.Color.DarkOrange;
            this.ControlPanel.GradientTopRight = System.Drawing.Color.Goldenrod;
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Quality = 10;
            this.ControlPanel.Size = new System.Drawing.Size(402, 28);
            this.ControlPanel.TabIndex = 0;
            // 
            // pb_Flag
            // 
            this.pb_Flag.BackColor = System.Drawing.Color.Transparent;
            this.pb_Flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Flag.Image = ((System.Drawing.Image)(resources.GetObject("pb_Flag.Image")));
            this.pb_Flag.Location = new System.Drawing.Point(75, 6);
            this.pb_Flag.Name = "pb_Flag";
            this.pb_Flag.Size = new System.Drawing.Size(24, 16);
            this.pb_Flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Flag.TabIndex = 3;
            this.pb_Flag.TabStop = false;
            this.pb_Flag.Click += new System.EventHandler(this.pb_Flag_Click);
            // 
            // pb_Logo
            // 
            this.pb_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_Logo.Image = global::VietnamOTP_Service.Properties.Resources.Logo;
            this.pb_Logo.Location = new System.Drawing.Point(6, 2);
            this.pb_Logo.Name = "pb_Logo";
            this.pb_Logo.Size = new System.Drawing.Size(60, 23);
            this.pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Logo.TabIndex = 2;
            this.pb_Logo.TabStop = false;
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Minimize.Image = ((System.Drawing.Image)(resources.GetObject("btn_Minimize.Image")));
            this.btn_Minimize.ImageActive = null;
            this.btn_Minimize.Location = new System.Drawing.Point(349, 3);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(22, 22);
            this.btn_Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Minimize.TabIndex = 1;
            this.btn_Minimize.TabStop = false;
            this.btn_Minimize.Zoom = 10;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.ImageActive = null;
            this.btn_Close.Location = new System.Drawing.Point(375, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(22, 22);
            this.btn_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.Zoom = 10;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // DragControl2
            // 
            this.DragControl2.Fixed = true;
            this.DragControl2.Horizontal = true;
            this.DragControl2.TargetControl = this.pb_Logo;
            this.DragControl2.Vertical = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 222);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.cb_CustomNumber);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_Expand);
            this.Controls.Add(this.balance_label);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.btn_Copy_OTPCode);
            this.Controls.Add(this.txt_OTPCode);
            this.Controls.Add(this.btn_Copy_Number);
            this.Controls.Add(this.txt_Number);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.txt_ID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VietnamOTP Service";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.TextBox txt_OTPCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Copy_Number;
        private System.Windows.Forms.Button btn_Copy_OTPCode;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.Button btn_Expand;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Label balance_label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cb_Viettel;
        private System.Windows.Forms.CheckBox cb_Vinaphone;
        private System.Windows.Forms.CheckBox cb_Mobifone;
        private System.Windows.Forms.CheckBox cb_Vietnamobile;
        private System.Windows.Forms.CheckBox cb_Itelecom;
        private System.Windows.Forms.CheckBox cb_Wintel;
        private System.Windows.Forms.CheckBox cb_CustomNumber;
        private System.Windows.Forms.ToolTip toolTip1;
        private Bunifu.Framework.UI.BunifuElipse ElipseControl;
        private Bunifu.Framework.UI.BunifuGradientPanel ControlPanel;
        private Bunifu.Framework.UI.BunifuDragControl DragControl1;
        private Bunifu.Framework.UI.BunifuImageButton btn_Close;
        private Bunifu.Framework.UI.BunifuImageButton btn_Minimize;
        private System.Windows.Forms.PictureBox pb_Logo;
        private Bunifu.Framework.UI.BunifuDragControl DragControl2;
        private System.Windows.Forms.PictureBox pb_Flag;
    }
}


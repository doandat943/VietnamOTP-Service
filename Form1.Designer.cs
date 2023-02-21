namespace VietnamOTP_Service
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.generate_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.status_label = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.balance_label = new System.Windows.Forms.Label();
            this.expand_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cb_viettel = new System.Windows.Forms.CheckBox();
            this.cb_vinaphone = new System.Windows.Forms.CheckBox();
            this.cb_mobifone = new System.Windows.Forms.CheckBox();
            this.cb_vietnamobile = new System.Windows.Forms.CheckBox();
            this.cb_itelecom = new System.Windows.Forms.CheckBox();
            this.cb_wintel = new System.Windows.Forms.CheckBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ElipseControl = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.DragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.ControlPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.Country_Icon = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Minimize_Button = new Bunifu.Framework.UI.BunifuImageButton();
            this.Close_Button = new Bunifu.Framework.UI.BunifuImageButton();
            this.DragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Country_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 0;
            // 
            // generate_button
            // 
            this.generate_button.Enabled = false;
            this.generate_button.Location = new System.Drawing.Point(214, 159);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(75, 23);
            this.generate_button.TabIndex = 3;
            this.generate_button.Text = "Generate";
            this.generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
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
            this.label2.Size = new System.Drawing.Size(60, 18);
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
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(230, 39);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(59, 23);
            this.login_button.TabIndex = 1;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(12, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Number";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(12, 102);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(190, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "OTP Code";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // expand_button
            // 
            this.expand_button.Location = new System.Drawing.Point(271, 70);
            this.expand_button.Name = "expand_button";
            this.expand_button.Size = new System.Drawing.Size(18, 54);
            this.expand_button.TabIndex = 6;
            this.expand_button.Text = ">";
            this.expand_button.UseVisualStyleBackColor = true;
            this.expand_button.Click += new System.EventHandler(this.expand_button_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.cb_viettel);
            this.flowLayoutPanel1.Controls.Add(this.cb_vinaphone);
            this.flowLayoutPanel1.Controls.Add(this.cb_mobifone);
            this.flowLayoutPanel1.Controls.Add(this.cb_vietnamobile);
            this.flowLayoutPanel1.Controls.Add(this.cb_itelecom);
            this.flowLayoutPanel1.Controls.Add(this.cb_wintel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(301, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(88, 140);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // cb_viettel
            // 
            this.cb_viettel.AutoSize = true;
            this.cb_viettel.Checked = true;
            this.cb_viettel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_viettel.Location = new System.Drawing.Point(3, 3);
            this.cb_viettel.Name = "cb_viettel";
            this.cb_viettel.Size = new System.Drawing.Size(55, 17);
            this.cb_viettel.TabIndex = 0;
            this.cb_viettel.Text = "Viettel";
            this.toolTip1.SetToolTip(this.cb_viettel, "Vietnam");
            this.cb_viettel.UseVisualStyleBackColor = true;
            this.cb_viettel.CheckedChanged += new System.EventHandler(this.cb_viettel_CheckedChanged);
            // 
            // cb_vinaphone
            // 
            this.cb_vinaphone.AutoSize = true;
            this.cb_vinaphone.Checked = true;
            this.cb_vinaphone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_vinaphone.Location = new System.Drawing.Point(3, 26);
            this.cb_vinaphone.Name = "cb_vinaphone";
            this.cb_vinaphone.Size = new System.Drawing.Size(77, 17);
            this.cb_vinaphone.TabIndex = 1;
            this.cb_vinaphone.Text = "Vinaphone";
            this.toolTip1.SetToolTip(this.cb_vinaphone, "Vietnam");
            this.cb_vinaphone.UseVisualStyleBackColor = true;
            this.cb_vinaphone.CheckedChanged += new System.EventHandler(this.cb_vinaphone_CheckedChanged);
            // 
            // cb_mobifone
            // 
            this.cb_mobifone.AutoSize = true;
            this.cb_mobifone.Checked = true;
            this.cb_mobifone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mobifone.Location = new System.Drawing.Point(3, 49);
            this.cb_mobifone.Name = "cb_mobifone";
            this.cb_mobifone.Size = new System.Drawing.Size(70, 17);
            this.cb_mobifone.TabIndex = 2;
            this.cb_mobifone.Text = "Mobifone";
            this.toolTip1.SetToolTip(this.cb_mobifone, "Vietnam");
            this.cb_mobifone.UseVisualStyleBackColor = true;
            this.cb_mobifone.CheckedChanged += new System.EventHandler(this.cb_mobifone_CheckedChanged);
            // 
            // cb_vietnamobile
            // 
            this.cb_vietnamobile.AutoSize = true;
            this.cb_vietnamobile.Checked = true;
            this.cb_vietnamobile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_vietnamobile.Location = new System.Drawing.Point(3, 72);
            this.cb_vietnamobile.Name = "cb_vietnamobile";
            this.cb_vietnamobile.Size = new System.Drawing.Size(86, 17);
            this.cb_vietnamobile.TabIndex = 3;
            this.cb_vietnamobile.Text = "Vietnamobile";
            this.toolTip1.SetToolTip(this.cb_vietnamobile, "Vietnam");
            this.cb_vietnamobile.UseVisualStyleBackColor = true;
            this.cb_vietnamobile.CheckedChanged += new System.EventHandler(this.cb_vietnamobile_CheckedChanged);
            // 
            // cb_itelecom
            // 
            this.cb_itelecom.AutoSize = true;
            this.cb_itelecom.Checked = true;
            this.cb_itelecom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_itelecom.Location = new System.Drawing.Point(3, 95);
            this.cb_itelecom.Name = "cb_itelecom";
            this.cb_itelecom.Size = new System.Drawing.Size(66, 17);
            this.cb_itelecom.TabIndex = 4;
            this.cb_itelecom.Text = "Itelecom";
            this.toolTip1.SetToolTip(this.cb_itelecom, "Vietnam");
            this.cb_itelecom.UseVisualStyleBackColor = true;
            this.cb_itelecom.CheckedChanged += new System.EventHandler(this.cb_itelecom_CheckedChanged);
            // 
            // cb_wintel
            // 
            this.cb_wintel.AutoSize = true;
            this.cb_wintel.Checked = true;
            this.cb_wintel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_wintel.Location = new System.Drawing.Point(3, 118);
            this.cb_wintel.Name = "cb_wintel";
            this.cb_wintel.Size = new System.Drawing.Size(56, 17);
            this.cb_wintel.TabIndex = 5;
            this.cb_wintel.Text = "Wintel";
            this.toolTip1.SetToolTip(this.cb_wintel, "Vietnam");
            this.cb_wintel.UseVisualStyleBackColor = true;
            this.cb_wintel.CheckedChanged += new System.EventHandler(this.cb_wintel_CheckedChanged);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(301, 190);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(97, 17);
            this.checkBox.TabIndex = 8;
            this.checkBox.Text = "Phone Number";
            this.toolTip1.SetToolTip(this.checkBox, "Check here to use custom number generator function, see detailed instructions on " +
        "github");
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
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
            this.ControlPanel.Controls.Add(this.Country_Icon);
            this.ControlPanel.Controls.Add(this.Logo);
            this.ControlPanel.Controls.Add(this.Minimize_Button);
            this.ControlPanel.Controls.Add(this.Close_Button);
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
            // Country_Icon
            // 
            this.Country_Icon.BackColor = System.Drawing.Color.Transparent;
            this.Country_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Country_Icon.Image = ((System.Drawing.Image)(resources.GetObject("Country_Icon.Image")));
            this.Country_Icon.Location = new System.Drawing.Point(72, 6);
            this.Country_Icon.Name = "Country_Icon";
            this.Country_Icon.Size = new System.Drawing.Size(24, 16);
            this.Country_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Country_Icon.TabIndex = 3;
            this.Country_Icon.TabStop = false;
            this.Country_Icon.Click += new System.EventHandler(this.Country_Icon_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = global::VietnamOTP_Service.Properties.Resources.Logo;
            this.Logo.Location = new System.Drawing.Point(6, 2);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(60, 23);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 2;
            this.Logo.TabStop = false;
            // 
            // Minimize_Button
            // 
            this.Minimize_Button.BackColor = System.Drawing.Color.Transparent;
            this.Minimize_Button.Image = ((System.Drawing.Image)(resources.GetObject("Minimize_Button.Image")));
            this.Minimize_Button.ImageActive = null;
            this.Minimize_Button.Location = new System.Drawing.Point(349, 3);
            this.Minimize_Button.Name = "Minimize_Button";
            this.Minimize_Button.Size = new System.Drawing.Size(22, 22);
            this.Minimize_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Minimize_Button.TabIndex = 1;
            this.Minimize_Button.TabStop = false;
            this.Minimize_Button.Zoom = 10;
            this.Minimize_Button.Click += new System.EventHandler(this.Minimize_Button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.BackColor = System.Drawing.Color.Transparent;
            this.Close_Button.Image = ((System.Drawing.Image)(resources.GetObject("Close_Button.Image")));
            this.Close_Button.ImageActive = null;
            this.Close_Button.Location = new System.Drawing.Point(375, 3);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(22, 22);
            this.Close_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Close_Button.TabIndex = 0;
            this.Close_Button.TabStop = false;
            this.Close_Button.Zoom = 10;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // DragControl2
            // 
            this.DragControl2.Fixed = true;
            this.DragControl2.Horizontal = true;
            this.DragControl2.TargetControl = this.Logo;
            this.DragControl2.Vertical = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 222);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.expand_button);
            this.Controls.Add(this.balance_label);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generate_button);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VietnamOTP Service";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Country_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.Button expand_button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Label balance_label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cb_viettel;
        private System.Windows.Forms.CheckBox cb_vinaphone;
        private System.Windows.Forms.CheckBox cb_mobifone;
        private System.Windows.Forms.CheckBox cb_vietnamobile;
        private System.Windows.Forms.CheckBox cb_itelecom;
        private System.Windows.Forms.CheckBox cb_wintel;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private Bunifu.Framework.UI.BunifuElipse ElipseControl;
        private Bunifu.Framework.UI.BunifuGradientPanel ControlPanel;
        private Bunifu.Framework.UI.BunifuDragControl DragControl1;
        private Bunifu.Framework.UI.BunifuImageButton Close_Button;
        private Bunifu.Framework.UI.BunifuImageButton Minimize_Button;
        private System.Windows.Forms.PictureBox Logo;
        private Bunifu.Framework.UI.BunifuDragControl DragControl2;
        private System.Windows.Forms.PictureBox Country_Icon;
    }
}


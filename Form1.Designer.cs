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
            this.network1 = new System.Windows.Forms.CheckBox();
            this.network2 = new System.Windows.Forms.CheckBox();
            this.network3 = new System.Windows.Forms.CheckBox();
            this.network4 = new System.Windows.Forms.CheckBox();
            this.network5 = new System.Windows.Forms.CheckBox();
            this.network6 = new System.Windows.Forms.CheckBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 0;
            // 
            // generate_button
            // 
            this.generate_button.Enabled = false;
            this.generate_button.Location = new System.Drawing.Point(214, 132);
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
            this.label2.Location = new System.Drawing.Point(13, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Balance";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(230, 12);
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
            this.textBox2.Location = new System.Drawing.Point(12, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Number";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 43);
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
            this.textBox3.Location = new System.Drawing.Point(12, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(190, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "OTP Code";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 74);
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
            this.status_label.Location = new System.Drawing.Point(13, 108);
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
            this.comboBox1.Location = new System.Drawing.Point(12, 160);
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
            this.balance_label.Location = new System.Drawing.Point(71, 135);
            this.balance_label.Name = "balance_label";
            this.balance_label.Size = new System.Drawing.Size(138, 18);
            this.balance_label.TabIndex = 0;
            this.balance_label.Text = "VND";
            this.balance_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // expand_button
            // 
            this.expand_button.Location = new System.Drawing.Point(271, 43);
            this.expand_button.Name = "expand_button";
            this.expand_button.Size = new System.Drawing.Size(18, 54);
            this.expand_button.TabIndex = 7;
            this.expand_button.Text = ">";
            this.expand_button.UseVisualStyleBackColor = true;
            this.expand_button.Click += new System.EventHandler(this.expand_button_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.network1);
            this.flowLayoutPanel1.Controls.Add(this.network2);
            this.flowLayoutPanel1.Controls.Add(this.network3);
            this.flowLayoutPanel1.Controls.Add(this.network4);
            this.flowLayoutPanel1.Controls.Add(this.network5);
            this.flowLayoutPanel1.Controls.Add(this.network6);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(301, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(88, 140);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // network1
            // 
            this.network1.AutoSize = true;
            this.network1.Checked = true;
            this.network1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.network1.Location = new System.Drawing.Point(3, 3);
            this.network1.Name = "network1";
            this.network1.Size = new System.Drawing.Size(55, 17);
            this.network1.TabIndex = 0;
            this.network1.Text = "Viettel";
            this.toolTip1.SetToolTip(this.network1, "Vietnam");
            this.network1.UseVisualStyleBackColor = true;
            this.network1.CheckedChanged += new System.EventHandler(this.network1_CheckedChanged);
            // 
            // network2
            // 
            this.network2.AutoSize = true;
            this.network2.Checked = true;
            this.network2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.network2.Location = new System.Drawing.Point(3, 26);
            this.network2.Name = "network2";
            this.network2.Size = new System.Drawing.Size(77, 17);
            this.network2.TabIndex = 1;
            this.network2.Text = "Vinaphone";
            this.toolTip1.SetToolTip(this.network2, "Vietnam");
            this.network2.UseVisualStyleBackColor = true;
            this.network2.CheckedChanged += new System.EventHandler(this.network2_CheckedChanged);
            // 
            // network3
            // 
            this.network3.AutoSize = true;
            this.network3.Checked = true;
            this.network3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.network3.Location = new System.Drawing.Point(3, 49);
            this.network3.Name = "network3";
            this.network3.Size = new System.Drawing.Size(70, 17);
            this.network3.TabIndex = 2;
            this.network3.Text = "Mobifone";
            this.toolTip1.SetToolTip(this.network3, "Vietnam");
            this.network3.UseVisualStyleBackColor = true;
            this.network3.CheckedChanged += new System.EventHandler(this.network3_CheckedChanged);
            // 
            // network4
            // 
            this.network4.AutoSize = true;
            this.network4.Checked = true;
            this.network4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.network4.Location = new System.Drawing.Point(3, 72);
            this.network4.Name = "network4";
            this.network4.Size = new System.Drawing.Size(86, 17);
            this.network4.TabIndex = 3;
            this.network4.Text = "Vietnamobile";
            this.toolTip1.SetToolTip(this.network4, "Vietnam");
            this.network4.UseVisualStyleBackColor = true;
            this.network4.CheckedChanged += new System.EventHandler(this.network4_CheckedChanged);
            // 
            // network5
            // 
            this.network5.AutoSize = true;
            this.network5.Checked = true;
            this.network5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.network5.Location = new System.Drawing.Point(3, 95);
            this.network5.Name = "network5";
            this.network5.Size = new System.Drawing.Size(66, 17);
            this.network5.TabIndex = 4;
            this.network5.Text = "Itelecom";
            this.toolTip1.SetToolTip(this.network5, "Vietnam");
            this.network5.UseVisualStyleBackColor = true;
            this.network5.CheckedChanged += new System.EventHandler(this.network5_CheckedChanged);
            // 
            // network6
            // 
            this.network6.AutoSize = true;
            this.network6.Checked = true;
            this.network6.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.network6.Location = new System.Drawing.Point(3, 118);
            this.network6.Name = "network6";
            this.network6.Size = new System.Drawing.Size(72, 17);
            this.network6.TabIndex = 5;
            this.network6.Text = "Vodafone";
            this.toolTip1.SetToolTip(this.network6, "Romania");
            this.network6.UseVisualStyleBackColor = true;
            this.network6.CheckedChanged += new System.EventHandler(this.network6_CheckedChanged);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(301, 163);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(97, 17);
            this.checkBox.TabIndex = 10;
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
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 160);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(277, 21);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 193);
            this.Controls.Add(this.comboBox2);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VietnamOTP Service";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Label balance_label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox network1;
        private System.Windows.Forms.CheckBox network2;
        private System.Windows.Forms.CheckBox network3;
        private System.Windows.Forms.CheckBox network4;
        private System.Windows.Forms.CheckBox network5;
        private System.Windows.Forms.CheckBox network6;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


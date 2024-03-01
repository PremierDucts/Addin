namespace AddinsPremierducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.macAddress = new System.Windows.Forms.TextBox();
            this.uid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.errorInput = new System.Windows.Forms.TextBox();
            this.radio_dev = new System.Windows.Forms.RadioButton();
            this.radio_prod = new System.Windows.Forms.RadioButton();
            this.url_label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(1084, 173);
            this.username.Margin = new System.Windows.Forms.Padding(6);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(452, 31);
            this.username.TabIndex = 0;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(1084, 273);
            this.password.Margin = new System.Windows.Forms.Padding(6);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(452, 31);
            this.password.TabIndex = 1;
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(846, 635);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(6);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(364, 102);
            this.btn_submit.TabIndex = 2;
            this.btn_submit.Text = "Login";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // macAddress
            // 
            this.macAddress.Location = new System.Drawing.Point(1084, 408);
            this.macAddress.Margin = new System.Windows.Forms.Padding(6);
            this.macAddress.Name = "macAddress";
            this.macAddress.ReadOnly = true;
            this.macAddress.Size = new System.Drawing.Size(452, 31);
            this.macAddress.TabIndex = 3;
            // 
            // uid
            // 
            this.uid.Location = new System.Drawing.Point(1084, 512);
            this.uid.Margin = new System.Windows.Forms.Padding(6);
            this.uid.Name = "uid";
            this.uid.ReadOnly = true;
            this.uid.Size = new System.Drawing.Size(452, 31);
            this.uid.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(846, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(846, 279);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 44);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(838, 413);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 44);
            this.label3.TabIndex = 7;
            this.label3.Text = "MAC address";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(846, 517);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 44);
            this.label4.TabIndex = 8;
            this.label4.Text = "UID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 865);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(110, 177);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(484, 467);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(1498, 23);
            this.btn_close.Margin = new System.Windows.Forms.Padding(6);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(78, 44);
            this.btn_close.TabIndex = 10;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Enabled = false;
            this.btn_exit.Location = new System.Drawing.Point(1250, 635);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(290, 102);
            this.btn_exit.TabIndex = 11;
            this.btn_exit.Text = "Logout";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1408, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(802, 742);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Location check error logs:";
            // 
            // errorInput
            // 
            this.errorInput.Location = new System.Drawing.Point(802, 773);
            this.errorInput.Margin = new System.Windows.Forms.Padding(6);
            this.errorInput.Name = "errorInput";
            this.errorInput.ReadOnly = true;
            this.errorInput.Size = new System.Drawing.Size(708, 31);
            this.errorInput.TabIndex = 4;
            // 
            // radio_dev
            // 
            this.radio_dev.AutoSize = true;
            this.radio_dev.Location = new System.Drawing.Point(851, 855);
            this.radio_dev.Name = "radio_dev";
            this.radio_dev.Size = new System.Drawing.Size(169, 29);
            this.radio_dev.TabIndex = 14;
            this.radio_dev.TabStop = true;
            this.radio_dev.Text = "Development";
            this.radio_dev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio_dev.UseVisualStyleBackColor = true;
            this.radio_dev.CheckedChanged += new System.EventHandler(this.radio_dev_CheckedChanged);
            // 
            // radio_prod
            // 
            this.radio_prod.AutoSize = true;
            this.radio_prod.Location = new System.Drawing.Point(1250, 855);
            this.radio_prod.Name = "radio_prod";
            this.radio_prod.Size = new System.Drawing.Size(146, 29);
            this.radio_prod.TabIndex = 15;
            this.radio_prod.TabStop = true;
            this.radio_prod.Text = "Production";
            this.radio_prod.UseVisualStyleBackColor = true;
            this.radio_prod.CheckedChanged += new System.EventHandler(this.radio_prod_CheckedChanged);
            // 
            // url_label
            // 
            this.url_label.AutoSize = true;
            this.url_label.Location = new System.Drawing.Point(1039, 892);
            this.url_label.Name = "url_label";
            this.url_label.Size = new System.Drawing.Size(70, 25);
            this.url_label.TabIndex = 16;
            this.url_label.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1607, 929);
            this.Controls.Add(this.url_label);
            this.Controls.Add(this.radio_prod);
            this.Controls.Add(this.radio_dev);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorInput);
            this.Controls.Add(this.uid);
            this.Controls.Add(this.macAddress);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take-off Login Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox errorInput;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Button button1;


        private System.Windows.Forms.Button btn_exit;

        private System.Windows.Forms.Button btn_close;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox macAddress;
        private System.Windows.Forms.TextBox uid;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button btn_submit;

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radio_dev;
        private System.Windows.Forms.RadioButton radio_prod;
        private System.Windows.Forms.Label url_label;
    }
}
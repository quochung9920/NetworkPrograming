namespace WindowsFormsApplication4
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
            this.btnStart = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.txtmessage = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtClient1Port = new System.Windows.Forms.MaskedTextBox();
            this.txtClient2Port = new System.Windows.Forms.MaskedTextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(16, 316);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(273, 44);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(17, 28);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(448, 224);
            this.listBox1.TabIndex = 1;
            // 
            // btnsend
            // 
            this.btnsend.Enabled = false;
            this.btnsend.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsend.ForeColor = System.Drawing.Color.Teal;
            this.btnsend.Location = new System.Drawing.Point(295, 302);
            this.btnsend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(172, 48);
            this.btnsend.TabIndex = 12;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // txtmessage
            // 
            this.txtmessage.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmessage.Location = new System.Drawing.Point(17, 262);
            this.txtmessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(448, 30);
            this.txtmessage.TabIndex = 13;
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtKey.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.ForeColor = System.Drawing.SystemColors.Window;
            this.txtKey.Location = new System.Drawing.Point(29, 235);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(160, 37);
            this.txtKey.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtClient1Port);
            this.panel1.Controls.Add(this.txtClient2Port);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 293);
            this.panel1.TabIndex = 17;
            // 
            // txtClient1Port
            // 
            this.txtClient1Port.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtClient1Port.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient1Port.ForeColor = System.Drawing.SystemColors.Window;
            this.txtClient1Port.Location = new System.Drawing.Point(29, 148);
            this.txtClient1Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClient1Port.Mask = "000";
            this.txtClient1Port.Name = "txtClient1Port";
            this.txtClient1Port.Size = new System.Drawing.Size(160, 37);
            this.txtClient1Port.TabIndex = 21;
            // 
            // txtClient2Port
            // 
            this.txtClient2Port.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtClient2Port.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient2Port.ForeColor = System.Drawing.SystemColors.Window;
            this.txtClient2Port.Location = new System.Drawing.Point(29, 193);
            this.txtClient2Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClient2Port.Mask = "000";
            this.txtClient2Port.Name = "txtClient2Port";
            this.txtClient2Port.Size = new System.Drawing.Size(160, 37);
            this.txtClient2Port.TabIndex = 14;
            this.txtClient2Port.ValidatingType = typeof(int);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "SHA1",
            "SHA2",
            "MD5"});
            this.comboBox2.Location = new System.Drawing.Point(29, 57);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(160, 36);
            this.comboBox2.TabIndex = 19;
            this.comboBox2.Text = "SHA1";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "AES",
            "DES",
            "RSA"});
            this.comboBox1.Location = new System.Drawing.Point(29, 9);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 36);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.Text = "RSA";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.listBox1);
            this.panel4.Controls.Add(this.btnsend);
            this.panel4.Controls.Add(this.txtmessage);
            this.panel4.Location = new System.Drawing.Point(475, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(477, 357);
            this.panel4.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1152, 393);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Server -- Chat Secured";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox txtmessage;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.MaskedTextBox txtClient1Port;
        private System.Windows.Forms.MaskedTextBox txtClient2Port;
    }
}


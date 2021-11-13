namespace Clientthang
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
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.buttonSendRequest = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.BtClear = new System.Windows.Forms.Button();
            this.txtPublickey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrivatekey = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtPublickey = new System.Windows.Forms.Button();
            this.Lb1 = new System.Windows.Forms.Label();
            this.Lb2 = new System.Windows.Forms.Label();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.txtboxshow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRequest.Location = new System.Drawing.Point(16, 380);
            this.textBoxRequest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.Size = new System.Drawing.Size(681, 121);
            this.textBoxRequest.TabIndex = 8;
            this.textBoxRequest.TextChanged += new System.EventHandler(this.TextBoxRequest_TextChanged);
            // 
            // buttonSendRequest
            // 
            this.buttonSendRequest.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSendRequest.Location = new System.Drawing.Point(705, 447);
            this.buttonSendRequest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSendRequest.Name = "buttonSendRequest";
            this.buttonSendRequest.Size = new System.Drawing.Size(187, 54);
            this.buttonSendRequest.TabIndex = 7;
            this.buttonSendRequest.Text = "Send";
            this.buttonSendRequest.UseVisualStyleBackColor = true;
            this.buttonSendRequest.Click += new System.EventHandler(this.ButtonSendRequest_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.Location = new System.Drawing.Point(705, 79);
            this.buttonDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(187, 54);
            this.buttonDisconnect.TabIndex = 6;
            this.buttonDisconnect.Text = "StopServer";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(705, 15);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(187, 54);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "StarServer";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // BtClear
            // 
            this.BtClear.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtClear.Location = new System.Drawing.Point(705, 143);
            this.BtClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtClear.Name = "BtClear";
            this.BtClear.Size = new System.Drawing.Size(187, 54);
            this.BtClear.TabIndex = 14;
            this.BtClear.Text = "Clear";
            this.BtClear.UseVisualStyleBackColor = true;
            this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
            // 
            // txtPublickey
            // 
            this.txtPublickey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublickey.Location = new System.Drawing.Point(899, 42);
            this.txtPublickey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPublickey.Multiline = true;
            this.txtPublickey.Name = "txtPublickey";
            this.txtPublickey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublickey.Size = new System.Drawing.Size(689, 213);
            this.txtPublickey.TabIndex = 18;
            this.txtPublickey.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(899, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 19;
            this.label1.Text = "Publickey";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(899, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 28);
            this.label3.TabIndex = 24;
            this.label3.Text = "PrivateKey";
            this.label3.Visible = false;
            // 
            // txtPrivatekey
            // 
            this.txtPrivatekey.Location = new System.Drawing.Point(899, 286);
            this.txtPrivatekey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrivatekey.Multiline = true;
            this.txtPrivatekey.Name = "txtPrivatekey";
            this.txtPrivatekey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrivatekey.Size = new System.Drawing.Size(689, 216);
            this.txtPrivatekey.TabIndex = 25;
            this.txtPrivatekey.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RSA"});
            this.comboBox1.Location = new System.Drawing.Point(705, 203);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 31);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtPublickey
            // 
            this.BtPublickey.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtPublickey.Location = new System.Drawing.Point(705, 276);
            this.BtPublickey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtPublickey.Name = "BtPublickey";
            this.BtPublickey.Size = new System.Drawing.Size(187, 70);
            this.BtPublickey.TabIndex = 28;
            this.BtPublickey.Text = "Generate and SendKey";
            this.BtPublickey.UseVisualStyleBackColor = true;
            this.BtPublickey.Visible = false;
            this.BtPublickey.Click += new System.EventHandler(this.BtPublickey_Click);
            // 
            // Lb1
            // 
            this.Lb1.AutoSize = true;
            this.Lb1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb1.Location = new System.Drawing.Point(15, 11);
            this.Lb1.Name = "Lb1";
            this.Lb1.Size = new System.Drawing.Size(194, 28);
            this.Lb1.TabIndex = 29;
            this.Lb1.Text = "Message received";
            // 
            // Lb2
            // 
            this.Lb2.AutoSize = true;
            this.Lb2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb2.Location = new System.Drawing.Point(15, 350);
            this.Lb2.Name = "Lb2";
            this.Lb2.Size = new System.Drawing.Size(155, 28);
            this.Lb2.TabIndex = 30;
            this.Lb2.Text = "Message Send";
            // 
            // btDecrypt
            // 
            this.btDecrypt.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDecrypt.Location = new System.Drawing.Point(705, 380);
            this.btDecrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(187, 54);
            this.btDecrypt.TabIndex = 31;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Visible = false;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // txtboxshow
            // 
            this.txtboxshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxshow.Location = new System.Drawing.Point(20, 42);
            this.txtboxshow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxshow.Multiline = true;
            this.txtboxshow.Name = "txtboxshow";
            this.txtboxshow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxshow.Size = new System.Drawing.Size(677, 304);
            this.txtboxshow.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 516);
            this.Controls.Add(this.txtboxshow);
            this.Controls.Add(this.btDecrypt);
            this.Controls.Add(this.Lb2);
            this.Controls.Add(this.Lb1);
            this.Controls.Add(this.BtPublickey);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtPrivatekey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPublickey);
            this.Controls.Add(this.BtClear);
            this.Controls.Add(this.textBoxRequest);
            this.Controls.Add(this.buttonSendRequest);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Clientthang";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.Button buttonSendRequest;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button BtClear;
        private System.Windows.Forms.TextBox txtPublickey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrivatekey;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtPublickey;
        private System.Windows.Forms.Label Lb1;
        private System.Windows.Forms.Label Lb2;
        private System.Windows.Forms.Button btDecrypt;
        private System.Windows.Forms.TextBox txtboxshow;
    }
}


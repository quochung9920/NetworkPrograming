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
            this.textBoxRequest.Location = new System.Drawing.Point(12, 309);
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.Size = new System.Drawing.Size(512, 99);
            this.textBoxRequest.TabIndex = 8;
            this.textBoxRequest.TextChanged += new System.EventHandler(this.TextBoxRequest_TextChanged);
            // 
            // buttonSendRequest
            // 
            this.buttonSendRequest.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSendRequest.Location = new System.Drawing.Point(529, 363);
            this.buttonSendRequest.Name = "buttonSendRequest";
            this.buttonSendRequest.Size = new System.Drawing.Size(140, 44);
            this.buttonSendRequest.TabIndex = 7;
            this.buttonSendRequest.Text = "Send";
            this.buttonSendRequest.UseVisualStyleBackColor = true;
            this.buttonSendRequest.Click += new System.EventHandler(this.ButtonSendRequest_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.Location = new System.Drawing.Point(529, 64);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(140, 44);
            this.buttonDisconnect.TabIndex = 6;
            this.buttonDisconnect.Text = "StopServer";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(529, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(140, 44);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "StarServer";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // BtClear
            // 
            this.BtClear.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtClear.Location = new System.Drawing.Point(529, 116);
            this.BtClear.Name = "BtClear";
            this.BtClear.Size = new System.Drawing.Size(140, 44);
            this.BtClear.TabIndex = 14;
            this.BtClear.Text = "Clear";
            this.BtClear.UseVisualStyleBackColor = true;
            this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
            // 
            // txtPublickey
            // 
            this.txtPublickey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublickey.Location = new System.Drawing.Point(674, 34);
            this.txtPublickey.Multiline = true;
            this.txtPublickey.Name = "txtPublickey";
            this.txtPublickey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublickey.Size = new System.Drawing.Size(518, 174);
            this.txtPublickey.TabIndex = 18;
            this.txtPublickey.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(674, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Publickey";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(674, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "PrivateKey";
            this.label3.Visible = false;
            // 
            // txtPrivatekey
            // 
            this.txtPrivatekey.Location = new System.Drawing.Point(674, 232);
            this.txtPrivatekey.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrivatekey.Multiline = true;
            this.txtPrivatekey.Name = "txtPrivatekey";
            this.txtPrivatekey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrivatekey.Size = new System.Drawing.Size(518, 176);
            this.txtPrivatekey.TabIndex = 25;
            this.txtPrivatekey.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RSA"});
            this.comboBox1.Location = new System.Drawing.Point(529, 165);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 27);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtPublickey
            // 
            this.BtPublickey.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtPublickey.Location = new System.Drawing.Point(529, 224);
            this.BtPublickey.Margin = new System.Windows.Forms.Padding(2);
            this.BtPublickey.Name = "BtPublickey";
            this.BtPublickey.Size = new System.Drawing.Size(140, 57);
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
            this.Lb1.Location = new System.Drawing.Point(11, 9);
            this.Lb1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lb1.Name = "Lb1";
            this.Lb1.Size = new System.Drawing.Size(151, 22);
            this.Lb1.TabIndex = 29;
            this.Lb1.Text = "Message received";
            // 
            // Lb2
            // 
            this.Lb2.AutoSize = true;
            this.Lb2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb2.Location = new System.Drawing.Point(11, 284);
            this.Lb2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lb2.Name = "Lb2";
            this.Lb2.Size = new System.Drawing.Size(122, 22);
            this.Lb2.TabIndex = 30;
            this.Lb2.Text = "Message Send";
            // 
            // btDecrypt
            // 
            this.btDecrypt.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDecrypt.Location = new System.Drawing.Point(529, 309);
            this.btDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(140, 44);
            this.btDecrypt.TabIndex = 31;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Visible = false;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // txtboxshow
            // 
            this.txtboxshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxshow.Location = new System.Drawing.Point(15, 34);
            this.txtboxshow.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxshow.Multiline = true;
            this.txtboxshow.Name = "txtboxshow";
            this.txtboxshow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxshow.Size = new System.Drawing.Size(509, 248);
            this.txtboxshow.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 419);
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
            this.Name = "Form1";
            this.Text = "Clientthang";
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


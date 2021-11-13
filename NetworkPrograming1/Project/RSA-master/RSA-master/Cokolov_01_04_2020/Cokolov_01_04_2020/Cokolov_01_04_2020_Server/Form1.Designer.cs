namespace Serverthang
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSendRequest = new System.Windows.Forms.Button();
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.Lb1 = new System.Windows.Forms.Label();
            this.Lb2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublickey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtPublickey = new System.Windows.Forms.Button();
            this.txtshow = new System.Windows.Forms.TextBox();
            this.BtClear = new System.Windows.Forms.Button();
            this.txtPrivatekey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(9, 418);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(545, 125);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // buttonSendRequest
            // 
            this.buttonSendRequest.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSendRequest.Location = new System.Drawing.Point(571, 490);
            this.buttonSendRequest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSendRequest.Name = "buttonSendRequest";
            this.buttonSendRequest.Size = new System.Drawing.Size(187, 55);
            this.buttonSendRequest.TabIndex = 8;
            this.buttonSendRequest.Text = "Send";
            this.buttonSendRequest.UseVisualStyleBackColor = true;
            this.buttonSendRequest.Click += new System.EventHandler(this.ButtonSendRequest_Click);
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopServer.Location = new System.Drawing.Point(568, 100);
            this.buttonStopServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(187, 57);
            this.buttonStopServer.TabIndex = 7;
            this.buttonStopServer.Text = "Stop Server";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.ButtonStopServer_Click);
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartServer.Location = new System.Drawing.Point(568, 28);
            this.buttonStartServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(187, 55);
            this.buttonStartServer.TabIndex = 6;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.ButtonStartServer_Click);
            // 
            // Lb1
            // 
            this.Lb1.AutoSize = true;
            this.Lb1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb1.Location = new System.Drawing.Point(12, -2);
            this.Lb1.Name = "Lb1";
            this.Lb1.Size = new System.Drawing.Size(194, 28);
            this.Lb1.TabIndex = 11;
            this.Lb1.Text = "Message received";
            // 
            // Lb2
            // 
            this.Lb2.AutoSize = true;
            this.Lb2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb2.Location = new System.Drawing.Point(4, 386);
            this.Lb2.Name = "Lb2";
            this.Lb2.Size = new System.Drawing.Size(155, 28);
            this.Lb2.TabIndex = 12;
            this.Lb2.Text = "Message Send";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RSA",
            "MD5",
            "SHA1",
            "Caesar"});
            this.comboBox1.Location = new System.Drawing.Point(568, 207);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 37);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(568, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Method";
            // 
            // txtPublickey
            // 
            this.txtPublickey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublickey.Location = new System.Drawing.Point(771, 58);
            this.txtPublickey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPublickey.Multiline = true;
            this.txtPublickey.Name = "txtPublickey";
            this.txtPublickey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPublickey.Size = new System.Drawing.Size(611, 227);
            this.txtPublickey.TabIndex = 17;
            this.txtPublickey.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(765, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "Publickey";
            this.label1.Visible = false;
            // 
            // BtPublickey
            // 
            this.BtPublickey.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtPublickey.Location = new System.Drawing.Point(568, 311);
            this.BtPublickey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtPublickey.Name = "BtPublickey";
            this.BtPublickey.Size = new System.Drawing.Size(187, 66);
            this.BtPublickey.TabIndex = 19;
            this.BtPublickey.Text = "Generate and SendKey";
            this.BtPublickey.UseVisualStyleBackColor = true;
            this.BtPublickey.Visible = false;
            this.BtPublickey.Click += new System.EventHandler(this.BtPublickey_Click);
            // 
            // txtshow
            // 
            this.txtshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtshow.Location = new System.Drawing.Point(9, 28);
            this.txtshow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtshow.Multiline = true;
            this.txtshow.Name = "txtshow";
            this.txtshow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtshow.Size = new System.Drawing.Size(545, 349);
            this.txtshow.TabIndex = 20;
            // 
            // BtClear
            // 
            this.BtClear.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtClear.Location = new System.Drawing.Point(568, 253);
            this.BtClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtClear.Name = "BtClear";
            this.BtClear.Size = new System.Drawing.Size(187, 46);
            this.BtClear.TabIndex = 21;
            this.BtClear.Text = "Clear";
            this.BtClear.UseVisualStyleBackColor = true;
            this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
            // 
            // txtPrivatekey
            // 
            this.txtPrivatekey.Location = new System.Drawing.Point(771, 318);
            this.txtPrivatekey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrivatekey.Multiline = true;
            this.txtPrivatekey.Name = "txtPrivatekey";
            this.txtPrivatekey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrivatekey.Size = new System.Drawing.Size(611, 227);
            this.txtPrivatekey.TabIndex = 22;
            this.txtPrivatekey.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(765, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 28);
            this.label3.TabIndex = 23;
            this.label3.Text = "PrivateKey";
            this.label3.Visible = false;
            // 
            // btDecrypt
            // 
            this.btDecrypt.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDecrypt.Location = new System.Drawing.Point(571, 418);
            this.btDecrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(187, 54);
            this.btDecrypt.TabIndex = 28;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Visible = false;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonSendRequest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 555);
            this.Controls.Add(this.btDecrypt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrivatekey);
            this.Controls.Add(this.BtClear);
            this.Controls.Add(this.txtshow);
            this.Controls.Add(this.BtPublickey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPublickey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Lb2);
            this.Controls.Add(this.Lb1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSendRequest);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.buttonStartServer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = " Serverthang";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSendRequest;
        private System.Windows.Forms.Button buttonStopServer;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Label Lb1;
        private System.Windows.Forms.Label Lb2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPublickey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtPublickey;
        private System.Windows.Forms.TextBox txtshow;
        private System.Windows.Forms.Button BtClear;
        private System.Windows.Forms.TextBox txtPrivatekey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btDecrypt;
    }
}


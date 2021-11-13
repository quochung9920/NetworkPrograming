namespace Client_Sever
{
    partial class Server
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
            this.bntSend = new System.Windows.Forms.Button();
            this.txtMessaga = new System.Windows.Forms.TextBox();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // bntSend
            // 
            this.bntSend.Location = new System.Drawing.Point(452, 333);
            this.bntSend.Name = "bntSend";
            this.bntSend.Size = new System.Drawing.Size(101, 54);
            this.bntSend.TabIndex = 5;
            this.bntSend.Text = "Send";
            this.bntSend.UseVisualStyleBackColor = true;
            this.bntSend.Click += new System.EventHandler(this.bntSend_Click);
            // 
            // txtMessaga
            // 
            this.txtMessaga.Location = new System.Drawing.Point(3, 333);
            this.txtMessaga.Multiline = true;
            this.txtMessaga.Name = "txtMessaga";
            this.txtMessaga.Size = new System.Drawing.Size(434, 54);
            this.txtMessaga.TabIndex = 4;
            // 
            // lsvMessage
            // 
            this.lsvMessage.Location = new System.Drawing.Point(3, 3);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(557, 297);
            this.lsvMessage.TabIndex = 3;
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.List;
            // 
            // Server
            // 
            this.AcceptButton = this.bntSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 392);
            this.Controls.Add(this.bntSend);
            this.Controls.Add(this.txtMessaga);
            this.Controls.Add(this.lsvMessage);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntSend;
        private System.Windows.Forms.TextBox txtMessaga;
        private System.Windows.Forms.ListView lsvMessage;
    }
}


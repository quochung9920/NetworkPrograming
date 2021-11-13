
namespace _9._7TCPChat
{
    partial class TcpChat
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
            this.label1 = new System.Windows.Forms.Label();
            this.newText = new System.Windows.Forms.TextBox();
            this.results = new System.Windows.Forms.ListView();
            this.btnListen = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter text String";
            // 
            // newText
            // 
            this.newText.Location = new System.Drawing.Point(51, 56);
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(319, 22);
            this.newText.TabIndex = 1;
            // 
            // results
            // 
            this.results.HideSelection = false;
            this.results.Location = new System.Drawing.Point(36, 135);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(742, 295);
            this.results.TabIndex = 2;
            this.results.UseCompatibleStateImageBehavior = false;
            this.results.View = System.Windows.Forms.View.List;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(460, 9);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(112, 30);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.ButtonListen_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(465, 74);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(119, 36);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(654, 54);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(102, 40);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // TcpChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.results);
            this.Controls.Add(this.newText);
            this.Controls.Add(this.label1);
            this.Name = "TcpChat";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newText;
        private System.Windows.Forms.ListView results;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
    }
}


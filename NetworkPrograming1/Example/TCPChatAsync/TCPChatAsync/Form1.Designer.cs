
namespace AcSyncTcpSrv
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.conStatus = new System.Windows.Forms.TextBox();
            this.newText = new System.Windows.Forms.TextBox();
            this.bthSend = new System.Windows.Forms.Button();
            this.bthStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text receive from Client";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Stop Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // results
            // 
            this.results.HideSelection = false;
            this.results.Location = new System.Drawing.Point(26, 77);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(723, 273);
            this.results.TabIndex = 2;
            this.results.UseCompatibleStateImageBehavior = false;
            this.results.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connect status";
            // 
            // conStatus
            // 
            this.conStatus.Location = new System.Drawing.Point(155, 377);
            this.conStatus.Name = "conStatus";
            this.conStatus.Size = new System.Drawing.Size(594, 22);
            this.conStatus.TabIndex = 4;
            // 
            // newText
            // 
            this.newText.Location = new System.Drawing.Point(234, 31);
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(181, 22);
            this.newText.TabIndex = 5;
            // 
            // bthSend
            // 
            this.bthSend.Location = new System.Drawing.Point(458, 16);
            this.bthSend.Name = "bthSend";
            this.bthSend.Size = new System.Drawing.Size(69, 38);
            this.bthSend.TabIndex = 6;
            this.bthSend.Text = "Send";
            this.bthSend.UseVisualStyleBackColor = true;
            this.bthSend.Click += new System.EventHandler(this.bthSend_Click);
            // 
            // bthStart
            // 
            this.bthStart.Location = new System.Drawing.Point(773, 17);
            this.bthStart.Name = "bthStart";
            this.bthStart.Size = new System.Drawing.Size(144, 38);
            this.bthStart.TabIndex = 7;
            this.bthStart.Text = "Start Server";
            this.bthStart.UseVisualStyleBackColor = true;
            this.bthStart.Click += new System.EventHandler(this.bthStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 450);
            this.Controls.Add(this.bthStart);
            this.Controls.Add(this.bthSend);
            this.Controls.Add(this.newText);
            this.Controls.Add(this.conStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.results);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView results;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox conStatus;
        private System.Windows.Forms.TextBox newText;
        private System.Windows.Forms.Button bthSend;
        private System.Windows.Forms.Button bthStart;
    }
}


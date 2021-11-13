
namespace BTH1_C5
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
            this.btnStop = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.conStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text receice from Client:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(551, 26);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(169, 36);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop Server";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // results
            // 
            this.results.HideSelection = false;
            this.results.Location = new System.Drawing.Point(39, 75);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(681, 265);
            this.results.TabIndex = 2;
            this.results.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection Status:";
            // 
            // conStatus
            // 
            this.conStatus.Location = new System.Drawing.Point(178, 378);
            this.conStatus.Name = "conStatus";
            this.conStatus.Size = new System.Drawing.Size(518, 22);
            this.conStatus.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.conStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.results);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListView results;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox conStatus;
    }
}


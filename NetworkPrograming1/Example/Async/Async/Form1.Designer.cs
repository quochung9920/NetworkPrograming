
using System;

namespace Async
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
            this.address = new System.Windows.Forms.TextBox();
            this.btnResolve = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(88, 42);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(304, 22);
            this.address.TabIndex = 0;
            // 
            // btnResolve
            // 
            this.btnResolve.Location = new System.Drawing.Point(504, 41);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(164, 48);
            this.btnResolve.TabIndex = 2;
            this.btnResolve.Text = "Resolve";
            this.btnResolve.UseVisualStyleBackColor = true;
            // 
            // results
            // 
            this.results.FormattingEnabled = true;
            this.results.ItemHeight = 16;
            this.results.Location = new System.Drawing.Point(98, 263);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(293, 132);
            this.results.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.results);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.address);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load());
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private EventHandler Form1_Load()
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.ListBox results;
    }
}


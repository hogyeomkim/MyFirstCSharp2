﻿namespace MyFirstCSharp
{
    partial class Chap17_Array2
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
            this.btnMatrix = new System.Windows.Forms.Button();
            this.txtMatrix = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnMatrix
            // 
            this.btnMatrix.Location = new System.Drawing.Point(48, 18);
            this.btnMatrix.Margin = new System.Windows.Forms.Padding(2);
            this.btnMatrix.Name = "btnMatrix";
            this.btnMatrix.Size = new System.Drawing.Size(443, 50);
            this.btnMatrix.TabIndex = 0;
            this.btnMatrix.Text = "2차원 배열";
            this.btnMatrix.UseVisualStyleBackColor = true;
            this.btnMatrix.Click += new System.EventHandler(this.btnMatrix_Click);
            // 
            // txtMatrix
            // 
            this.txtMatrix.Location = new System.Drawing.Point(48, 72);
            this.txtMatrix.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatrix.Multiline = true;
            this.txtMatrix.Name = "txtMatrix";
            this.txtMatrix.Size = new System.Drawing.Size(444, 171);
            this.txtMatrix.TabIndex = 1;
            // 
            // Chap17_Array2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 249);
            this.Controls.Add(this.txtMatrix);
            this.Controls.Add(this.btnMatrix);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Chap17_Array2";
            this.Text = "2차원 배열";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMatrix;
        private System.Windows.Forms.TextBox txtMatrix;
    }
}
﻿namespace BitboardGui
{
    partial class MainForm
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
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.ShowBitboardButton = new System.Windows.Forms.Button();
            this.Bitboard0Label = new System.Windows.Forms.Label();
            this.Bitboard0TextBox = new System.Windows.Forms.TextBox();
            this.BoardSizeLabel = new System.Windows.Forms.Label();
            this.BoardSizeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPictureBox.Location = new System.Drawing.Point(0, 1);
            this.MainPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(593, 593);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.SizeChanged += new System.EventHandler(this.MainPictureBox_SizeChanged);
            this.MainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseUp);
            // 
            // ShowBitboardButton
            // 
            this.ShowBitboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowBitboardButton.Location = new System.Drawing.Point(616, 552);
            this.ShowBitboardButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ShowBitboardButton.Name = "ShowBitboardButton";
            this.ShowBitboardButton.Size = new System.Drawing.Size(275, 27);
            this.ShowBitboardButton.TabIndex = 3;
            this.ShowBitboardButton.Text = "Show";
            this.ShowBitboardButton.UseVisualStyleBackColor = true;
            this.ShowBitboardButton.Click += new System.EventHandler(this.ShowBitboardButton_Click);
            // 
            // Bitboard0Label
            // 
            this.Bitboard0Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bitboard0Label.AutoSize = true;
            this.Bitboard0Label.Location = new System.Drawing.Point(612, 60);
            this.Bitboard0Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Bitboard0Label.Name = "Bitboard0Label";
            this.Bitboard0Label.Size = new System.Drawing.Size(64, 15);
            this.Bitboard0Label.TabIndex = 23;
            this.Bitboard0Label.Text = "Bitboard 0:";
            // 
            // Bitboard0TextBox
            // 
            this.Bitboard0TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bitboard0TextBox.Location = new System.Drawing.Point(687, 57);
            this.Bitboard0TextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Bitboard0TextBox.Name = "Bitboard0TextBox";
            this.Bitboard0TextBox.Size = new System.Drawing.Size(204, 23);
            this.Bitboard0TextBox.TabIndex = 22;
            this.Bitboard0TextBox.Text = "0";
            // 
            // BoardSizeLabel
            // 
            this.BoardSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BoardSizeLabel.AutoSize = true;
            this.BoardSizeLabel.Location = new System.Drawing.Point(612, 9);
            this.BoardSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BoardSizeLabel.Name = "BoardSizeLabel";
            this.BoardSizeLabel.Size = new System.Drawing.Size(63, 15);
            this.BoardSizeLabel.TabIndex = 24;
            this.BoardSizeLabel.Text = "Board size:";
            // 
            // BoardSizeTextBox
            // 
            this.BoardSizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BoardSizeTextBox.Enabled = false;
            this.BoardSizeTextBox.Location = new System.Drawing.Point(687, 6);
            this.BoardSizeTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BoardSizeTextBox.Name = "BoardSizeTextBox";
            this.BoardSizeTextBox.Size = new System.Drawing.Size(50, 23);
            this.BoardSizeTextBox.TabIndex = 25;
            this.BoardSizeTextBox.Text = "8";
            // 
            // MainForm
            // 
            this.AcceptButton = this.ShowBitboardButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 593);
            this.Controls.Add(this.BoardSizeTextBox);
            this.Controls.Add(this.BoardSizeLabel);
            this.Controls.Add(this.Bitboard0Label);
            this.Controls.Add(this.Bitboard0TextBox);
            this.Controls.Add(this.ShowBitboardButton);
            this.Controls.Add(this.MainPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Bitboard viewer";
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Button ShowBitboardButton;
        private System.Windows.Forms.Label Bitboard0Label;
        private System.Windows.Forms.TextBox Bitboard0TextBox;
        private System.Windows.Forms.Label BoardSizeLabel;
        private System.Windows.Forms.TextBox BoardSizeTextBox;
    }
}


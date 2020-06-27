namespace B20_Ex05
{
    partial class MemoryGame
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
            this.lblCurrnetPlayer = new System.Windows.Forms.Label();
            this.lblFirstPlayer = new System.Windows.Forms.Label();
            this.lblSecondPlayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrnetPlayer
            // 
            this.lblCurrnetPlayer.AutoSize = true;
            this.lblCurrnetPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCurrnetPlayer.Location = new System.Drawing.Point(15, 459);
            this.lblCurrnetPlayer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrnetPlayer.Name = "lblCurrnetPlayer";
            this.lblCurrnetPlayer.Size = new System.Drawing.Size(139, 24);
            this.lblCurrnetPlayer.TabIndex = 0;
            this.lblCurrnetPlayer.Text = "Current Player :";
            // 
            // lblFirstPlayer
            // 
            this.lblFirstPlayer.AutoSize = true;
            this.lblFirstPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFirstPlayer.Location = new System.Drawing.Point(15, 495);
            this.lblFirstPlayer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFirstPlayer.Name = "lblFirstPlayer";
            this.lblFirstPlayer.Size = new System.Drawing.Size(60, 24);
            this.lblFirstPlayer.TabIndex = 1;
            this.lblFirstPlayer.Text = "label2";
            // 
            // lblSecondPlayer
            // 
            this.lblSecondPlayer.AutoSize = true;
            this.lblSecondPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSecondPlayer.Location = new System.Drawing.Point(15, 531);
            this.lblSecondPlayer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSecondPlayer.Name = "lblSecondPlayer";
            this.lblSecondPlayer.Size = new System.Drawing.Size(60, 24);
            this.lblSecondPlayer.TabIndex = 2;
            this.lblSecondPlayer.Text = "label3";
            // 
            // MemoryGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 704);
            this.Controls.Add(this.lblSecondPlayer);
            this.Controls.Add(this.lblFirstPlayer);
            this.Controls.Add(this.lblCurrnetPlayer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MemoryGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemoryGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrnetPlayer;
        private System.Windows.Forms.Label lblFirstPlayer;
        private System.Windows.Forms.Label lblSecondPlayer;
    }
}
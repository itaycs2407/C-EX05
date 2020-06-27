namespace B20_Ex05
{
    partial class MemoryGameSettings
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.ButtonPlayerChooser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonBoardSize = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Player Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Second Player Name :";
            // 
            // textBoxFirstPlayerName
            // 
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(215, 20);
            this.textBoxFirstPlayerName.Name = "textBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(165, 20);
            this.textBoxFirstPlayerName.TabIndex = 3;
            // 
            // textBoxSecondPlayerName
            // 
            this.textBoxSecondPlayerName.Enabled = false;
            this.textBoxSecondPlayerName.Location = new System.Drawing.Point(215, 55);
            this.textBoxSecondPlayerName.Name = "textBoxSecondPlayerName";
            this.textBoxSecondPlayerName.Size = new System.Drawing.Size(165, 20);
            this.textBoxSecondPlayerName.TabIndex = 4;
            this.textBoxSecondPlayerName.Text = "-Computer-";
            // 
            // ButtonPlayerChooser
            // 
            this.ButtonPlayerChooser.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonPlayerChooser.ForeColor = System.Drawing.Color.Black;
            this.ButtonPlayerChooser.Location = new System.Drawing.Point(421, 55);
            this.ButtonPlayerChooser.Name = "ButtonPlayerChooser";
            this.ButtonPlayerChooser.Size = new System.Drawing.Size(118, 23);
            this.ButtonPlayerChooser.TabIndex = 5;
            this.ButtonPlayerChooser.Text = "Against a Friend";
            this.ButtonPlayerChooser.UseVisualStyleBackColor = true;
            this.ButtonPlayerChooser.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Board Size :";
            // 
            // ButtonBoardSize
            // 
            this.ButtonBoardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ButtonBoardSize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ButtonBoardSize.Location = new System.Drawing.Point(19, 156);
            this.ButtonBoardSize.Name = "ButtonBoardSize";
            this.ButtonBoardSize.Size = new System.Drawing.Size(181, 115);
            this.ButtonBoardSize.TabIndex = 7;
            this.ButtonBoardSize.Text = "4 X 4";
            this.ButtonBoardSize.UseVisualStyleBackColor = false;
            this.ButtonBoardSize.Click += new System.EventHandler(this.ButtonBoardSize_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(464, 248);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 8;
            this.ButtonStart.Text = "Start !";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // MemoryGameSettings
            // 
            this.AcceptButton = this.ButtonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 286);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.ButtonBoardSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonPlayerChooser);
            this.Controls.Add(this.textBoxSecondPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemoryGameSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFirstPlayerName;
        private System.Windows.Forms.TextBox textBoxSecondPlayerName;
        private System.Windows.Forms.Button ButtonPlayerChooser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonBoardSize;
        private System.Windows.Forms.Button ButtonStart;
    }
}
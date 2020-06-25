using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B20_Ex05
{
    public partial class MemoryGame : Form
    {
        public MemoryGame()
        {
            InitializeComponent();
        }


        public void ShuffleButtons()
        {
            Button currentButton = new Button();
            int rows, cols; 
            int startingTop = 19, startingLeft = 12, height = 75, width = 75;
            for (rows = 0; rows < GameController.rows; rows++)
            {
                for (cols = 0; cols < GameController.cols; cols++)
                {
                    currentButton = new Button(); 
                    currentButton.Top = startingTop + rows *(startingTop + height);
                    currentButton.Left = startingLeft + cols * (startingLeft + width);
                    currentButton.Width = width;
                    currentButton.Height = height;
                    currentButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
                    currentButton.ForeColor = System.Drawing.Color.Black;
                    currentButton.UseVisualStyleBackColor = true;
                    this.Controls.Add(currentButton);
                }
                this.Width = startingLeft + cols * (startingLeft + width) + 20;
            }

            label1.Top = startingTop + rows * (startingTop + height) + 20;
            label2.Top = label1.Top + label1.Height + 20;
            label3.Top = label2.Top + label2.Height + 20;
            this.Height = label2.Top + label2.Height + 120;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Button currentButton = (sender as Button);
            //Color col = currentButton.BackColor;
            //currentButton.BackColor = Color.FromArgb(80, col.R, col.G, col.B);
            //System.Threading.Thread.Sleep(250);
            //currentButton.BackColor = Color.FromArgb(20, col.R, col.G, col.B);
            fadeOutAndIn(sender);
        }

        private void fadeOutAndIn(object sender)
        {
            int i;
            if ((sender as Button).Text != string.Empty)
            {
                Button currentButton = (sender as Button);
                for (i = 10; i > 0; i--)
                {
                    Color col = currentButton.BackColor;
                    currentButton.BackColor = Color.FromArgb(i*10, col.R, col.G, col.B);
                    System.Threading.Thread.Sleep(250);
                }
                currentButton.Text = "Faded";
                for (i =0; i <10 ; i++)
                {
                    Color col = currentButton.BackColor;
                    currentButton.BackColor = Color.FromArgb(i * 10, col.R, col.G, col.B);
                    System.Threading.Thread.Sleep(750);
                }
            }
        }
    }
}

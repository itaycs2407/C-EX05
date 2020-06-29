using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B20_Ex05
{
    public partial class MemoryGameSettings : Form
    {
        private bool m_ComputerPlayer = !true;
        private string[] m_BoardSize = new string[]{"4 X 4","4 X 5","4 X 6","5 X 4","5 X 6","6 X 4","6 X 5","6 X 6"};
        private int i=1;
        private IGameControll m_GameControl;

        public MemoryGameSettings()
        {
            InitializeComponent();
        }

        internal IGameControll GameControl { get => m_GameControl; set => m_GameControl = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSecondPlayerName.Text = m_ComputerPlayer ? "-Computer-" : String.Empty;
            textBoxSecondPlayerName.Enabled = !m_ComputerPlayer;
            ButtonPlayerChooser.Text = m_ComputerPlayer ? "Againg a Friend" : "Against Computer";
            m_ComputerPlayer = !m_ComputerPlayer;
        }

        private void ButtonBoardSize_Click(object sender, EventArgs e)
        {
            ButtonBoardSize.Text = m_BoardSize[i++ % 8];
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            GameControl.SetFirstPlayerName(textBoxFirstPlayerName.Text.ToString());
            //GameController.m_FirstPlayerName = textBoxFirstPlayerName.Text;
            GameControl.SetSecondPlayerName(textBoxSecondPlayerName.Text.ToString());
            //GameController.m_SecondPlayerName = textBoxSecondPlayerName.Text;
            if (textBoxSecondPlayerName.Text == "-Computer-")
            {
                GameControl.SetSecondPlayerName(string.Empty);
               // GameController.m_SecondPlayerName = string.Empty;
            }
            GameControl.SetGridSize(ButtonBoardSize.Text.ToString());
            //GameController.m_GridSize = ButtonBoardSize.Text;
            this.Close();
        }

       



    }
}

using B20_Ex02_1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B20_Ex05
{
    public partial class MemoryGame : Form
    {
        private List<Button> m_GameButttons = new List<Button>();
        public bool m_GoodPick = false;
        public IGameControll m_GameControl;

        public List<Button> GameButttons { get => m_GameButttons; set => m_GameButttons = value; }

        public MemoryGame(Player playerOne, Player playertwo)
        {
            InitializeComponent();
            updatePlayersAttOnUI(playerOne, playertwo);
        }

        private void updatePlayersAttOnUI(Player playerOne, Player playertwo)
        {
            lblCurrnetPlayer.Text = "Current Player: " + playerOne.Name;
            lblFirstPlayer.Text = string.Format(@"{0} : 0 Pairs.", playerOne.Name);
            lblCurrnetPlayer.BackColor = lblFirstPlayer.BackColor = Color.LightGreen;
            lblSecondPlayer.Text = string.Format(@"{0} : 0 Pairs.", playertwo.Name);
            lblSecondPlayer.BackColor = Color.LightBlue;
        }

        public void UpdateLblCurrentPlayer(string i_PlayerName, Color i_BackColor)
        {
            lblCurrnetPlayer.Text = "Current Player: " + i_PlayerName;
            lblCurrnetPlayer.BackColor = i_BackColor;
        }

        public void updateLblFirstPlayer(Player i_Player)
        {
            updateLbl(lblFirstPlayer, i_Player);
        }
        public void updateLblSecondPlayer(Player i_Player)
        {
            updateLbl(lblSecondPlayer, i_Player);
        }

        private void updateLbl(Label i_LabelToChange, Player i_Player)
        {
            string pairSTR = i_Player.NumOfHits == 1 ? "Pair." : "Pairs.";
            i_LabelToChange.Text = string.Format(@"{0} : {1} {2}", i_Player.Name, i_Player.NumOfHits , pairSTR);
            i_LabelToChange.BackColor = i_Player.Color;
        }

        public void ShuffleButtons()
        {
            Button currentButton;
            int rows, cols; 
            const int startingTop = 19, startingLeft = 12, height = 80, width = 80;
            for (rows = 0; rows < m_GameControl.GetRows(); rows++)
            {
                for (cols = 0; cols < m_GameControl.GetCols(); cols++)
                {
                    currentButton = new Button(); 
                    currentButton.Top = startingTop + rows *(startingTop + height);
                    currentButton.Left = startingLeft + cols * (startingLeft + width);
                    currentButton.Width = width;
                    currentButton.Height = height;
                    currentButton.Click += CurrentButton_Click;
                    currentButton.TabIndex = rows * m_GameControl.GetRows() + cols;
                    currentButton.FlatStyle = FlatStyle.Flat;
                    currentButton.FlatAppearance.BorderSize = 1;
                    currentButton.ForeColor = System.Drawing.Color.Black;
                    currentButton.UseVisualStyleBackColor = true;
                    GameButttons.Add(currentButton);
                    this.Controls.Add(currentButton);
                }
                this.Width = startingLeft + cols * (startingLeft + width) + 20;
            }

            // set the form bound to fit the button and labels display
            lblCurrnetPlayer.Top = startingTop + rows * (startingTop + height) + 20;
            lblFirstPlayer.Top = lblCurrnetPlayer.Top + lblCurrnetPlayer.Height + 20;
            lblSecondPlayer.Top = lblFirstPlayer.Top + lblFirstPlayer.Height + 20;
            this.Height = lblFirstPlayer.Top + lblFirstPlayer.Height + 120;
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            

            // check if the button wasnt press before
            bool isTheButtonVisable = m_GameControl.GetVisavilityOfCell(sender as Button);
            if (!isTheButtonVisable)
            {
                workOnCard(pressedButton);
            }
            m_GameControl.UpdateContent();
            checkIfGameEnded();
            tryPlayComputerTurn();
            checkIfGameEnded();
        }

        private void workOnCard(Button i_button)
        {
            m_GameControl.TryFlipCard(i_button);
            m_GameControl.UpdateContent();
            System.Threading.Thread.Sleep(500);
            m_GameControl.MakeMove(i_button);
        }

        private void tryPlayComputerTurn()
        {
            while (m_GameControl.IsCurrentActiePlayerComputer())
            {
                m_GameControl.MakeMove();
                m_GameControl.UpdateContent();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void checkIfGameEnded()
        {
           if (!m_GameControl.IsGameOn())
            {
                m_GameControl.EndGameMsg();
            }
        }

    }
    }

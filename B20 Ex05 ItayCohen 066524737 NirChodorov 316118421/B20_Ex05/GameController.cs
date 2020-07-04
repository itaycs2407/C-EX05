using B20_Ex02_1;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace B20_Ex05
{
    class GameController : IGameControll
    {
        private MemoryGameSettings m_MemoryGameSetting;
        private MemoryGame m_MemoryGame;
        private Logic m_GameLogic = new Logic();
        public string m_FirstPlayerName;
        public string m_SecondPlayerName;
        public string m_GridSize;
        public int rows , cols;
        bool numberOfPick = true;
        Button firstPick;

        public GameController()
        {
            m_MemoryGameSetting = new MemoryGameSettings();
            m_MemoryGameSetting.GameControl = this;
        }
        public void Run()
        {
            m_MemoryGameSetting.ShowDialog();
            initializePlayers();
            m_MemoryGame = new MemoryGame(m_GameLogic.Players[0], m_GameLogic.Players[1]);
            m_MemoryGame.m_GameControl = this;
            initializeGrid();
            m_MemoryGame.ShuffleButtons();
            m_MemoryGame.ShowDialog();
        }

     
       

        private void makeComputerMove(Player currentActivePlayer)
        {
            int[] computerGuess = m_GameLogic.MakeComputerMove();
            if (m_GameLogic.TryUpdateForEquality(computerGuess[0], computerGuess[1], computerGuess[2], computerGuess[3]))
            {
                currentActivePlayer.NumOfHits++;
                // change buttons border color to the color of the active player
                setButtonBorderColorAfterHit(computerGuess[0], computerGuess[1], currentActivePlayer);
                setButtonBorderColorAfterHit(computerGuess[2], computerGuess[3], currentActivePlayer);
            }
            else
            {
                // wait for one second
                System.Threading.Thread.Sleep(1000);
            }
           
        }

        private void makeHumanMove(Button i_ButtonPressed, Player currentActivePlayer)
        {
            // get buttonPressed cords
            int buttonPressedRow = getRowCordForButton(i_ButtonPressed);
            int buttonPressedCol = getColCordForButton(i_ButtonPressed);

            //i_ButtonPressed.Text = GetCellContent(buttonPressedRow, buttonPressedCol).ToString();
            // try flip card
            if (numberOfPick)
            {
                if (m_GameLogic.TryFlipCard(buttonPressedRow, buttonPressedCol))
                {
                    firstPick = i_ButtonPressed;
                    m_MemoryGame.m_GoodPick = true;
                    numberOfPick = !numberOfPick;
                }
            }
            else
            {
                if (m_GameLogic.TryFlipCard(buttonPressedRow, buttonPressedCol))
                {
                    if (m_GameLogic.TryUpdateForEquality(getRowCordForButton(firstPick), getColCordForButton(firstPick), buttonPressedRow, buttonPressedCol))
                    {
                        // change buttons border color to the color of the active player
                        setButtonBorderColorAfterHit(firstPick, currentActivePlayer);
                        setButtonBorderColorAfterHit(i_ButtonPressed, currentActivePlayer);
                    }
                    else
                    {
                       // m_GameLogic.TryFlipCard(getRowCordForButton(firstPick), getColCordForButton(firstPick));
                       // m_GameLogic.TryFlipCard(buttonPressedRow, buttonPressedCol);
                        m_MemoryGame.m_GoodPick = !true;
                    }
                numberOfPick = !numberOfPick;
                }
            }
        }
        void IGameControll.VisableOff(Button i_PressedButton)
        {
            int buttonPressedRow = getRowCordForButton(i_PressedButton);
            int buttonPressedCol = getColCordForButton(i_PressedButton);
            m_GameLogic.setCellVisiballity(getRowCordForButton(firstPick), getColCordForButton(firstPick),!true);
            m_GameLogic.setCellVisiballity(buttonPressedRow, buttonPressedCol, !true) ;
           // i_PressedButton.Text = string.Empty;
        }
        private void  setButtonBorderColorAfterHit(int i_Row, int i_Col, Player currentActivePlayer)
        {
            int buttonTabIndex = i_Row * rows + i_Col;
            m_MemoryGame.GameButttons.ForEach(btn =>
            {
                if (btn.TabIndex == buttonTabIndex)
                {
                    btn.FlatAppearance.BorderColor = currentActivePlayer.Color;
                }
            });
        }

        private void setButtonBorderColorAfterHit(Button i_Button, Player i_CurrentActivePlayer)
        {
            i_Button.FlatAppearance.BorderColor = i_CurrentActivePlayer.Color;
            i_Button.FlatAppearance.BorderSize = 3;
        }

        public void UpdateContent()
        {
            // update button
            m_MemoryGame.GameButttons.ForEach(btn =>
            {
                if (m_GameLogic.IsCellVisable(getRowCordForButton(btn), getColCordForButton(btn)))
                {
                    btn.Text = GetCellContent(getRowCordForButton(btn), getColCordForButton(btn)).ToString();
                }
                else
                {
                    btn.Text = string.Empty;
                }
            });

            // update labels
            m_MemoryGame.updateLblFirstPlayer(m_GameLogic.Players[0]);
            m_MemoryGame.updateLblSecondPlayer(m_GameLogic.Players[1]);
        }

        private void EndGame()
        {
            // close the game form
            m_MemoryGame.Close();
            // get details for the winner and looser.
            Player winner = m_GameLogic.GetWinner();
            Player looser = m_GameLogic.GetLoser();
            string announceTheScoreMSG = string.Format(@"{0}, you are the winner with {1} points!!.{2}{3}, you are the looser with {4} points.", winner.Name, winner.NumOfHits, Environment.NewLine, looser.Name, looser.NumOfHits);
            string endOfTheGameMSG = string.Format(@"Press Yes to play new game, or No to Exit");
            // put message dialog with the detail.
            MessageBox.Show(announceTheScoreMSG, "Scores !!!", MessageBoxButtons.OK);
            // put exit dialog
            if (MessageBox.Show(endOfTheGameMSG, "GoodBye ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               Run();
            }
            //TODO : logic for the new game ? yes or no
            
        }

        private int getRowCordForButton(Button i_Button)
        {
            return (i_Button.TabIndex / rows);
        }

        private int getColCordForButton(Button i_Button)
        {
            return (i_Button.TabIndex % cols);
        }

        private void initializePlayers()
        {
            m_GameLogic.AddNewPlayer(new Player(0, m_FirstPlayerName, true, Color.LightGreen));
            if (m_SecondPlayerName == string.Empty)
            {
                m_GameLogic.AddNewPlayer(new Player(1, "Computer", !true, Color.LightBlue));
            }
            else
            {
                m_GameLogic.AddNewPlayer(new Player(1, m_SecondPlayerName, true, Color.LightBlue));
            }
        }


        private void initializeGrid()
        {
            rows = m_GridSize[0]-48;
            cols = m_GridSize[4]-48;
            m_GameLogic.TryCreateGrid(rows, cols);
        }

        public char GetCellContent(int i_Row, int i_Col)
        {
            return m_GameLogic.GetCellContent(i_Row, i_Col);
        }

         void IGameControll.MakeMove(Button i_ButtonPressed)
        {
                Player currentActivePlayer = m_GameLogic.GetActivePlayer();
                if (currentActivePlayer.IsHuman)
                {
                    makeHumanMove(i_ButtonPressed, currentActivePlayer);
                }
                else
                {
                    makeHumanMove(i_ButtonPressed, currentActivePlayer);
                    //makeComputerMove(currentActivePlayer);
                }
                // check for current active player and update the UI.
                currentActivePlayer = m_GameLogic.GetActivePlayer();
                m_MemoryGame.UpdateLblCurrentPlayer(currentActivePlayer.Name, currentActivePlayer.Color);
           
            
        }
         void IGameControll.SetGridSize(string i_SizeSTR)
        {
            m_GridSize = i_SizeSTR;
        }
  
        void IGameControll.SetSecondPlayerName(string i_Name)
        {
            m_SecondPlayerName = i_Name;
        }

         void IGameControll.SetFirstPlayerName(string i_Name)
        {
            m_FirstPlayerName = i_Name;
        }
         int IGameControll.GetRows()
        {
            return rows;
        }
         int IGameControll.GetCols()
        {
            return cols;
        }

        public bool GetVisavilityOfCell(Button i_PressedButton)
        {
            int buttonPressedRow = getRowCordForButton(i_PressedButton);
            int buttonPressedCol = getColCordForButton(i_PressedButton);
            return m_GameLogic.IsCellVisable(buttonPressedRow, buttonPressedCol);
        }

        public bool IsGameOn()
        {
            return m_GameLogic.IsGameOn();
        }

        public void EndGameMsg()
        {
            EndGame();
        }
    }
}

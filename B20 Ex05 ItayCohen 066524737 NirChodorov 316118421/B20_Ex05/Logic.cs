﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace B20_Ex02_1
{
    public class Logic
    {
        private const int k_MinimumLengthForGrid = 4;
        private const int k_MaximumLengthForGrid = 6;
        private const int k_SameCardCount = 2;
        private Random rnd = new Random();

        public Cell[,] GameGrid { get => m_GameGrid; set => m_GameGrid = value; }

        public int CurrentActivePlayerId { get => m_CurrentActivePlayerId; set => m_CurrentActivePlayerId = value; }

        public bool IsGameOver { get => m_IsGameOver; set => m_IsGameOver = value; }
        public List<Player> Players { get => m_Players; set => m_Players = value; }

        private List<Player> m_Players = null;
        private int m_CurrentActivePlayerId = 0;
        private bool m_IsGameOver = !true;
        private AiEngine m_AiEngine;
        private Cell[,] m_GameGrid;
        private List<char> m_OptionalCardsLetters;

        public Logic()
        {
            m_AiEngine = new AiEngine();
            Players = new List<Player>();
            m_OptionalCardsLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V' };
        }
         
        public void ShuffleGrid()
        {
            int rowGeneratedIndex, colGeneratedIndex;
            PictureBox tempPB = new PictureBox();
            for (int i = 0; i < (GetGridCols() * GetGridRows()) / k_SameCardCount; i++)
            {
                tempPB.Load(@"https://picsum.photos/80");
                for (int j = 0; j < k_SameCardCount; j++)
                {
                    do
                    {
                        rowGeneratedIndex = rnd.Next(GetGridRows());
                        colGeneratedIndex = rnd.Next(GetGridCols());
                    } 
                    while (m_GameGrid[rowGeneratedIndex, colGeneratedIndex] != null);

                    m_GameGrid[rowGeneratedIndex, colGeneratedIndex] = new Cell(m_OptionalCardsLetters[i], !true, tempPB.Image);
                }
            }
        }

        public Player GetActivePlayer()
        {
            return Players.Find(ply => ply.Id == m_CurrentActivePlayerId);
        }

        public char GetCellContent(int i_Row, int i_Col)
        {
            return m_GameGrid[i_Row, i_Col].Letter;
        }

        public Image GetCellImg(int i_Row, int i_Col)
        {
            return m_GameGrid[i_Row, i_Col].ButtonBackImg;
        }

        public bool IsCellVisable(int row,int col)
        {
            return m_GameGrid[row, col].IsVisable;
        }


        public bool TryCreateGrid(int i_Rows, int i_Cols)
        {
            bool v_IsValid = checkLimits(i_Rows, k_MinimumLengthForGrid, k_MaximumLengthForGrid) && checkLimits(i_Cols, k_MinimumLengthForGrid, k_MaximumLengthForGrid) && ((i_Rows * i_Cols) % 2 == 0);
            if (v_IsValid)
            {
                GameGrid = new Cell[i_Rows, i_Cols];
                ShuffleGrid();
            }
            
            return v_IsValid;
        }

        public bool TryFlipCard(int i_Row, int i_Col)
        {
            bool v_FlipSuccess = !true;
            if (checkLimits(i_Row, 0, GetGridRows() - 1 ) && checkLimits(i_Col, 0, GetGridCols() - 1 ))
            {
                if(m_GameGrid[i_Row, i_Col].IsVisable == !true)
                {
                    setCellVisiballity(i_Row, i_Col, true);
                    v_FlipSuccess = true;
                }
            }
             
            return v_FlipSuccess;
        }

        public void AddNewPlayer(Player i_Player)
        {
            if (Players == null)
            {
                Players = new List<Player>();
                Players.Add(i_Player);
            }
            else if (Players.Count < 2)
            {
                Players.Add(i_Player);
            }
        }

        public Player GetWinner()
        {
            int max = 0;
            Player winningPlayer = null;
            Players.ForEach(ply =>
            {
                if (ply.NumOfHits > max)
                {
                    max = ply.NumOfHits;
                    winningPlayer = ply;
                }
            });

            return winningPlayer;
        }

        public Player GetLoser()
        {
            int min = GetGridCols() * GetGridRows() / 2;
            Player losingPlayer = null, winningPlayer = GetWinner();
            Players.ForEach(ply =>
            {
                if (ply.NumOfHits < min && ply != winningPlayer)
                {
                    min = ply.NumOfHits;
                    losingPlayer = ply;
                }
            });
            return losingPlayer;
        }

        public bool TryQuitGame(string i_UserInput)
        {
            string userInputAfterTrim = i_UserInput.Trim(' ').ToUpper();
            m_IsGameOver = userInputAfterTrim.Contains('Q');
            return m_IsGameOver;
        }

        public int[] MakeComputerMove()
        {
            int[] firstPick, secondPick;

            do
            {
                firstPick = m_AiEngine.GetPick(GetGridRows(), GetGridCols());
            } 
            while (!TryFlipCard(firstPick[0], firstPick[1]));
            do
            {
                secondPick = m_AiEngine.GetPick(GetGridRows(), GetGridCols(), new AiEngine.CardOnBoard(firstPick[0], firstPick[1], m_GameGrid[firstPick[0], firstPick[1]]));
            }
            while (!TryFlipCard(secondPick[0], secondPick[1]));

            bool v_IsHit = TryUpdateForEquality(firstPick[0], firstPick[1], secondPick[0], secondPick[1]);
            return new int[] { firstPick[0], firstPick[1], secondPick[0], secondPick[1] };
        }

        public int GetGridCols()
        {
            return m_GameGrid.GetLength(1);
        }

        public int GetGridRows()
        {
            return m_GameGrid.GetLength(0);
        }

        public bool IsGameOn()
        {
            bool v_FoundInvisible = !true;
            if (!IsGameOver)
            {
                for (int i = 0; i < GetGridRows() && !v_FoundInvisible; i++)
                {
                    for (int j = 0; j < GetGridCols() && !v_FoundInvisible; j++)
                    {
                        if (!m_GameGrid[i, j].IsVisable)
                        {
                            v_FoundInvisible = true;
                        }
                    }
                }
            }

            return v_FoundInvisible;
        }

        // get player match cells. check the cells equaility. if true - > update the cell with the player id
        public bool TryUpdateForEquality(int i_RowFirstCell, int i_ColFirstCell, int i_RowSecondCell, int i_ColSecondCell)
        {
            // check if the cordinate are not eaqual
            bool v_IsValid = !((i_RowFirstCell == i_RowSecondCell) && (i_ColSecondCell == i_ColFirstCell));

            // check valid cordinate
            v_IsValid = v_IsValid && (checkLimits(i_RowFirstCell, 0, GetGridRows()) && checkLimits(i_ColFirstCell, 0, GetGridCols() ))
                && (checkLimits(i_RowSecondCell, 0, GetGridRows()) && checkLimits(i_ColSecondCell, 0, GetGridCols()));

            if (v_IsValid)
            {
                if (m_GameGrid[i_RowFirstCell, i_ColFirstCell].Letter == m_GameGrid[i_RowSecondCell, i_ColSecondCell].Letter)
                {
                    updateOnEqual(i_RowFirstCell, i_ColFirstCell, i_RowSecondCell, i_ColSecondCell);
                }
                else
                {
                    updateOnNotEqual(i_RowFirstCell, i_ColFirstCell, i_RowSecondCell, i_ColSecondCell);
                    v_IsValid = !true;
                }
            }

            return v_IsValid;
        }

        private void updateOnEqual(int i_RowFirstCell, int i_ColFirstCell, int i_RowSecondCell, int i_ColSecondCell) 
        {
            Player currentPlayer = GetActivePlayer();

            // update cells match (which player discover this couple)
            updatePlayerCellFinder(currentPlayer, i_RowFirstCell, i_ColFirstCell);
            updatePlayerCellFinder(currentPlayer, i_RowSecondCell, i_ColSecondCell);

            // update cells visabillity
            setCellVisiballity(i_RowFirstCell, i_ColFirstCell, true);
            setCellVisiballity(i_RowSecondCell, i_ColSecondCell, true);

            // update player hits
            addHit(currentPlayer);

            m_AiEngine.RemoveFromPrevChoices(m_GameGrid[i_RowFirstCell, i_ColFirstCell]);
            m_AiEngine.RemoveFromPrevChoices(m_GameGrid[i_RowSecondCell, i_ColSecondCell]);
        }

        private void updateOnNotEqual(int i_RowFirstCell, int i_ColFirstCell, int i_RowSecondCell, int i_ColSecondCell)
        {
            // update cells visabillity
            //setCellVisiballity(i_RowFirstCell, i_ColFirstCell, !true);
            //setCellVisiballity(i_RowSecondCell, i_ColSecondCell, !true);

            m_AiEngine.InsertPrevChoice(i_RowFirstCell, i_ColFirstCell, m_GameGrid[i_RowFirstCell, i_ColFirstCell]);
            m_AiEngine.InsertPrevChoice(i_RowSecondCell, i_ColSecondCell, m_GameGrid[i_RowSecondCell, i_ColSecondCell]);

            // give the turn to another player
            updateActivePlayer();
        }

        private bool checkLimits(int i_Number, int i_Low, int i_High)
        {
            return (i_Number >= i_Low) && (i_Number <= i_High);
        }

        private void updateActivePlayer()
        {
            int activePlayerIndex = Players.FindIndex(ply => ply.Id == CurrentActivePlayerId);
            CurrentActivePlayerId = (activePlayerIndex + 1 >= Players.Count()) ? Players[0].Id : Players[activePlayerIndex + 1].Id;
        }

        public void setCellVisiballity(int i_Row, int i_Col, bool i_isVisible)
        {
            if(checkLimits(i_Row, 0, GetGridRows()) && checkLimits(i_Row, 0, GetGridCols()))
            {
                m_GameGrid[i_Row, i_Col].IsVisable = i_isVisible;
            }
        }

        // update the cells property in which player find its match
        private void updatePlayerCellFinder(Player i_Ply, int i_Row, int i_Col)
        {
            m_GameGrid[i_Row, i_Col].PlayerId = i_Ply.Id;
        }

        private void addHit(Player i_Ply)
        {
            Players.FirstOrDefault(ply => ply.Id == i_Ply.Id).NumOfHits++;
        }
    }
}

using B20_Ex02_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex05
{
    class GameController
    {
        private MemoryGameSettings m_MemoryGameSetting;
        private MemoryGame m_MemoryGame;
        private Logic m_GameLogic = new Logic();
        public static string m_FirstPlayerName;
        public static string m_SecondPlayerName;
        public static string m_GridSize;
        public static int rows , cols;

        public GameController()
        {
            m_MemoryGameSetting = new MemoryGameSettings();
            m_MemoryGame = new MemoryGame();
            
        }
        public void Run()
        {
            m_MemoryGameSetting.ShowDialog();
            initializePlayers();
            initializeGrid();
            m_MemoryGame.ShuffleButtons();
            m_MemoryGame.ShowDialog();

        }

        private void initializePlayers()
        {
            m_GameLogic.AddNewPlayer(new Player(0, m_FirstPlayerName, true));
            if (m_SecondPlayerName == string.Empty)
            {
                m_GameLogic.AddNewPlayer(new Player(1, "Computer", !true));
            }
            else
            {
                m_GameLogic.AddNewPlayer(new Player(1, m_SecondPlayerName, true));
            }
        }
        private void initializeGrid()
        {
            rows = m_GridSize[0]-48;
            cols = m_GridSize[4]-48;
            m_GameLogic.TryCreateGrid(rows, cols);
        }
      
        
    }
}

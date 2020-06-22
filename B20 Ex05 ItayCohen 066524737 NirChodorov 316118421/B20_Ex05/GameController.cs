using B20_Ex02_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex05
{
    class GameController
    {
        private MemoryGameSettings m_MemoryGameSetting;
        private Logic m_GameLogic = new Logic();
        public GameController()
        {
            m_MemoryGameSetting = new MemoryGameSettings();

        }
        public void Run()
        {
            m_MemoryGameSetting.ShowDialog();
        }
    }
}

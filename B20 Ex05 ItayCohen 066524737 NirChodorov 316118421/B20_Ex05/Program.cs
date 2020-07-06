using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B20_Ex05
{
    class Program
    {
        public static void Main()
        {
            playGame();
            
        }

        private static void playGame()
        {
            string endOfTheGameMSG = string.Format(@"Press Yes to play new game, or No to Exit"); ;
            do
            {
                GameController m_UIManager = new GameController();
                m_UIManager.Run();
            }
            while (MessageBox.Show(endOfTheGameMSG, "GoodBye ?", MessageBoxButtons.YesNo) == DialogResult.Yes);
        }
    }
}

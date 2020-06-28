using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B20_Ex05
{
    interface IGameControll
    {
        void MakeMove(Button i_ButtonPressed);
        char GetCellContent(int row, int col);
        void SetGridSize(string i_SizeSTR);
        void SetSecondPlayerName(string i_Name);
        void SetFirstPlayerName(string i_Name);

        int GetRows();
        int GetCols();
        
    }
}

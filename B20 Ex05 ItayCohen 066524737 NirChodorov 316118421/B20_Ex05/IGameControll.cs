using System.Windows.Forms;

namespace B20_Ex05
{
    public interface IGameControll
    {
        void MakeMove(Button i_ButtonPressed);
        char GetCellContent(int i_Row, int i_Col);
        void SetGridSize(string i_SizeSTR);
        void SetSecondPlayerName(string i_Name);
        void SetFirstPlayerName(string i_Name);
        int GetRows();
        int GetCols();
     



    }
}

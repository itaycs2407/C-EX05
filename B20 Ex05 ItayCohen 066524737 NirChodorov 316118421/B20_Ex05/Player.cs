using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02_1 
{ 
    public class Player 
    {
        private int m_Id;
        private string m_Name;
        private int m_NumOfHits;
        private bool m_IsHuman = !true;
        private Color m_color;

        public Player(int i_Id, string i_Name, bool i_IsHuman, Color i_Color)
        {
            m_Id = i_Id;
            m_Name = i_Name;
            m_IsHuman = i_IsHuman;
            m_NumOfHits = 0;
            m_color = i_Color;
        }

        public int NumOfHits { get => m_NumOfHits; set => m_NumOfHits = value; }

        public bool IsHuman { get => m_IsHuman;  }

        public string Name { get => m_Name; }

        public int Id { get => m_Id; }
        public Color Color { get => m_color; set => m_color = value; }
    }
}

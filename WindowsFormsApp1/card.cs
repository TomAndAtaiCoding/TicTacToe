using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class card
    {
        public Button CardButton;
        public int x;
        public int y;
        public string content;
        public string key;
        public card(int x, int y, Button button)
        {
            this.x = x;
            this.y = y;
            CardButton = button;
            content = "";
            button.Text = "";
            key = string.Format("({0},{1})", x, y);
            Globals.cards.Add(key, this);
        }
    }
}

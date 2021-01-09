using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract2_20191122_WinForms_Game_TableShulte
{
    class ButtonComparer:IComparer<Button>
    {
        public int Compare(Button btn1, Button btn2)
        {
            if (Int32.Parse(btn1.Text) > Int32.Parse(btn2.Text))
            {
                return 1;
            }
            else if (Int32.Parse(btn1.Text) < Int32.Parse(btn2.Text))
            {
                return -1;
            }

            return 0;
        }
    }
}

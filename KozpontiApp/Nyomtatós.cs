using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KozpontiApp
{
    class Nyomtatós : Főoldalolvasó
    {
        Button b;

        public Nyomtatós(Button b)
        {
            this.b = b;
            színezés(b, lenyeg("NYOMTATÓS"));
        }
    }
}

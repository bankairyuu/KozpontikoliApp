using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KozpontiApp
{
    class Kondi : Főoldalolvasó
    {
        Button b;

        public Kondi(Button b)
        {
            this.b = b;
            színezés(b, lenyeg(1));
        }

        
    }
}

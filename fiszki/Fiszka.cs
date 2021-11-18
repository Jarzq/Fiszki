using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiszki
{
    class Fiszka
    {
        public string Front, Back;
        public bool check;

       public Fiszka(string front, string back, bool check)
        {
            this.Front = front;
            this.Back = back;
            this.check = false;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab_5
{
    partial class Example
    {
        public int i;
        public string example;
        static int schetchik = 0;
        public Example(int i, string example)
        {
            this.i = i;
            this.example = example;
            schetchik++;
        }
        public void M()
        {
            Console.WriteLine("{0 } №{1}", this.example, this.i);
        }
    }
 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab12
{
    [Serializable]
    public class Novosti : descriptionOfProgram
    {
        public Novosti():base(1)
        {

        }
        public Novosti(string country) : base(1)
        {
            this.country = country;
        }
        public override string ToString()
        {
            return "Новости страны " + this.country + ". " + base.ToString();
        }
        public void output(string p1, string p2)
        {
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
        string country;
    }
}

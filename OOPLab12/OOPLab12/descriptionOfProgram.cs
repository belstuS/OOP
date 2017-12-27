using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab12
{
    public abstract class descriptionOfProgram
    {
        public enum typeOfProgram
        {
            Novosti = 1, Film, Catoon, Blurb, Peredacha
        }
        public enum typeOfFilm
        {
            featureFilm = 1, comedy, horror, adventure
        }
        public struct Time
        {
            public int hour;
            public int minutes;
        }
        public Time time;//время в которое показывается что-либо
                         //    string type;
        typeOfProgram prog;
        public descriptionOfProgram(int i)
        {
            Console.WriteLine("Укажите время: ");
            Console.Write("Hour = ");
            this.time.hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Min = ");
            this.time.minutes = Convert.ToInt32(Console.ReadLine());
            this.prog = (typeOfProgram)i;
        }
        public override string ToString()
        {
            return "Time: " + this.time.hour + ":" + this.time.minutes + "\n" + this.prog;
        }
    }
}

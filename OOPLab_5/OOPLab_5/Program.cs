using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab_5
{
    partial class Example
    {
        public virtual void MethodForEmp()
        {
            Console.WriteLine("Пример частичного класса, разбитого на два файла: ExmplOfPartial, Program");
        }
    }
    enum Days
    {
        Monday = 1, Tuesday, Wensday, Thursday , Friday, Saturday, Sunday
    }
    public enum typeOfProgram
    {
        Novosti = 1, Film, Catoon, Blurb, Peredacha
    }
    public  enum typeOfFilm
    {
        featureFilm = 1, comedy, horror, adventure
    }
    public struct Time
    {
        public int hour;
        public int minutes;
    }
    public abstract class descriptionOfProgram
    {
        public Time time;
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
            return "Time: " + this.time.hour + ":" + this.time.minutes+ "\n"+this.prog;
        }
    }
    public class Novosti: descriptionOfProgram
    {
        public Novosti(string country):base(1)
        {
            this.country = country;
        }
        public override string ToString()
        {
            return "Новости страны " + this.country+". "+base.ToString();
        }
        string country;
    }
    public class Film: descriptionOfProgram
    {
       
        public Film(string country, string nameofFilm, int type) : base(2)
        {
            this.country = country;
            this.nameOfFilm = nameofFilm;
            Console.WriteLine("Введите год издания фильма: ");
            this.year = Convert.ToInt32(Console.ReadLine());
            this.type = (typeOfFilm)type;
         }
        typeOfFilm type
        {
            get; set;
        }
        public override string ToString()
        {
            return this.type +" "+ this.nameOfFilm +", страна: "+this.country +", год: . "+this.year+base.ToString();
        }
        string country;
        string nameOfFilm;
        int year;
    }
    public class Catton: descriptionOfProgram
    {
        string nameOfCatton;
        int ageLimit;
        public Catton(string NameOfCatton, int ageLimit):base(3)
        {
            this.nameOfCatton = NameOfCatton;
            this.ageLimit = ageLimit;
        }
        public override string ToString()
        {
            return "Мультфильм: " + this.nameOfCatton + ", возрастное ограничение = " + this.ageLimit + base.ToString();
        }
    }
    public class Blurb: descriptionOfProgram
    {
        string nameOfProduct;
        public Blurb(string NameOfProduct):base(4)
        {
            this.nameOfProduct = NameOfProduct;
        }
        public override string ToString()
        {
            return "Реклама " + this.nameOfProduct+". "+ base.ToString();
        }
    }
    public class Broadcast: descriptionOfProgram
    {
        string nameOfGuiding;
        string nameofBroadcast;
        int ageLimit;
        public Broadcast(string nameOfBroadcast, string nameofGuiding, int ageLimit):base(5)
        {
            this.nameofBroadcast = nameOfBroadcast;
            this.nameOfGuiding = nameofGuiding;
            this.ageLimit = ageLimit;
        }
        public override string ToString()
        {
            return "Телепередача "+this.nameofBroadcast+", телеведещий "+ this.nameOfGuiding+". " + base.ToString();
        }
    }
    class Container
    {
        public List<descriptionOfProgram> m1 = new List<descriptionOfProgram>();
        public void Add(descriptionOfProgram obj)
        {
            m1.Add(obj);
        }
        public void Remove(descriptionOfProgram obj)
        {
            m1.Remove(obj);
        }
        static public void Print(List<descriptionOfProgram> spisok)
        {
            foreach (descriptionOfProgram i in spisok)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
    class Controller : IComparer<descriptionOfProgram>
    {
        public int countOfBlurb(Container obj)
        {
            int count = 0;
            foreach (descriptionOfProgram i in obj.m1)
            {
                if (i.GetType() == typeof(Blurb))
                    count++;
            }
            return count;
        }
        public int lenghtOfIt(Container obj)
        {
            int count = 0;
            foreach (descriptionOfProgram i in obj.m1)
            {
                count += i.time.hour * 60 + i.time.minutes;
            }
            return count;
        }
        public int Compare(descriptionOfProgram obj1, descriptionOfProgram obj2)
        {
            if (obj1.time.hour > obj2.time.hour)
            {
                return 1;
            }
            if (obj1.time.hour < obj2.time.hour)
            {
                return -1;
            }
            else
            {
                if (obj1.time.minutes > obj2.time.minutes)
                    return 1;
                if (obj1.time.minutes < obj2.time.minutes)
                    return -1;
            }
            return 0;
        }
    }
        class Program
        { 
            static void Main(string[] args)
            {
            Example ex = new Example(1, "Пример");//демонстрация работы partial класса
            ex.M();
            Container mas = new Container();
            Console.WriteLine("Film");
            Film obj1 = new Film("Tor", "Пила 8", 1);
            Console.WriteLine("Blurb");
            Blurb obj2 = new Blurb("Памперсы");
            Console.WriteLine("Blurb");
            Blurb obj3 = new Blurb("Ситилинк");
            Console.WriteLine("Catton");
            Catton obj4 = new Catton("Что бы было", 16);
            Console.WriteLine("Novosti");
            Novosti obj5 = new Novosti("Беларусь");
            mas.Add(obj1);
            mas.Add(obj2);
            mas.Add(obj3);
            mas.Add(obj4);
            mas.Add(obj5);
            Container.Print(mas.m1);
            Controller contr = new Controller();
            Console.WriteLine("Количество реклам в телепередаче = {0}", contr.countOfBlurb(mas));
            Console.WriteLine("Проолжительность программы = {0}", contr.lenghtOfIt(mas));
            mas.m1.Sort(new Controller());
            Console.WriteLine("\n");
            Console.WriteLine("Отсортированная программа: \n");
            Container.Print(mas.m1);
            Console.ReadKey();
            }
        }
}


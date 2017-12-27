using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
        Monday = 1, Tuesday, Wensday, Thursday, Friday, Saturday, Sunday
    }
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
    public abstract class descriptionOfProgram
    {
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
    class NovostiException : Exception
    {
        public NovostiException(string message) : base(message)
        {

        }
    }
    public class Novosti : descriptionOfProgram
    {
        public Novosti(string country) : base(1)
        {
            if (country.CompareTo("Северная Корея") == 0)
            {
                throw new NovostiException("Новости Северной Кореи строго запрещены");
            }
            this.country = country;
        }
        public override string ToString()
        {
            return "Новости страны " + this.country + ". " + base.ToString();
        }
        string country;
    }
    public class Film : descriptionOfProgram
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
            return this.type + " " + this.nameOfFilm + ", страна: " + this.country + ", год: . " + this.year + base.ToString();
        }
        string country;
        string nameOfFilm;
        int year;
    }
    class CartoonException:Exception 
    {
        string message;
        public CartoonException(string message):base(message)
        {
        }
    }

    public class Cartoon : descriptionOfProgram
    {
        string nameOfCartoon;
        int ageLimit;
        public Cartoon(string NameOfCartoon, int ageLimit) : base(3)
        {
            this.nameOfCartoon = NameOfCartoon;
            if (ageLimit > 18)
                throw new CartoonException("Возрастное ограничение - 18 лет");
            this.ageLimit = ageLimit;
        }
        public override string ToString()
        {
            return "Мультфильм: " + this.nameOfCartoon + ", возрастное ограничение = " + this.ageLimit + base.ToString();
        }
    }
    
    class BlurbException : Exception
    {

        public BlurbException(string message) : base(message)
        {

        }
    }
    public class Blurb: descriptionOfProgram
    {
        string nameOfProduct;
        public Blurb(string nameOfProduct):base(4)
        {
            if (nameOfProduct.CompareTo("Шампунь") == 0)
                throw new BlurbException("реклама шампуня запрещена");
            this.nameOfProduct = nameOfProduct;
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
            try
            {
                int i = 1;
                i /= 0;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Внимание: деление на нуль!");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null-объект");
            }
            finally
            {
                Console.WriteLine("Возникла ошибка");
            }
            try
            {
                int[] mas3 = new int[2];
                mas3[3] = 1;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за пределы массива!");
            }
            finally
            {
                Console.WriteLine("Ошибка успешно вычислена");
            }
            try
            {
                FileStream m = File.OpenRead("nan");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за пределы массива");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Не найден файл с указанным именем");
            }
            try
            {
                bool u = false;
                Debug.Assert(u);
                Debug.Assert(u, "message");
                Debug.Assert(u, "message", "detailMessage");
                Blurb obj2 = new Blurb("Jacobs");
                Cartoon obj4 = new Cartoon("Next", 19);
                Blurb obj3 = new Blurb("Шампунь");
                Example ex = new Example(1, "Пример");//partial
                ex.M();
                Container mas = new Container();
                Console.WriteLine("Film");
                Film obj1 = new Film("Na'Vi", "True Side", 1);
                Console.WriteLine("Blurb");
                Console.WriteLine("Blurb");
                Console.WriteLine("Catton");
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
            catch (CartoonException ex)
            {
                Console.WriteLine("Ошибка в логике введенных данных");
            }
            catch (FormatException)
            {
                Console.WriteLine("Тип введенных данным неверный");

            }
            finally
            {
                Console.WriteLine("Stop исключениям");
                Console.ReadKey();
            }
            
            }
        }
}


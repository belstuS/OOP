using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OOPLab10
{
    public enum typeOfProgram
    {
        Novosti = 1, Film, Catoon, Blurb, Peredacha
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
    public class Novosti : descriptionOfProgram
    {
        int kanal;
        public int Kanal
        {
            get
            {
                return kanal;
            }
            set
            {
                kanal = value;
            }
        }
        public Novosti(string country, int kanal) : base(1)
        {
            this.country = country;
        }
        public override string ToString()
        {
            return "Новости страны " + this.country + ". " + base.ToString();
        }
        string country;
    }
    class ObobCollect1<Object>
    {
        public SortedList<long, object> col = new SortedList<long, object>();
        Random rnd = new Random();
        public void PrintOut()
        {
            foreach (KeyValuePair<long, object> i in col)
                Console.WriteLine("Ключ = {0}, значение = {1}", i.Key, i.Value.ToString());
        }
        public void ADD(Object o)
        {
            long i = rnd.Next();
            col.Add(i, o);
        }
        public void CreateObCOl()
        {
            Console.WriteLine("Кол-во эл-ов в обобщенной коллекции SortedList = ");
            int count = Convert.ToInt32(Console.ReadLine());
            for (long i = 0; i < count; i++)
            {
                Console.WriteLine("Строка в {0} эл-те", i);
                string buf = Console.ReadLine();
                col.Add(i, buf);
            }
        }
        public void DeleteN()
        {
            Console.WriteLine("Количество элементов для удаления = ");
            int countToDel = Convert.ToInt32(Console.ReadLine());
            while (countToDel > 0 && this.col.Count > 0)
            {
                col.RemoveAt(col.Count-1);
                countToDel--;
            }
        }
}
    class ObobCollect2<Object>
    {
        Stack<Object> col = new Stack<Object>();
        public void Copy(ObobCollect1<Object> col1)
        {
            foreach (KeyValuePair<long, object> i in col1.col)
            {
                col.Push((Object)i.Value);
            }
        }
        public void PrintOut()
        {
            foreach (object i in col)
            {
                Console.WriteLine(i.ToString());
            }
        }
        public void Poisk(object i)
        {
            bool fl = false;
            while (this.col.Count > 0 && !fl)
            {
                if (i.Equals(this.col.Pop()))
                {
                    fl = true;
                    Console.WriteLine(i.ToString());
                }
                if (!fl)
                {
                    Console.WriteLine("Объект не найден");
                }
            }
        }
    }
    class ObservableCollection<T>
    {
        public delegate void Ki();
        public event Ki CollectionChange;
        public void M()
        {
            Console.WriteLine("Go");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ///////////////////////////////////Задание №1///////////////////////////////
                //ArrayList m = new ArrayList();
                //Random rdm = new Random();
                //for (int i = 0; i < 5; i++)
                //    m.Add(rdm.Next(0, 10));
                //m.Add("kjdld'");
                //m.Remove("kjdld'");
                //m.RemoveAt(2);
                //Console.WriteLine("Количество эл-ов в необобщенной коллекции = {0}", m.Count);
                //Console.WriteLine("Необобщенная коллекция: ");
                //foreach (object o in m)
                //    Console.WriteLine(o);
                ///////////////////////////////////Задание №2///////////////////////////////
                //ObobCollect1<string> obj1 = new ObobCollect1<string>();
                //obj1.CreateObCOl();
                //obj1.PrintOut();
                //obj1.DeleteN();
                //obj1.PrintOut();
                //ObobCollect2<string> obj2 = new ObobCollect2<string>();
                //obj2.Copy(obj1);
                //obj2.PrintOut();
                //obj2.Poisk("str");
                /////////////////////////////////Задание №3///////////////////////////////
                ObobCollect1<Novosti> obj3 = new ObobCollect1<Novosti>();
                obj3.ADD(new Novosti("Беларусь", 1));
                //obj3.ADD(new Novosti("РФ", 5));
                //obj3.ADD(new Novosti("Страны СНГ", 2));
                //obj3.ADD(new Novosti("Япония", 3));
                obj3.ADD(new Novosti("Северная Корея)", 4));
                //obj1.PrintOut();
                //obj1.DeleteN();
                //obj1.PrintOut();
                ObobCollect2<Novosti> obj4 = new ObobCollect2<Novosti>();
                obj4.Copy(obj3);
                obj4.PrintOut();
                obj4.Poisk(new Novosti("Япония", 3));
                obj4.PrintOut();
                Console.ReadKey();
                ObservableCollection<Novosti> obj5 = new ObservableCollection<Novosti>();
                obj5.CollectionChange += obj5.M;
                obj5.CollectionChange += obj5.M;
            }
            catch (Exception ex)
            {

            }
           
            
        }
    }
}

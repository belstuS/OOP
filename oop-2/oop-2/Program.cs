using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace oop2
{
    public class Date
    {
        public int day, month, year;
        static int age;
        static readonly long ID;
        const int centry = 20;
        static int count = 0;

        public Date()
        {
            day = 14;
            month = 12;
            year = 1998;
            age = 21;
            count++;
        }

        public Date(int day, int month, int year)
        {
            if (day > 0 && day < 32)
                this.day = day;
            else Console.WriteLine("Ошибка дня");
            if (month > 0 && month < 13)
                this.month = month;
            else Console.WriteLine("Ошибка месяца");
            if (year > 0 && year < 10000)
                this.year = year;
            else Console.WriteLine("Ошибка года");
            count++;
        } // Проверка

        public Date(int month = 12, int year = 1998)
        {
            this.day = 23;
            if (month > 0 && month < 13)
                this.month = month;
            else Console.WriteLine("Ошибка месяца");
            if (year > 0 && year < 10000)
                this.year = year;
            else Console.WriteLine("Ошибка года");
            count++;
        } // Проверка

        static Date() // только для чтения
        {
            age = 22;
            ID = DateTime.Now.Ticks;
            count++;
        }

        private Date(int year) // Закрытый конструктор
        {
            this.year = 1651;
            count++;
        }

        public int Day
        {
            get
            {
                return Day;
            }
            set
            {
                if ((value > 0) && (value < 32)) // Тестовое условие
                {
                    Day = value;
                }
                else
                {
                    Day = 0;
                }
            }
        }

        public void MetRef(ref int i)
        {
            i = i + 1;
        }
        public void MetOut(out int i)
        {
            i = 22;
        }

        public static void info(Date obj)
        {
            Console.WriteLine("Day = {0}, Month = {1}, Year = {2}", obj.day, obj.month, obj.year);
        }

        public partial class date // класс partial
        {
            private int day;
            private int month;
            private int year;
        }

        ~Date() // Деструктор [call on free memory]
        {
            count--;
        }

        public override int GetHashCode() // переопределяете методы класса 
        {
            int hash = 269;
            hash = this.day == 0 ? day = 22 : day.GetHashCode();
            hash = (hash * 47);
            return hash;
        }

        public override bool Equals(System.Object obj) // переопределяете методы класса 
        {
            if (obj == null)
            {
                return false;
            }

            Date day = obj as Date;
            if ((System.Object)day == null)
            {
                return false;
            }

            return (month == day.month) && (year == day.year);
        }

        public static string ToString(System.Object obj)
        {
            if (obj == null)
            {
                return "nil";
            }

            // If parameter cannot be cast to Point return false.
            Date p = obj as Date;
            if ((System.Object)p == null)
            {
                return "nil";
            }

            return p.day.ToString() + ":" + p.year.ToString();
        }

        public partial class data
        {
            private data()
            {
                age = 21;
                count++;
            }

        }
        public void getDate()
        {
            Console.WriteLine($"{day}/{month}/{year}");
        }

        public void getDateNew()
        {
            switch (month)
            {
                case 1:
                    Console.WriteLine($"{day} января {year} года");
                    break;
                case 2:
                    Console.WriteLine($"{day} февраля {year} года");
                    break;
                case 3:
                    Console.WriteLine($"{day} мара {year} года");
                    break;
                case 4:
                    Console.WriteLine($"{day} апреля {year} года");
                    break;
                case 5:
                    Console.WriteLine($"{day} мая {year} года");
                    break;
                case 6:
                    Console.WriteLine($"{day} июня {year} года");
                    break;
                case 7:
                    Console.WriteLine($"{day} июля {year} года");
                    break;
                case 8:
                    Console.WriteLine($"{day} августа {year} года");
                    break;
                case 9:
                    Console.WriteLine($"{day} сентября {year} года");
                    break;
                case 10:
                    Console.WriteLine($"{day} октября {year} года");
                    break;
                case 11:
                    Console.WriteLine($"{day} ноября {year} года");
                    break;
                case 12:
                    Console.WriteLine($"{day} декабря {year} года");
                    break;
                default:
                    Console.WriteLine("Error month");
                    break;
            }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
           Date x = new Date();
           int y = 22;
           x.MetRef(ref y);
           Console.WriteLine("Значние после вызова ref: {0}", y);
           x.MetOut(out y);
           Console.WriteLine("Значние после вызова out: {0}", y);

            Date x1 = new Date(20, 12, 1998);
            Date.info(x1);
            Console.WriteLine("День x1: {0}", x1.day);
            x1.getDate();
            x1.getDateNew();

           Date part = new Date(20, 12, 1998);
           Console.WriteLine("Equals x1 and part: {0}", x1.Equals(part));
           Console.WriteLine("x1.ToString: {0}", Date.ToString(x1));
           Console.WriteLine("x1.GetType(): {0}", x1.GetType());

            Date[] array = { new Date(20, 10,1997), new Date(21, 10, 1998), new Date() };

            // Определение типа, создание сущности и инициализация свойств
            var clas = new { day = 2, month = 10, year = 1984 };
            // Вывод свойств на консоль
            Console.WriteLine("day = {0}, month = {1}, year = {2}", clas.day, clas.month, clas.year);

            int a = int.Parse(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                if (array[i].year == a) Console.WriteLine($"{array[i].day}/{array[i].month}/{array[i].year}");
            }

            int g = int.Parse(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                if (array[i].day == g) Console.WriteLine($"{array[i].day}/{array[i].month}/{array[i].year}");
            }
            Console.ReadLine();
        }
    }
}
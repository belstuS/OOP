using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab11
{
    class Month
    {
        public string[] months = { "June", "July", "August", "September", "October", "November", "December",
        "January", "Febrary", "March", "April", "May"};
        public static void Print(IEnumerable<string> months)
        {
            foreach (string mon in months)
            {
                Console.WriteLine("{0}", mon);
            }
        }
        public int Count(IEnumerable<string> months)
        {
            int i = 0;
            foreach (string mon in months)
            {
                i++;
            }
            return i;
        }
    }
    class Rectangle
    {
        public static int vsp;
        public int a, b;//две стороны прямоугольника
        public double diag;
        public int ugol;
        static int kolichestvoObj = 0;
        public Rectangle()
        {
            kolichestvoObj++;
        }
        public Rectangle(int a, int b, int ugol)//параллелограмм
        {
            this.a = a;
            this.b = b;
            this.ugol = ugol;
            kolichestvoObj++;
        }
        public Rectangle(int a, int b)//прямоугольник
        {
            this.a = a;
            this.b = b;
            this.ugol = 90;
        }
        public Rectangle(int a)//квадрат со стороной 10
        {
            this.a = a;
            this.b = a;
            this.ugol = 90;
            kolichestvoObj++;
        }
        static Rectangle()
        {
            vsp = 1;
            kolichestvoObj++;
        }
        public double Diagonal(ref int a, ref int b, out int diag)
        {
            diag = (int)Math.Sqrt(a * b);
            return diag;
        }
        static public void InformationAboutObject(Rectangle rec)
        {
            vsp = rec.a.GetHashCode();
            Console.WriteLine("Объекты: ");
            Console.WriteLine("Переменная a имеет тип {0} и значение = {1}", rec.a.GetType(), rec.a);
            Console.WriteLine("Переменная b имеет тип {0}  и значение = {1}", rec.b.GetType(), rec.b);
            Console.WriteLine("Переменная ugol имеет тип {0} и значение = {1}", rec.ugol.GetType(), rec.ugol);
        }
        public int Perimetr()
        {
            return 2 * (this.a + this.b);
        }
        public double Square()
        {
            return this.a * this.b * Math.Sin(Math.PI * this.ugol / 180);
        }
        public int Perimeter()
        {
            return 2 * (this.a + this.b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Month m = new Month();
            Console.WriteLine("Введите длину строки = ");
            int i = Convert.ToInt32(Console.ReadLine());
            IEnumerable<string> sequence1 = from n in m.months
                                            where n.Length == i
                                            select n;
            IEnumerable<string> sequence2 = from n in m.months
                                            where n.Equals("June") || n.Equals("July") || n.Equals("August")
                                            select n;
            IEnumerable<string> sequence3 = from n in m.months
                                            where n.Equals("December") || n.Equals("Febrary") || n.Equals("January")
                                            select n;
            IEnumerable<string> sequence4 = from n in m.months
                                            orderby n
                                            select n;

            int countOfMon = m.months.Count(p => p.Contains('u') && m.months.Length > 4);
            Console.WriteLine("Название месяцев с указанной длинной: ");
            Month.Print(sequence1);
            Console.WriteLine("Летние месяца: ");
            Month.Print(sequence2);
            Console.WriteLine("Зимние месяца: ");
            Month.Print(sequence3);
            Console.WriteLine("Месяца в алфавитном порядке: ");
            Month.Print(sequence4);
            Console.WriteLine("Месяца содеражащие букву u и неменьше по длине 4: {0}", countOfMon);
            List<Rectangle> list = new List<Rectangle>()
            {
                new Rectangle(4, 5, 45),
                new Rectangle(6, 7, 20),
                new Rectangle(10),
                new Rectangle(4),
                new Rectangle(5, 6),
                new Rectangle(3, 8, 37),
                new Rectangle(5, 23),
                new Rectangle(8)
            };
            IEnumerable<Rectangle> quadrat = from n in list
                                             where n.a == n.b && n.ugol == 90
                                             select n;
            IEnumerable<Rectangle> parallelogram = from n in list
                                                   where n.a != n.b && n.ugol != 90
                                                   select n;
            IEnumerable<Rectangle> rectangle = from n in list
                                               where n.a != n.b && n.ugol == 90
                                               select n;
            Console.WriteLine("Минимальная площадь квадрата: ");
            double min = quadrat.Min(p => p.Square());
            Console.WriteLine("{0}", min);
            double max = quadrat.Max(p => p.Square());
            Console.WriteLine("Максимальная площадь квадрата: ");
            Console.WriteLine(max);


            Console.WriteLine("Минимальная площадь параллелограма: ");
            min = parallelogram.Min(p => p.Square());
            Console.WriteLine("{0:N2}", min);
            max = parallelogram.Max(p => p.Square());
            Console.WriteLine("Максимальная площадь параллелограма: ");
            Console.WriteLine("{0:N2}", max);

            Console.WriteLine("Минимальная площадь прямоугольника: ");
            min = rectangle.Min(p => p.Square());
            Console.WriteLine("{0}", min);
            max = rectangle.Max(p => p.Square());
            Console.WriteLine("Максимальная площадь прямоугольника: ");
            Console.WriteLine("{0}", max);

            Console.WriteLine("Введите x, где x - длина стороны квадрата: ");
            int x = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Rectangle> quadrat1 = from n in quadrat
                                              where n.a <= x
                                              select n;
            IEnumerable<int> rectangle1 = rectangle.Select(p => p.Perimeter());
            Console.ReadKey();
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPLab09
{
    class StringByme: IEnumerator
    {
        int position = 0;
        char[] str = new char[250];
        int capacity = 0;
        public void WriteString()
        {
          //  string m;
            for (int i = 0; i < this.capacity; i++)
            {
                Console.Write(this.str[i]);
            }
            Console.WriteLine();
        }
        public StringByme()
        {
            Console.WriteLine("Введите строку = ");
            string s = Console.ReadLine();
            foreach (char i in s)
            {
                str[position] = i;
                position++;
            }
            this.capacity = this.position;
        }
        public object Current
        {
            get
            {
                return str[position];
            }
        }
        public void CountofSim()
        {
            Console.WriteLine("Count of Simbols in string {0} = {1}", this.str, this.capacity);
        }
        public bool MoveNext()
        {
            this.position++;
            return (this.position < this.capacity);
        }
        public bool MovePrev()
        {
            position--;
            return (this.position > -1);
        }
        public void deleteSomeSimbols()
        {
            Console.WriteLine("Введите символ, который Вы хотите удалить из строки = ");
            char sim = Convert.ToChar(Console.ReadLine());
            int count = 0;
            this.position = -1;
            while (this.MoveNext())
            {
                if (sim == this.str[position])
                {
                    for (int m = position; m < capacity - 1; m++)
                    {
                        str[m] = str[m + 1];
                        str[m + 1] = '\0';
                    }
                    this.position--;
                    this.capacity--;
                count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Данная строка не содержит введенного символа!");
            }
            else
            {
                this.WriteString();
            }
        }
        public void ReverseOfString()
        {
            Console.WriteLine("Реверс даной строки");
            int i = 0;
            this.position = this.capacity;
            char[] buf = new char[255]; 
            while (this.MovePrev())
            {
                buf[i] = this.str[position];
                i++;
            }
            this.position = -1;
            while (this.MoveNext())
            {
                this.str[position] = buf[position];
            }
            this.WriteString();
        }
        public void NPovt()
        {
            Console.WriteLine("Количество повторений = ");
            int count = Convert.ToInt32(Console.ReadLine())-1;
            if (count > 0)
            {
                int m = this.capacity;
                this.capacity *= (count+1);
                while (count != 0)
                {
                    for (int i = this.position + 1, k = 0; k<m; i++, k++)
                    {
                        str[position] = str[k];
                        this.position++;
                    }
                    count--;
                }
                this.WriteString();
            }
            else
            {
                Console.WriteLine("Введтите корректное значение повторений строки");
            }
        }
        public void ToUpper()
        {
            position = -1;
            while (MoveNext())
            {
                if ((this.str[this.position] <='z' && this.str[this.position]>= 'a') ||
                    (this.str[this.position] <= 'а' && this.str[this.position] >= 'я'))
                {
                    int m = this.str[this.position] - 0x20;
                    this.str[position] = Convert.ToChar(m);
                }
            }
            Console.WriteLine("Result of method ToUpper: ");
            this.WriteString();
        }
        public void Reset()
        {
            position = -1;
        }
    }
    public delegate void D(int uron);
    public delegate void M();
    class Boss//инициатор
    {
        public event D TurnOn;
        public event M Upgrade;
        public void Command(int i)
        {
            this.TurnOn(i);
        }
        public void CommandM()
        {
            this.Upgrade();
        }
    }
    class PeopleException : Exception
    {
        public PeopleException(string message) : base("")
        {

        }
    }
    class People
    {
        string name;
        int age;
        int load;
        int uron;
        public string Name
        {
            get
            {
                return name;  
            }
        }
        public int Age
        {
            get
            {
                if (this.age > 100)
                    return age;
                else return 100 - this.age;
            }

        }
        public void Obnull(object sender, EventArgs e)
        {
            sender = null;
            Console.Clear();
            Console.WriteLine("Upgrade!");
        }
        public People(string name, int age, int load)
        {
            this.uron = 0;
            this.name = name;
            this.age = age;
            this.load = load;
        }
        public void Deistv(int uron)
        {
            if (this.uron > load)
            {
                Console.WriteLine("{0} требуется отдых", this.name);
                this.load = 0;
                this.uron += uron;
            }
             this.load -=uron;
            this.uron += uron;
        }
        public void Injury()
        {
            this.uron += 10;
            Console.WriteLine(this.uron);
        }
        public override string ToString()
        {
            return this.name + " " + "is of " + this.age + "ages " + this.uron + " - урон " + this.load + " - состояние";
        }
    }
    class Equipment
    {
        string nameOfProduct;
        int age;
        new int load;
        new int uron;
        public Equipment(string nameOfProduct, int age, int load)
        {
            this.uron = 0;
            this.age = age;
            this.load = load;
            this.nameOfProduct = nameOfProduct;
        }
        public void Injury()
        {
            this.uron += 20;
            Console.WriteLine(this.uron);
        }
        public void Deistv(int uron)
        {
            if (this.uron > load)
            {
                Console.WriteLine("{0} требуется отдых", this.nameOfProduct);
                this.load = 0;
                this.uron += uron;
            }
            this.load -= (int)(uron*0.58f);
            this.uron += (int)(uron*1.23f);
        }
        public override string ToString()
        {
            return this.nameOfProduct + " " + "is of " + this.age + "ages " + this.uron + " - урон " + this.load + " - состояние";
        }
    }
    public class Program
    {
        public delegate void Action<T>();
        public static void Main()
        {
            try
            {
                Boss obj1 = new Boss();
                People obj2 = new People("Pavel", 18, 20);
                Console.WriteLine(obj2);
                Equipment obj3 = new Equipment("Robot", 12, 50);
                Console.WriteLine(obj3);
                obj1.TurnOn += obj2.Deistv;
                obj1.TurnOn += obj3.Deistv;
                obj1.TurnOn += (int a) =>
                  {
                      Console.WriteLine(a);
                  };
                obj1.TurnOn += (int a) =>
                  {
                      Console.WriteLine("Пример работы делегата  №2");
                  };
                obj1.Command(10);

                obj1.Upgrade += obj2.Injury;
                obj1.Upgrade += obj3.Injury;
                obj1.CommandM();

                Console.WriteLine(obj2);
                Console.WriteLine(obj3);

                ////////////////////////////////////////////ЗАДАНИЕ№2////////////////////////////////////////////
                Action<StringByme> op;
                StringByme str1 = new StringByme();
                op = str1.CountofSim;
                op += str1.NPovt;
                op += str1.ToUpper;
                op += str1.ReverseOfString;
                op += str1.deleteSomeSimbols;
                op();
                Console.ReadKey();
            }
            catch (StackOverflowException)
            {
            }
            catch (Exception ex)
            {
            }
        }
    }
}
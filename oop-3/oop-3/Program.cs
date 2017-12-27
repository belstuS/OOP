using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//
namespace App
{

    class TPoint
    {
        public int x, y;

        public TPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class MyClass
    {
        public static int count = 0;
        private int sum;
        public int x, y;
        static readonly long ID; //можно только считывать значение, изменять в другом месте нельзя
        const int c = 15;

        public MyClass()
        {
            count++;
            x = 0;
            y = 0;
        }
        //  определите закрытый конструктор; предложите варианты его вызова;
        private MyClass(int x, int y, int sum)
        {
            count++;
            this.sum = (x + y) * (sum + c);
        }

        public MyClass(int x = 0, int y = 0)
        {
            count++;
            this.x = x;
            this.y = y;
        }

        public MyClass(TPoint p)
        {
            count++;
            this.x = p.x;
            this.y = p.y;
        }
        //статический конструктор (конструктор типа); 
        static MyClass()                        // Статический конструктор, вызывается 1 раз
        {
            count++;
            ID = DateTime.Now.Ticks;
        }
        //поле - только для чтения (например, для каждого экземпляра сделайте поле только для чтения ID - 
        //равно некоторому уникальному номеру (хэшу) вычисляемому автоматически на основе инициализаторов объекта)
        //Для одного из свойств ограните доступ по set  в одном из методов класса для работы с аргументами используйте ref - и out-параметры.

        public int Property
        {
            get
            {
                return Property;
            }
            set
            {
                if ((value > 0) && (value < 13))                // Тестовое условие
                {
                    Property = value + 1;
                }
                else
                {
                    Property = value;
                }
            }
        }

        public void Method(ref int i)
        {
            i = i + 13;
        }

        public void MethodOut(out int i)
        {
            i = 4;
        }

        ~MyClass()                              // Деструктор [call on free memory] 
        {
            count--;
        }
        // переопределяете методы класса Object: Equals, для сравнения объектов,  GetHashCode; 
        // для алгоритма вычисления хэша руководствуйтесь стандартными рекомендациями, ToString – вывода строки – информации об объекте.
        public override int GetHashCode()       // свой хэш, оверрид - переопределение
        {
            int unitCode;
            if (this.x == 0)
                unitCode = 1;
            else unitCode = 2;
            return this.y + unitCode;
        }

        public static void DrawInfo(MyClass Obj)
        {
            Console.WriteLine("x = {0}, y = {1}, sum = {2}", Obj.x, Obj.y, Obj.sum);
        }

        public override bool Equals(System.Object obj) //требования :рефлективность, симметричность, транзитивность, постоянство
        {
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            MyClass p = obj as MyClass;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (x == p.x) && (y == p.y);
        }

        public static string ToString(System.Object obj)
        {
            if (obj == null)
            {
                return "null";
            }

            // If parameter cannot be cast to Point return false.
            MyClass p = obj as MyClass; //as используется для выполнения определенных типов преобразований между совместимыми ссылочными типами
            //подобен оператору приведения. Однако, если преобразование невозможно, as возвращает значение null, а не вызывает исключение
            if ((System.Object)p == null)
            {
                return "null";
            }

            return p.x.ToString() + ":" + p.y.ToString();
        }
    }
    //Создайте несколько объектов вашего типа.Выполните вызов конструкторов, свойств, методов, сравнение объекты,
    ///проверьте тип созданного объекта и т.п.
    class Stringg
    {
        public string Value = "";

        public Stringg()
        {
            Value = "";
        }

        public Stringg(string value)
        {
            this.Value = value;
        }

        public int GetLength()
        {
            return Value.Length;
        }

        public bool FindChar(char c)
        {
            for (int i = 0; i < GetLength(); i++)
            {
                if (Value[i] == c) return true;
            }
            return false;
        }

        public bool IsWord(string word)
        {
            string[] arrWord;
            arrWord = Value.Split();
            for (int i = 0; i < arrWord.Length; i++)
            {
                if (word == arrWord[i]) return true;
            }
            return false;
        }

        public void Replace(char c1, char c2)
        {
            Value = Value.Replace(c1, c2);
        }
    }

    class MyStack
    {
        private float[] items; // элементы стека
        private int count;  // количество элементов
        const int n = 10;   // количество элементов в массиве по умолчанию
        public MyStack()
        {
            items = new float[n];
        }
        public MyStack(int length)
        {
            items = new float[length];
        }
        // пуст ли стек
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        // размер стека
        public int Count
        {
            get { return count; }
        }
        // добвление элемента
        public void Push(float item)
        {
            // если стек заполнен, выбрасываем исключение
            if (count == items.Length)
                throw new InvalidOperationException("Переполнение стека");
            items[count++] = item;
        }
        // извлечение элемента
        public float Pop()
        {
            // если стек пуст, исключение
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            float item = items[--count];
            items[count] = default(float); // сброс ссылку
            return item;
        }
        // возврат элемент из верхушки стека
        public float Peek()
        {
            return items[count - 1];
        }
        // существует ли отрицательный
        public bool isHaveNegative()
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] < 0) return true;
            }
            return false;
        }
        public float getMinValue()
        {
            if (count <= 0) throw new InvalidOperationException("Стек пуст");
            float fMin = items[0];
            for (int i = 1; i < count; i++)
            {
                if (fMin > items[i]) fMin = items[i];
            }
            return fMin;
        }
        public float getMaxValue()
        {
            if (count <= 0) throw new InvalidOperationException("Стек пуст");
            float fMax = items[0];
            for (int i = 1; i < count; i++)
            {
                if (fMax < items[i]) fMax = items[i];
            }
            return fMax;
        }
        public float GetValue(int n)
        {
            if (n > -1 && n < count) return items[n];
            throw new InvalidOperationException("Не существует");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass x = new MyClass();
            int v = 13;
            x.Method(ref v);                                            // In/Out access
            Console.WriteLine("Значние после вызова ref: {0}", v);
            x.MethodOut(out v);
            Console.WriteLine("Значние после вызова out: {0}", v);      // Out only

            MyClass x1 = new MyClass(5, 3);
            MyClass.DrawInfo(x1);
            Console.WriteLine("Кол-во: {0}", MyClass.count);

            MyClass partial = new MyClass(3, 5);
            Console.WriteLine("Equals x1 and partial: {0}", x1.Equals(partial));
            Console.WriteLine("x1.ToString: {0}", MyClass.ToString(x1));
            Console.WriteLine("x1.GetType(): {0}", x1.GetType());

            MyClass[] arr = { new MyClass(), new MyClass(1, 1), new MyClass(new TPoint(2, 2)) };



            //вариант 2
            int[] b = { 3, 5, 2 };
            MyStack[] ar = { new MyStack(b[0]), new MyStack(b[1]), new MyStack(b[2]) };
            Console.WriteLine("\nstacks: ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("ar[{0}]: ", i);
                for (int j = 0; j < b[i]; j++)
                {
                    ar[i].Push(((i % 2 == 0 && j % 2 == 1) ? (-1) : (1)) * (i + j) * 0.015f);
                    Console.Write("'{0}'; ", ar[i].GetValue(j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nnegative: ");
            for (int i = 0; i < 3; i++)
            {
                if (ar[i].isHaveNegative())
                {
                    Console.Write("ar[{0}]: ", i);
                    for (int j = 0; j < b[i]; j++)
                    {
                        Console.Write("'{0}'; ", ar[i].GetValue(j));
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}

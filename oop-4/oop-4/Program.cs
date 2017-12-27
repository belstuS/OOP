using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* - разность со скалярным значением; 
 * > проверка на вхождениеэлемента; 
 * !=проверка на неравенствомассивов ; 
 * + объединение массивов
 */
namespace Lab_4
{
    static public class MathemObject
    { // Методы расширения(extension methods) позволяют добавлять новые методы в уже существующие типы без создания нового производного класса.
        static public void nullFunc(this int[] arr, int len)
        {
            /*расчета определенных параметров 
           * (например:обнуление элементов, поиск минимального, размер объекта и т.п).
           */
            Console.WriteLine("массив из нулей");
            for (int i = 0; i < len; i++)
            {
                arr[i] = 0;
                Console.WriteLine(arr[i]);
            }
        }
        static public void maxElem(this int[] arr, int len)
        {
            int max = arr[0];
            for (int i = 0; i < len; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            Console.WriteLine("Максимальный элемент массива " + max);
        }
        static public void minElem(this int[] arr, int len)

        {
            int min = arr[0];
            for (int i = 0; i < len; i++)
            {
                if (min >= arr[i])
                    min = arr[i];
            }
            Console.WriteLine("Минимальный элемент массива " + min);
        }


        // проверка гласных в строке
        static public void Glasnye(this string str)
        {
            string c = "eyuioa";
            string str1 = c;
            char[] arrp = str.ToCharArray();
            char[] arrp1 = str.ToCharArray();
            for (int j = 0; j < str1.Length; j++)
            {
                for (int i = 0; i < arrp1.Length; i++)
                {
                    if (str1[j] == arrp[i])
                        Console.WriteLine("Гласные " + arrp[i] + " есть в строке");
                }
            }
        }

        //Удаление первых пяти элементов
        static public void Delete(this int[] arr, int len)
        {
            len = arr.Length;
            for (int i = 0; i < len - 5; i++)
            {
                int leng = len - 5;
                arr[i] = arr[i + 5];
                arr[len] = arr[len];

            }
        }
    }

    public class MyArray
    {
        private int[] arr;
        private int length;
        private string s;
        public short ff; //для преобразования типа

           /*
            * Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. Проинициализируйте его
            */
        public class Owner
        { //включение классов - делегирование
            public int ID;
            public string CompanyName;

            public Owner(string str, int k)
            {
                ID = k;
                CompanyName = str;
            }
        }
        /*
         * Добавьте в свой класс вложенный класс Date(дата создания).Проинициализируйте
         */

        public class Data
        {
            public int month;
            public int day;
            public int years;
            public Data(int m, int d, int y)
            {
                month = m;
                day = d;
                years = y;
            }
        }
        /* создание массива
         */
        public MyArray(int size)
        {
            arr = new int[size];
            length = size;
        }
        
        // operator используется для перегрузки встроенного оператора или выполнения пользовательского преобразования в классе или объявлении структуры.
        public static MyArray operator -(MyArray obj1, MyArray obj2) //разность
        {
            MyArray myObj3 = new MyArray(obj1.length);
            for (int i = 0; i < myObj3.length; i++)
            {
                myObj3.arr[i] = obj1.arr[i] - obj2.arr[i];
            }
            return myObj3;
        }
        public static MyArray operator +(MyArray obj1, MyArray obj2) //объединение
        {
            MyArray myObj5 = new MyArray(obj1.length);
            for (int i = 0; i < myObj5.length; i++)
            {
                myObj5.arr[i] = obj1.arr[i] + obj2.arr[i];
            }
            return myObj5;
        }

        public static bool operator ==(MyArray obj1, MyArray obj2) //равенство (перегрузка попарно)
        {

            return obj1.Equals(obj2);
        }
        public static bool operator !=(MyArray obj1, MyArray obj2) //неравенство 
        {
            return !obj1.Equals(obj2);
        }

        public static bool operator <(MyArray obj1, MyArray obj2) //проверка на вхождение(перегрузка попарно)
        {
            if (obj1.length < obj2.length)
                return true;
            return false;
        }

        public static bool operator >(MyArray obj1, MyArray obj2)
        {
            if (obj1.length > obj2.length)   //проверка на вхождение
                return true;
            return false;
        }
        //implicit - неявное преобразование, explicit - явное преобразование
        public static explicit operator int(MyArray obj) //объявляет оператор преобразования определяемого пользователем типа, который должен быть вызван с помощью приведения
        {
            return obj.ff;
        }
        //для перегрузки операторов == и !=
        public override int GetHashCode()
        {
            int hash = 269;
            s.GetHashCode();
            hash = (hash * 47) + arr.Length.GetHashCode();
            return hash;
        }


        public virtual Boolean Equals(MyArray obj)
        {
            bool a = false;
            if (obj.arr == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            if (obj.arr.Length == this.arr.Length)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == obj.arr[i])
                    {
                        if (i == arr.Length - 1)
                            a = true;
                    }
                    else { a = false; break; }
                }
            }
            else { a = false; }
            return a;
        }



        static void Main(string[] args)
        {
            int k = 3;
            int m = 4;
            MyArray myObj1 = new MyArray(k);
            Console.WriteLine("Значения массива объекта myObj1");
            for (int i = 0; i < k; i++)
            {
                myObj1.arr[i] = i * 2;
                Console.WriteLine(myObj1.arr[i]);
            }
            Console.WriteLine(" \n");
            MyArray myObj2 = new MyArray(k);
            Console.WriteLine("Значения массива объекта myObj2");
            for (int i = 0; i < k; i++)
            {
                myObj2.arr[i] = i * 2;
                Console.WriteLine(myObj2.arr[i]);
            }
            Console.WriteLine(" \n");
            MyArray myObj3 = myObj1 - myObj2;
            Console.WriteLine("Разность = " + myObj3);
            Console.WriteLine(" \n");
            MyArray myObj5 = myObj1 + myObj2;
            Console.WriteLine("Объединение = " + myObj5);
            Console.WriteLine(" \n");
            MyArray myObj4 = new MyArray(m);
            Console.WriteLine("Значения массива объекта myObj4");
            for (int i = 0; i < m; i++)
            {
                myObj4.arr[i] = i * 2 - 10;
                Console.WriteLine(myObj4.arr[i]);
            }
            Console.WriteLine(" \n");

            Console.WriteLine(" \n");
            if (myObj1 == myObj2)
                Console.WriteLine("Объекты 1 и 2 равны");
            else
                Console.WriteLine("Объекты 1 и 2 не равны");
            Console.WriteLine(" \n");
            if (myObj1 < myObj4)
                Console.WriteLine("объект №4 имеет большую длину");
            Console.WriteLine(" \n");
            int l = (int)myObj4;
            Console.WriteLine(l);
            Console.WriteLine(" \n");
            myObj4.arr.minElem(m);
            Console.WriteLine(" \n");
            myObj4.arr.maxElem(m);
            Console.WriteLine(" \n");
            myObj4.arr.Delete(m);
            Console.WriteLine(" \n");
            Console.WriteLine("Введите строку (на английском)");
            myObj4.s = Console.ReadLine();
            myObj4.s.Glasnye();
            Console.WriteLine(" \n");
            myObj4.arr.nullFunc(m);
            Console.WriteLine(" \n");
            Owner one = new Owner("Company", 34567);
            Console.WriteLine(one.CompanyName + " " + one.ID);
            Console.WriteLine(" \n");
            Data two = new Data(4, 10, 2017);
            Console.WriteLine(two.day + " " + two.month + " " + two.years);
            Console.WriteLine(" \n");
            Console.ReadKey();
        }
    }
}

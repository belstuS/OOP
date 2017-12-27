using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab_7
{
    public interface Iexmpl<T>
    {
        void AddItem(T a);
        void DeleteItem(T a);
        void ShowList(List<T> a);
    }
    public class CollectionType<T>
    {
        //2.1 Вложить обобщ. коллекцию
        public int kolch;//кол-во элементов в мн-ве
        public T[] mas;
        public CollectionType()
        {
            Console.WriteLine("Введите кол-во элементов в мн-ве");
            this.kolch = Convert.ToInt32(Console.ReadLine());
            mas = new T[kolch];
        }
        public void Output()
        {
            Console.Write("(");
            foreach (T i in mas)
            {
                Console.Write($"{i}, ");
            }
            Console.Write(")");
            Console.WriteLine();
        }
        public static bool operator <(CollectionType<T> set1, CollectionType<T> set2)//пересекаются ли мн-ва
        {
            for (int i = 0; i < set1.kolch; i++)
            {
                for (int m = 0; m < set2.kolch; m++)
                {
                    if (!set1.mas[i].Equals(set2.mas[m]))
                        return true;
                }
            }
            return false;
        }
        public static bool operator >(CollectionType<T> set1, CollectionType<T> set2)//множество set1 содержит в себе мн-во set2
        {
            int kol = 0;
            int kol1 = 0;
            if (set2.kolch > set1.kolch)
                return false;
            for (int i = 0; i < set2.kolch; i++)
            {
                for (int m = 0; m < set1.kolch; m++)
                {
                    if (!set1.mas[m].Equals(set2.mas[i]))
                        kol++;
                }
                if (kol > 0)
                {
                    kol1++;
                    kol = 0;
                }
                else
                    return false;
            }
            if (kol1 == set2.kolch)
                return true;
            return false;
        }
        public class Owner
        {
            public int Id;
            public string Name;
            public string organisation;
            public Owner(int Id, string Name, string organisation)
            {
                this.Id = Id;
                this.Name = Name;
                this.organisation = organisation;
            }
        }
        public void SaveObj()
        {
            FileStream f = new FileStream(@"C:\Users\Slava\Desktop\Универ\OOP\OOPLab_8\OOPLab_7\FileToSave.txt", FileMode.OpenOrCreate);
            byte[] array = System.Text.Encoding.Default.GetBytes(this.ToString());
            f.Write(array, 0, array.Length);
            f.Close();
        }
    }
    
    //3.2 Пример класса, используемого в кач-ве параметра обобщения
    public class Cartoon
    {
        string nameOfCartoon;
        int ageLimit;
        public Cartoon(string NameOfCartoon, int ageLimit)
        {
            this.nameOfCartoon = NameOfCartoon;
            this.ageLimit = ageLimit;
        }
        public override string ToString()
        {
            return "Мультфильм: " + this.nameOfCartoon + ", возрастное ограничение = " + this.ageLimit;
        }
        public void WriteAndRead()
        {
            FileStream f = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //  f.WriteByte(Convert.ToByte(this.ToString()));
            byte[] array = System.Text.Encoding.Default.GetBytes(this.ToString());
            f.Write(array, 0, array.Length);
            f.Close();

            using (FileStream file = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] array1 = new byte[file.Length];
                file.Read(array1, 0, array1.Length);
                string text = System.Text.Encoding.Default.GetString(array1);
                Console.WriteLine("Считанная информация из файла: {0}", text);
            }
        }
    }

    //обобщенный тип с ограничением
    class Exmpl<T> where T: class
    {
        public List<T> list = new List<T>();
        public void Show(T a)
        {
            Console.WriteLine(a.ToString());
        }
    }
    class Exmpl2<T> : Iexmpl<T>
    {
        public List<T> list = new List<T>();
        public void AddItem(T obj)
        {
            this.list.Add(obj);
        }
        public void DeleteItem(T a)
        {
           
                this.list.Remove(a);
        }
        public void ShowList(List<T> a)
        {
            foreach (T i in a)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //3.1 Проверка обощения для стандартных типов данных
                Cartoon obj = new Cartoon("666 смертных грехов", 12);
                obj.WriteAndRead();
                Random rm = new Random();
                Console.WriteLine("Obj1: ");
                CollectionType< int> obj1 = new CollectionType<int>();
                for (int i = 0; i < obj1.kolch; i++)
                {
                    obj1.mas[i] = rm.Next(1, 10);
                }
                obj1.SaveObj();
                Console.WriteLine("Obj2: ");
                CollectionType<int> obj2 = new CollectionType<int>();
                for (int i = 0; i < obj2.kolch; i++)
                {
                    obj2.mas[i] = rm.Next(1, 10);
                }
                Console.WriteLine("Obj1: ");
                obj1.Output();
                Console.WriteLine("Obj2: ");
                obj2.Output();
                Console.Write("Множество obj1 содержит в себе obj2 = ");
                Console.WriteLine(obj1 > obj2);
                Console.Write("Множества obj1 и obj2 пересекаются = ");
                Console.WriteLine(obj1 < obj2);
                Console.WriteLine("Obj3: ");
                CollectionType<string> obj3 = new CollectionType<string>();
                for (int i = 0; i < obj3.kolch; i++)
                {
                    Console.Write("obj3[{i}] = ", i);
                    obj3.mas[i] = Console.ReadLine();
                }
                Console.WriteLine("Obj4: ");
                CollectionType<string> obj4 = new CollectionType<string>();
                for (int i = 0; i < obj4.kolch; i++)
                {
                    Console.Write("obj4[{i}] = ", i);
                    obj4.mas[i] = Console.ReadLine();
                }
                Console.WriteLine("Obj3: ");
                obj3.Output();
                Console.WriteLine("Obj4: ");
                obj4.Output();
                Console.Write("Множество obj3 содержит в себе obj4 = ");
                Console.WriteLine(obj3 > obj4);
                Console.Write("Множества obj3 и obj4 пересекаются = ");
                Console.WriteLine(obj3 < obj4);
                //ПРОВЕРКА РАБОТОСПОСОБНОСТИ ЗАДАНИЯ 2.2
                Exmpl2<Cartoon> ob = new Exmpl2<Cartoon>();
                ob.AddItem(new Cartoon("Ну, погоди!", 12));
                ob.AddItem(new Cartoon("Том и Джери", 6));
                Exmpl<Cartoon> prov = new Exmpl<Cartoon>();
                prov.list.Add(new Cartoon("Город, в котором меня нет", 12));
                prov.list.Add(new Cartoon("Простоквашино", 3));
                prov.Show(prov.list[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверно введенные данные!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка в логике задаваемых параметров объектов");
            }
            finally
            {
                Console.WriteLine("Stop Exceptions!");
                Console.ReadKey();
            }
        }
    }
}
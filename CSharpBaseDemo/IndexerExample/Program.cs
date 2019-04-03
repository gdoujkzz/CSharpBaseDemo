using System;

namespace IndexerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintConsole("Indexer入门");
            {
                PrintConsole("简单例子");
                Employee employee = new Employee();
                employee[0] = "testName";
                employee[1] = "testAge";
                employee[2] = "testSex";
                PrintConsole(nameof(employee.Name) + "\t" + employee[0]);
                PrintConsole(nameof(employee.Age) + "\t" + employee[1]);
                PrintConsole(nameof(employee.Sex) + "\t" + employee[2]);
                PrintConsole("简单例子结束");
            }
            {
                PrintConsole("常用的索引器介绍");
                MyArrayList<int> myInt = new MyArrayList<int>();
                myInt[0] = 10;
                myInt[1] = 20;
                myInt[2] = 30;
                myInt[3] = 40;
                for(var i = 0; i < myInt.Count; i++)
                {
                    PrintConsole(myInt[i].ToString());
                }
                PrintConsole("常用索引器介绍结束");

            }
            PrintConsole("Indexer结束");
        }

        static void PrintConsole(string msg)
        {
            Console.WriteLine($"--------------------------{msg}--------------------------");
            
        }
    }

    /// <summary>
    /// 自定义实现一个ArrayList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyArrayList<T>
    {
        private T[] _items;
        private int _size;
        private int _index;

        public int Count => this._size;

        public MyArrayList()
        {
            _size = 4;
            _items = new T[_size];
            _index = 0;
        }

        public MyArrayList(int size)
        {
            _size = size;
            _items = new T[_size];
            _index = 0;
        }

        //加上索引。
        public T this[int index]
        {
            set {
                if (index >= _size||index<0)
                {
                    throw new IndexOutOfRangeException();
                }
                _items[index] = value;
                _index++;
            }
            get
            {
                if (index >= _size || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _items[index];
               
            }
        }




    }



    public class Employee {
        public string Name { get; set; }

        public string Age { get; set; }

        public string Sex { get; set; }

        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.Name;
                    case 1:
                        return this.Age;
                    case 2:
                        return this.Sex;
                }
                return "";
               
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Name = value;
                        break;
                    case 1:
                        Age = value;
                        break;
                    case 2:
                        Sex = value;
                        break;
                }
            }
        }


    }

}

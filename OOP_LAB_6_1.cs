using System;
using System.IO;

namespace Pasha_OOP_6
{
    interface IBus
    {
        int Number(Hour[] m);
        void MinHour();
        void MaxComent();
    }

    abstract public class Bus : IBus
    {
        public string name;
        public string number;

        abstract public int Number(Hour[] m);
        abstract public void MinHour();
        abstract public void MaxComent();


    }
    public class Hour : Bus
    {

        public int host;
        public string coment;
        public Hour(string name, string number, int host, string coment)
        {
            this.name = name;
            this.number = number;

            this.host = host;
            this.coment = coment;
        }
        public override int Number(Hour[] m)
        {
            int n = 0;
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != null)
                {
                    n += m[i].host;
                }
            }
            Console.WriteLine("Загальна кількість пасажирів: {0}", n);
            return n;
        }
        public override void MinHour()
        {
            int min = Program.visit[0].host;
            int index = 0;

            for (int i = 0; i < Program.visit.Length; i++)
            {
                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].host < min)
                    {
                        min = Program.visit[i].host;
                        index = i;

                    }
                }
            }
            Console.WriteLine("година з найменшою кількістю пасажирів: {0}", index + 1);
            Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-15}", Program.visit[index].name, Program.visit[index].number, Program.visit[index].host, Program.visit[index].coment);

        }
        public override void MaxComent()
        {
            int max = Program.visit[0].coment.Length;
            int index = 0;
            for (int i = 0; i < Program.visit.Length; i++)
            {
                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].coment.Length > max)
                    {
                        max = Program.visit[i].coment.Length;
                        index = i;
                    }
                }
            }
            Console.WriteLine("найдовший коментар: {0}", Program.visit[index].coment);

        }
        public static void Add()
        {
            Console.WriteLine("Введiть данi");

            Console.Write("Назва: ");
            string str = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", str);

            Console.Write("Номери: ");
            string URL1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", URL1);

            Console.Write("Кількість: ");
            string ddate = Console.ReadLine();

            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", ddate);

            Console.Write("Коментар: ");
            string host1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", host1);



            Output.Write(Program.visit);

            Input.Key();

        }

        public static void Remove()
        {
            Console.Write("Назва: ");

            string name = Console.ReadLine();

            bool[] write = new bool[Program.visit.Length];

            for (int i = 0; i < Program.visit.Length; ++i)
            {
                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].name == name)
                    {
                        Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-15}", Program.visit[i].name, Program.visit[i].number, Program.visit[i].host, Program.visit[i].coment);

                        Console.WriteLine("Видалити? (Y/N)\n");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {

                            Program.visit[i] = null;
                            Program.delete[i] = true;
                            Output.Write(Program.visit);



                        }
                        else
                        {
                            Program.delete[i] = false;
                        }
                    }
                }
            }
        }

        public static void Edit()
        {

            Console.Write("Назва: ");

            string singer = Console.ReadLine();

            bool[] write = new bool[Program.visit.Length];

            for (int i = 0; i < Program.visit.Length; ++i)
            {
                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].name == singer)
                    {
                        Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-15}", Program.visit[i].name, Program.visit[i].number, Program.visit[i].host, Program.visit[i].coment);

                        Console.WriteLine("Введiть нову iнформацiю");

                        string str = Console.ReadLine();

                        string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        Program.visit[i] = new Hour(elements[0], elements[1], int.Parse(elements[2]), elements[3]);
                    }
                }
            }



        }




        private static void Save(Hour m)
        {
            StreamWriter save = new StreamWriter("text.txt", true);

            save.WriteLine(m.name);
            save.WriteLine(m.number);

            save.WriteLine(m.host);
            save.WriteLine(m.coment);

            save.Close();
        }

        public static void Parse(string[] elements, bool save)
        {
            int counter = 0;

            while (Program.visit[counter] != null)
            {
                ++counter;
            }

            for (int i = 0; i < elements.Length; i += 4)
            {
                Program.visit[counter + i / 4] = new Hour(elements[i], elements[i + 1], int.Parse(elements[i + 2]), elements[i + 3]);

                if (save)
                {
                    Save(Program.visit[counter + i / 4]);
                }
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }

    }

    class Output
    {
        public static void Write(Hour[] v)
        {


            for (int i = 0; i < v.Length; ++i)
            {
                if (v[i] != null)
                {
                    Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-15} ", Program.visit[i].name, Program.visit[i].number, Program.visit[i].host, Program.visit[i].coment);
                }
            }
        }
    }
    class Input
    {


        public static void Key()
        {
            Hour.Parse(Read(), false);

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("година з найменшою кількістю пасажирів: F");
            Console.WriteLine("найдовший коментар: S");
            Console.WriteLine("Загальна кількість пасажирів: K");
            Console.WriteLine("Виведення записiв: Enter");

            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    Hour.Add();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    Hour.Edit();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    Hour.Remove();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    Output.Write(Program.visit);
                    Key();
                    break;
                case ConsoleKey.F:
                    Console.WriteLine();
                    Program.visit[0].MinHour();
                    break;
                case ConsoleKey.S:
                    Console.WriteLine();
                    Program.visit[0].MaxComent();
                    break;
                case ConsoleKey.K:
                    Console.WriteLine();
                    Program.visit[0].Number(Program.visit);
                    break;



                case ConsoleKey.Escape:
                    return;
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }
    }



    class Program
    {
        public static Hour[] visit = new Hour[1000000];
        public static bool[] delete = new bool[1000000];
        static void Main(string[] args)
        {
            Input.Key();
        }
    }
}
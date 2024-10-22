namespace TjuvOchPolis
{
    internal class Program
    {
        static int rånadeMedbrogare = 0;
        static int arresteradeTjuvar = 0;

        static void Main(string[] args)
        {
            int medborgare = 30;
            int tjuvar = 20;
            int poliser = 10;

            int stadensBredd = 75;
            int stadensHöjd = 25;

            Fängelse fängelse = new Fängelse();

            List<Person> personer = new List<Person>();

            for (int i = 0; i < medborgare; i++)
            {
                personer.Add(new Medborgare());
            }

            for (int i = 0; i < tjuvar; i++)
            {
                personer.Add(new Tjuv());
            }

            for (int i = 0; i < poliser; i++)
            {
                personer.Add(new Polis(fängelse));
            }

            while (true)
            {
                foreach (var person in personer)
                {
                    person.Move(stadensBredd, stadensHöjd);
                }

                fängelse.TjuvenRörSig(personer, stadensBredd, stadensHöjd);

                SeStaden(personer, stadensBredd, stadensHöjd);

                for (int i = 0; i < personer.Count; i++)
                {
                    for (int j = i + 1; j < personer.Count; j++)
                    {
                        if (personer[i].X == personer[j].X && personer[i].Y == personer[j].Y)
                        {
                            HanteraMöte(personer[i], personer[j]);
                        }
                    }

                }

                VisaStatistik();

                fängelse.VisaFängelse();

                Thread.Sleep(200);
            }
        }

        static void HanteraMöte(Person person1, Person person2)
        {
            switch (person1, person2)
            {
                case (Polis polis, Tjuv tjuv):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Polis tar tjuv!");
                    polis.Arrestera(tjuv);
                    arresteradeTjuvar++;
                    Thread.Sleep(1000);
                    break;

                case (Tjuv tjuv, Polis polis):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Polis tar tjuv!");
                    polis.Arrestera(tjuv);
                    arresteradeTjuvar++;
                    Thread.Sleep(1000);
                    break;

                case (Tjuv tjuv, Medborgare medborgare):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Tjuv rånar medborgare!");
                    Item stulenSak = tjuv.StjälFrån(medborgare);
                    if (stulenSak != null)
                    {
                        Console.WriteLine($"Tjuven stal: {stulenSak.Name}");
                        rånadeMedbrogare++;
                    }
                    Thread.Sleep(1000);
                    break;

                case (Medborgare medborgare, Tjuv tjuv):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Tjuv rånar medborgare!");
                    Item stulenSak1 = tjuv.StjälFrån(medborgare);
                    if (stulenSak1 != null)
                    {
                        Console.WriteLine($"Tjuven stal: {stulenSak1.Name}");
                        rånadeMedbrogare++;
                    }
                    Thread.Sleep(1000);
                    break;

                case (Polis polis, Medborgare medborgare):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Medborgare möter polis, inget händer.");
                    Thread.Sleep(1000);
                    break;

                case (Medborgare medborgare, Polis polis):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Medborgare möter polis, inget händer.");
                    Thread.Sleep(1000);
                    break;

            }
        }

        static void SeStaden(List<Person> personer, int bredd, int höjd)
        {
            for (int y = 0; y < höjd; y++)
            {
                for (int x = 0; x < bredd; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write('.');
                    Console.ResetColor();
                }  
            }

            foreach (var person in personer)
            {
                Console.SetCursorPosition(person.X, person.Y);

                if (person is Polis)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (person is Medborgare)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (person is Tjuv)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(person.Symbol());
                Console.ResetColor();
            }
        }

        static void VisaStatistik()
        {
            Console.SetCursorPosition(0, 29);
            Console.WriteLine($"Antal rånade medborgare: {rånadeMedbrogare}");
            Console.SetCursorPosition(0, 30);
            Console.WriteLine($"Antal gripna tjuvar: {arresteradeTjuvar}");
        }
    }
}

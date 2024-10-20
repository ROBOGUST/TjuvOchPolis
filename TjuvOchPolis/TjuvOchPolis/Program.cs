namespace TjuvOchPolis
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int medborgare = 30;
            int tjuvar = 30;
            int poliser = 30;

            int stadensBredd = 75;
            int stadensHöjd = 25;

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
                personer.Add(new Polis());
            }

            while (true)
            {
                foreach (var person in personer)
                {
                    person.Move(stadensBredd, stadensHöjd);
                }

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

                Thread.Sleep(500);
                Console.Clear();
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
                    Thread.Sleep(1000);
                    break;

                case (Tjuv tjuv, Polis polis):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Polis tar tjuv!");
                    polis.Arrestera(tjuv);
                    Thread.Sleep(1000);
                    break;
                case (Tjuv tjuv, Medborgare medborgare):
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Tjuv rånar medborgare!");
                    Item stulenSak = tjuv.StjälFrån(medborgare);
                    if (stulenSak != null)
                    {
                        Console.WriteLine($"Tjuven stal: {stulenSak.Name}");
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

            }/*
            if (person1 is Polis polis && person2 is Tjuv tjuv)
            {
                Console.SetCursorPosition(0, 26);
                Console.WriteLine("Polis tar tjuv!");
                polis.Arrestera(tjuv);
                Thread.Sleep(1000);
            }
            else if (person1 is Tjuv tjuv1 && person2 is Polis polis1) 
            {
                Console.SetCursorPosition(0, 26);
                Console.WriteLine("Polis tar tjuv!");
                polis1.Arrestera(tjuv1);
                Thread.Sleep(1000);
            }
            if (person1 is Tjuv tjuv2 && person2 is Medborgare medborgare)
            {
                Console.SetCursorPosition(0, 26);
                Console.WriteLine("Tjuv rånar medborgare!");
                Item stulenSak = tjuv2.StjälFrån(medborgare);
                if (stulenSak != null)
                {
                    Console.WriteLine($"Tjuven stal: {stulenSak.Name}");
                }
                Thread.Sleep(1000);
            }
            else if (person1 is Medborgare medborgaren && person2 is Polis polisen)
            {
                Console.SetCursorPosition(0, 26);
                Console.WriteLine("Medborgare möter polis, inget händer.");
                Thread.Sleep(1000);
            }*/
        }

        static void SeStaden(List<Person> personer, int bredd, int höjd)
        {
            for (int y = 0; y < höjd; y++)
            {
                for (int x = 0; x < bredd; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('.');
                }
            }

            foreach (var person in personer)
            {
                Console.SetCursorPosition(person.X, person.Y);
                Console.Write(person.Symbol());
            }
        }
    }
}

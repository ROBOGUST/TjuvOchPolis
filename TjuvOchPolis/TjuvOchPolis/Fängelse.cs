using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Fängelse
    {
        private List<Tjuv> arresteradeTjuvar = new List<Tjuv>();

        private const int maxFängelsetid = 5;

        private int fängelseHöjd = 10;
        private int fängelseBredd = 10;

        public void ArresteraTjuv(Tjuv tjuv)
        {
            arresteradeTjuvar.Add(tjuv);
            tjuv.X = new Random().Next(0, fängelseBredd);
            tjuv.Y = new Random().Next(0, fängelseHöjd);

            tjuv.NollställFängelsetid();
        }

        public void TjuvenRörSig(List<Person> personer, int stadensBredd, int stadensHöjd)
        {
            for (int i = arresteradeTjuvar.Count - 1; i >= 0; i--)
            {
                var tjuv = arresteradeTjuvar[i];

                tjuv.ÖkaFängelsetid();

                if (tjuv.Fängelsetid >= maxFängelsetid)
                {
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine("Tjuv släpps från fängelse!");

                    tjuv.X = new Random().Next(0, stadensBredd);
                    tjuv.Y = new Random().Next(0, stadensHöjd);
                    arresteradeTjuvar.RemoveAt(i);
                    personer.Add(tjuv);
                }
                else
                {
                    tjuv.Move(fängelseBredd, fängelseHöjd);
                }
            }
        }

        public void VisaFängelse()
        {
            Console.SetCursorPosition(85, 0);
            Console.WriteLine("Fängelse:");
            for (int y = 0; y < fängelseHöjd; y++)
            {
                for (int x = 0; x < fängelseBredd; x++)
                {
                    Console.SetCursorPosition(95 + x, y);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write('.');
                    Console.ResetColor();
                }
            }

            foreach (var tjuv in arresteradeTjuvar)
            {
                Console.SetCursorPosition(95 + tjuv.X, tjuv.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('T');
                Console.ResetColor();
            }

            Thread.Sleep(1000);
        }
    }
}

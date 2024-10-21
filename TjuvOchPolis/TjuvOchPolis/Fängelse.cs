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
        private int fängelseHöjd = 10;
        private int fängelseBredd = 15;

        public void ArresteraTjuv(Tjuv tjuv)
        {
            arresteradeTjuvar.Add(tjuv);
            tjuv.X = new Random().Next(0, fängelseBredd);
            tjuv.Y = new Random().Next(0, fängelseHöjd);
        }

        public void TjuvenRörSig() 
        {
            foreach (var tjuv in arresteradeTjuvar)
            {
                tjuv.Move(fängelseBredd, fängelseHöjd);
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
                    Console.Write('.');
                }
            }

            foreach (var tjuv in arresteradeTjuvar)
            {
                Console.SetCursorPosition(95 + tjuv.X, tjuv.Y);
                Console.Write('T');
            }

            Thread.Sleep(1000);
        }
    }
}

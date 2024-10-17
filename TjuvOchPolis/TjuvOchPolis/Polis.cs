using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Polis : Person
    {
        public override char Symbol()
        {
            return 'P';
        }

        public void Arrestera(Tjuv tjuv)
        {
            foreach (var item in tjuv.Inventory)
            {
                Inventory.Add(item);
            }
            tjuv.Inventory.Clear();
        }
    }
}

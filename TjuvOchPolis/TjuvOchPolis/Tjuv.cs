using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Tjuv : Person
    {
        public override char Symbol()
        {
            return 'T';
        }

        public Item StjälFrån(Medborgare medborgare) 
        {
            Random rnd = new Random();
            if (medborgare.Inventory.Count > 0)
            {
                int index = rnd.Next(0, medborgare.Inventory.Count);
                Item stulenSak = medborgare.Inventory[index];
                Inventory.Add(stulenSak);
                medborgare.Inventory.RemoveAt(index);
                return stulenSak;
            }
            return null;
        }
    }
}

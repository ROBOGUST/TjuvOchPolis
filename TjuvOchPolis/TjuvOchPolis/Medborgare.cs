using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Medborgare : Person
    {
        public Medborgare() 
        {
            Inventory.Add(new Item("Nycklar"));
            Inventory.Add(new Item("Mobiltelefon"));
            Inventory.Add(new Item("Pengar"));
            Inventory.Add(new Item("Klocka"));
        }

        public override char Symbol()
        {
            return 'M';
        }
    }
}

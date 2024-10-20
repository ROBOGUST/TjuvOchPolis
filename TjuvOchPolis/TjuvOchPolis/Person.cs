using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public abstract class Person
    {
        public int X {  get; set; } 
        public int Y {  get; set; }
        public int XDirection {  get; set; }
        public int YDirection {  get; set; }

        public List<Item> Inventory { get; set; } = new List<Item>();

        private static Random rnd = new Random();

        //Starting position
        public Person() 
        {
            X = rnd.Next(0, 100);
            Y = rnd.Next(0, 25);
            SetRandomDirection();
        }

        //Setting random moving directions
        public void SetRandomDirection()
        {
            int[] directions = { -1, 0, 1 };
            XDirection = directions[rnd.Next(0, directions.Length)];
            YDirection = directions[rnd.Next(0, directions.Length)];
        }

        //Keeping Person inside the "box"
        public void Move(int maxX, int maxY)
        {
            X += XDirection;
            Y += YDirection;

            if (X < 0) X = maxX - 1;
            if (X >= maxX) X = 0;

            if (Y < 0) Y = maxY - 1;
            if (Y >= maxY) Y = 0;
        }

        //Preperation for Persons char id to see on screen
        public abstract char Symbol();
    }
}

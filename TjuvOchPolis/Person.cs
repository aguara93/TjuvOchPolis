﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Person
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }

        public Person(string name, int x, int y, int xDirection, int yDirection)
        {
            Name = name;
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
        }
        public virtual void Move(int width, int height)
        {
            X += XDirection;
            Y += YDirection;

            if (X < 0) X = width - 1;
            else if (X >= width) X = 0;

            if (Y < 0) Y = height - 1;
            else if (Y >= height) Y = 0;
        }
        public virtual char GetSymbol()
        {
            return ' ';
        }

        public class Police : Person
        {
            public List<Thing> Inventory { get; set; }

            public Police(string name, int x, int y, int xDirection, int yDirection)
       : base(name, x, y, xDirection, yDirection)
            {
                Inventory = new List<Thing>();
            }

            public override char GetSymbol()
            {
                return 'P';
            }
        }

        public class Thief : Person
        {
            public List<Thing> Inventory { get; set; }

            public Thief(string name, int x, int y, int xDirection, int yDirection)
                : base(name, x, y, xDirection, yDirection)
            {
                Inventory = new List<Thing>();
            }

            public Thing Steal()
            {
                return new Thing("Stolen Item");
            }

            public override char GetSymbol()
            {
                return 'T';
            }
        }
        public class Citizen : Person
        {
            public List<Thing> Inventory { get; set; }

            public Citizen(string name, int x, int y, int xDirection, int yDirection)
                : base(name, x, y, xDirection, yDirection)
            {
                Inventory = new List<Thing>
        {
            new Thing("Keys"),
            new Thing("Phone"),
            new Thing("Money"),
            new Thing("Watch")
        };
            }
            public Thing Steal()
            {
                if (Inventory.Count == 0) return null;
                Random random = new Random();
                int index = random.Next(Inventory.Count);
                Thing stolenItem = Inventory[index];
                Inventory.RemoveAt(index);
                return stolenItem;
            }
            public override char GetSymbol()
            {
                return 'C';
            }
        }
    }
}

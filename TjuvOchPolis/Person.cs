using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    //skapar basklassen for person
    public class Person
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }

        //konstruktor for att initiera gemensamma egenskaper
        public Person(string name, int x, int y, int xDirection, int yDirection)
        {
            Name = name;
            X = x;
            Y = y;
            XDirection = xDirection;
            YDirection = yDirection;
        }
        //skapar metoden for personer att flytta pa staden
        public void Move(int width, int height)
        {
            X += XDirection;
            Y += YDirection;
            //om en person gor utanfor stadens grans da kommer fran andra sidan
            if (X < 0) X = width - 1;
            else if (X >= width) X = 0;

            if (Y < 0) Y = height - 1;
            else if (Y >= height) Y = 0;
        }
        //skapar metoden som hamtar en symbol for personen
        public virtual char GetSymbol()
        {
            return ' ';
        }

        //subklassen som representerar polis
        public class Police : Person
        {
            public List<Thing> ConfiscatedStuff { get; set; }
            //konstruktor for att initiera polisens egenskaper
            public Police(string name, int x, int y, int xDirection, int yDirection) 
                : base(name, x, y, xDirection, yDirection)
            {
                ConfiscatedStuff = new List<Thing>();
            }
            public override char GetSymbol()
            {
                return 'P';
            }
        }
        //subklassen for tjuv
        public class Thief : Person
        {
            public List<Thing> StolenStuff { get; set; }
            //konstruktor
            public Thief(string name, int x, int y, int xDirection, int yDirection)
                : base(name, x, y, xDirection, yDirection)
            {
                StolenStuff = new List<Thing>();
            }
            //metoden vad gor tjuv med saker fran Inventory nar traffar medborgare
           
            public override char GetSymbol()
            {
                return 'T';
            }
        }
        //subklassen for medborgiaren
        public class Citizen : Person
        {
            public List<Thing> Belongings { get; set; }

            public Citizen(string name, int x, int y, int xDirection, int yDirection)
                : base(name, x, y, xDirection, yDirection)
            {
                Belongings = new List<Thing>
        {
            //medborgares inventory
            new Thing("Keys"),
            new Thing("Phone"),
            new Thing("Money"),
            new Thing("Watch")
        };
            }
            //metoden vad hander med citizen's inventory nar treffar han tjuven
            public Thing Steal()
            {
                if (Belongings.Count == 0) return null; //om inga tillhorigheter returnerar null
                Random random = new Random(); //skapar ett nytt Random objekt
                int index = random.Next(Belongings.Count); //valjer en slumpmassig sak
                Thing stolenItem = Belongings[index]; //hamtar stulna saken
                Belongings.RemoveAt(index); //tar bort en sak fran medborgarens tillhorigheter
                return stolenItem; //returnerar den stulna saken
            }
            public override char GetSymbol()
            {
                return 'C';
            }
        }
    }
}


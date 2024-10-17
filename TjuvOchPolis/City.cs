using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class City
    {
        public int Width;
        public int Height;
        public List<Person> People;

        public City(int width, int height, List<Person> people)
        {
            Width = width;
            Height = height;
            People = people;
        }
        public void AddPerson(Person person)
        {
            People.Add(person);
        }
        public void ManageCity()
        {
            while (true)
            {
                Console.Clear();
                ShowCity();
                MovePeople();
            }
        }
        //skapar metoden som visar staden i konsolen
        public void ShowCity()
        {
            //skapar 2D array som stadsgranser
            char[,] cityBorders = new char[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cityBorders[x, y] = ' ';
                }
            }

            foreach (Person person in People)
            {
                if (person.X >= 0 && person.X < Width && person.Y >= 0 && person.Y < Height)
                {
                    cityBorders[person.X, person.Y] = person.GetSymbol();
                }
            }

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                    Console.WriteLine(cityBorders[x, y]);
                Console.WriteLine();
            }
        }
        public void MovePeople()
        {
            foreach (Person person in People)
                person.Move(Width, Height);
        }
    }
}

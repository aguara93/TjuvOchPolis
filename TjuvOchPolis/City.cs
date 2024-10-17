using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    //skapar klass for staden
    public class City
    {
        public int Width; //stadens bredd
        public int Height; //stadens hojd
        public List<Person> People; //lista med personer i staden

        //konstruktorn for att initiera stadens egenskaper
        public City(int width, int height, List<Person> people)
        {
            Width = width;
            Height = height;
            People = people;
        }
        //metoden for att lagga till en person i staden
        public void AddPerson(Person person)
        {
            People.Add(person);
        }
        //metoden for att simulera vad hander i staden
        public void CityLife()
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

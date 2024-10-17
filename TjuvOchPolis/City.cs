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
    }
}

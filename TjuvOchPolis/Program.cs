using static TjuvOchPolis.Person;
using System;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City city = new City(100, 25);

            for (int i = 0; i < 10; i++)
                city.AddPerson(new Police($"Police-{i}", RandomPosition(city.Width), RandomPosition(city.Height), random.Next(-1, 2), random.Next(-1, 2)));
            for (int i = 0; i < 20; i++)
                city.AddPerson(new Thief($"Thief-{i}", RandomPosition(city.Width), RandomPosition(city.Height), random.Next(-1, 2), random.Next(-1, 2)));
            for (int i = 0; i < 30; i++)
                city.AddPerson(new Citizen($"Citizen-{i}", RandomPosition(city.Width), RandomPosition(city.Height), random.Next(-1, 2), random.Next(-1, 2)));

            city.ManageCity();
        }
    }
}

using static TjuvOchPolis.Person;
using System;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City city = new City(100, 25);

            List<string> policeNames = new List<string>()
            {
                "Dan", "Ben", "Tom", "Kim", "Tess", "Anna", "Mike", "Bill", "Alice", "Lea"
            };
            List<string> thiefNames = new List<string>()
            {
                "Bob", "Ellie", "Sara", "Bea", "Tea", "Alan", "Olaf", "Mia", "Rob", "Sam",
                "Lena", "Kate", "Affe", "Bosse", "Nisse", "Nick", "Blop", "Titi", "Sasha", "Masha"
            };
            List<string> citizenNames = new List<string>()
            {
                "Emma", "Isabella", "Ava", "Noah", "Liam", "Henry", "Oliver", "Olivia", "Max", "Alex",
                "Pia", "Kallu", "Abbe", "Monik", "Panik", "Gandalf", "Frodo", "Legolas", "Gimli", "Gollum",
                "Aragorn", "Geralt", "Yen", "Ciri", "Zoltan", "Zorro", "Garcia", "Mufasa", "Simba", "Zazu"
            };

            CreatePeople(city, policeNames, thiefNames, citizenNames, 10, 20, 30);

            city.CityLife();
        }
        //metoden att skapa manniskor i staden
        static void CreatePeople(City city, List<string> policeNames, List<string> thiefNames, List<string> citizenNames, int policeCount, int thiefCount, int citizenCount)
        {
            Random random = new Random();

            for (int i = 0; i < policeCount; i++)
            {
                int index = random.Next(policeNames.Count);
                string name = policeNames[index];
                policeNames.RemoveAt(index);

                int xDirection = random.Next(0, 2) == 0 ? 1 : -1; //ga vanster eller hoger
                int yDirection = random.Next(0, 2) == 0 ? 1 : -1; //ga upp eller ner

                city.AddPerson(new Person.Police(name, random.Next(0, city.Width), random.Next(0, city.Height), random.Next(-1, 2), random.Next(-1, 2)));
            }
            for (int i = 0; i < thiefCount; i++)
            {
                int index = random.Next(thiefNames.Count);
                string name = thiefNames[index];
                thiefNames.RemoveAt(index);

                int xDirection = random.Next(0, 2) == 0 ? 1 : -1; //ga vanster eller hoger
                int yDirection = random.Next(0, 2) == 0 ? 1 : -1; //ga upp eller ner

                city.AddPerson(new Person.Thief(name, random.Next(0, city.Width), random.Next(0, city.Height), random.Next(-1, 2), random.Next(-1, 2)));
            }
            for (int i = 0; i < citizenCount; i++)
            {
                int index = random.Next(citizenNames.Count);
                string name = citizenNames[index];
                citizenNames.RemoveAt(index);

                int xDirection = random.Next(0, 2) == 0 ? 1 : -1; //ga vanster eller hoger
                int yDirection = random.Next(0, 2) == 0 ? 1 : -1; //ga upp eller ner

                city.AddPerson(new Person.Citizen(name, random.Next(0, city.Width), random.Next(0, city.Height), random.Next(-1, 2), random.Next(-1, 2)));
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static TjuvOchPolis.Person;

namespace TjuvOchPolis
{
    //skapar klass for staden
    public class City
    {
        public int Width; //stadens bredd
        public int Height; //stadens hojd
        public List<Person> People; //lista med personer i staden
        public int RobbedCitizensCount { get; set; } = 0;
        public int ArrestedThievesCount { get; set; } = 0;

        //konstruktorn for att initiera stadens egenskaper
        public City(int width, int height)
        {
            Width = width;
            width = 100;
            Height = height;
            height = 25;
            People = new List<Person>();
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
                Interactions();
                Thread.Sleep(100);
            }
        }
        //metoden som visar staden
        public void ShowCity()
        {
            //skapar 2D array som stadsgranser
            char[,] cityBorders = new char[Height, Width];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    cityBorders[y, x] = ' '; //fyller granser med tomma utrymmen
                }
            }
            //placerar varje personen i granser
            foreach (Person person in People)
            {
                if (person.X >= 0 && person.X < Width && person.Y >= 0 && person.Y < Height)
                {
                    cityBorders[person.Y, person.X] = person.GetSymbol();
                }
            }
            //ritar granser i konsolen
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                    Console.Write(cityBorders[y, x]);
                Console.WriteLine();
            }
        }
        //metoden for att flytta alla personer i staden
        public void MovePeople()
        {
            foreach (Person person in People)
                person.Move(Width, Height);
        }
        //metoden for att kolla interaktioner mellan alla personer
        public void Interactions()
        {
            for (int i = 0; i < People.Count; i++)
            {
                for (int j = i + 1; j < People.Count; j++)
                {
                    if (People[i].X == People[j].X && People[i].Y == People[j].Y)
                    {
                        HandleInteractions(People[i], People[j]);
                    }

                }
            }
        }
        //metoden att hantera interaktioner mellan tva personer
        public void HandleInteractions(Person p1, Person p2)
        {
            //polisen fangar tjuven
            if (p1 is Police && p2 is Thief)
            {
                Police police = (Police)p1;
                Thief thief = (Thief)p2;
                Console.WriteLine($"Police {police.Name} is catching thief {thief.Name}.");
                List<Thing> stolenItems = thief.StolenStuff;
                police.ConfiscatedStuff.AddRange(stolenItems);
                People.Remove(thief);
                ArrestedThievesCount++;
            }
            //thuv tjuvar fran medborgaren
            else if (p1 is Thief && p2 is Citizen)
            {
                Citizen citizen = (Citizen)p2;
                Thing stolenItem = citizen.Steal();
                if (stolenItem != null)
                {
                    Thief currentThief = (Thief)p1;
                    currentThief.StolenStuff.Add(stolenItem);
                    Console.WriteLine($"Thief {currentThief.Name} is stealing {stolenItem.Name} from citizen {citizen.Name}.");
                    RobbedCitizensCount++;
                }
            }
            else if (p1 is Citizen && p2 is Police)
            {
                Citizen citizen = (Citizen)p1;
                Police police = (Police)p2;
                Console.WriteLine($"{citizen.Name} is greeting police {police.Name}.");
            }
            Console.SetCursorPosition(88, 27);
            Console.WriteLine($"Amount of robbed citizens: {RobbedCitizensCount}");
            Console.SetCursorPosition(88, 28);
            Console.WriteLine($"Amount of arrested thieves: {ArrestedThievesCount}");
            Thread.Sleep(2000);
        }
    }
}

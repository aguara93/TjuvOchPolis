﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    //skapar klassen som representerar en sak 
    public class Thing
    {
        public string Name { get; set; }

        public Thing(string name)
        {
            Name = name; //konstruktor for att satta namnet
        }
    }
}

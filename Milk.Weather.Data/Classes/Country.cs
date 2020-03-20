using System;
using System.Collections.Generic;
using System.Text;

namespace Milk.Weather.Data.Classes
{

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Coord coord { get; set; }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

}

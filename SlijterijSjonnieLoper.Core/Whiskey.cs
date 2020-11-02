using System;
using System.Collections.Generic;
using System.Text;

namespace SlijterijSjonnieLoper.Core
{
    public class Whiskey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public WhiskeyBrand Brand { get; set; }
        public WhiskeyType Type { get; set; }
    }
}

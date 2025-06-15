using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork_1st_course_
{
    public class RealEstate
    {
        public PropertyType Type { get; set; }
        public double Price { get; set; }
        public bool Sold { get; set; }

        public RealEstate() {}

        public RealEstate(PropertyType type, double price, bool sold)
        {
            Type = type;
            Price = price;
            Sold = sold;
        }

        public override string ToString()
        {
            return $"{Type, -10} | {Price, 10} | {(Sold ? "Yes" : "No"),5}";
        }
    }
}

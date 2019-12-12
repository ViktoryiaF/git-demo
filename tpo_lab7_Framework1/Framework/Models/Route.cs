using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Route
    {

        public string ArrivalCity { get; set; }

        public Route(string arrivalCity)
        {
            ArrivalCity = arrivalCity;
        }
    }
}

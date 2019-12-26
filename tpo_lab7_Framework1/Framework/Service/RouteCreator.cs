using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Models;

namespace Framework.Service
{
    public class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("ArrivalCity"));
        }
    }
}

using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    class ErrorsCreator
    {
        public static Errors WithAllPropertiesErrors()
        {
            return new Errors(TestDataReader.GetData("ErrorMessage"));
        }
    }
}

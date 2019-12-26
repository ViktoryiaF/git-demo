using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    class Errors
    {
         public string ErrorMessage { get; set; }
           

        public Errors(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}

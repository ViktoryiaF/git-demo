using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public class UserCreator
    {
        public static User WithAllProperties()
        {
            return new User(TestDataReader.GetData("FirstName"),
                TestDataReader.GetData("LastName"),
                TestDataReader.GetData("Email"),
                TestDataReader.GetData("Password"),
                TestDataReader.GetData("PhoneNumber"));
        }

    }
}

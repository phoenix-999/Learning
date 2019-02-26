using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
namespace SecurityServiceTutorial
{
    public class UserValidator:UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                Console.WriteLine("USER NULL");
                throw new ArgumentNullException();
            }

            if (userName != "yurii" || password != "1")
            {
                Console.WriteLine("NO USER");
                throw new SecurityTokenException("Unknown Username or Password");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using System.ServiceModel;

namespace ServiceLayer
{
    public class EmailPasswordValidator : UserNamePasswordValidator
    {
        private AuthController authController = new AuthController();

        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                authController.Validate(userName, password);
            }
            catch (AuthException e)
            {
                throw new FaultException("Auth exception: " + e.Message, new FaultCode("Auth failed"));
            }
        }
    }
}

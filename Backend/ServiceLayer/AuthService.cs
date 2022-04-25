using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Logic;
using System.ServiceModel;

namespace ServiceLayer
{
    public class AuthService : IAuthService
    {
        private AuthController authCtr = new AuthController();

        public void Login(string email, string password)
        {
            try
            {
                authCtr.Validate(email, password);
            }
            catch (AuthException e)
            {
                throw new FaultException<AuthFault>(new AuthFault(e.Message));
            }
        }

        public void Register(string email, string password, bool isTeacher)
        {
            try
            {
                authCtr.Register(email, password, isTeacher);
            }
            catch (UserCreationException e)
            {
                throw new FaultException<AuthFault>(new AuthFault(e.Message));
            }
            catch (Exception e)
            {
                throw new FaultException<AuthFault>(new AuthFault(e.Message));
            }
        }
    }
}

using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [FaultContract(typeof(AuthFault))]
        void Login(string email, string password);

        [OperationContract]
        [FaultContract(typeof(AuthFault))]
        void Register(string email, string password, bool isTeacher);
    }

    [DataContract]
    public class AuthFault
    {
        [DataMember]
        public string Message { get; set; }

        public AuthFault(string message)
        {
            this.Message = message;
        }
    }
}

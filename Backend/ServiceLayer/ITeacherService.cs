using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        IEnumerable<Teacher> Get();
    }
}

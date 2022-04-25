using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost authHost = new ServiceHost(typeof(AuthService)))
            using (ServiceHost tutorHost = new ServiceHost(typeof(UserService)))
            {
                Console.WriteLine("Opening auth service host...");
                authHost.Open();
                Console.WriteLine("Auth service host ready");
                Console.WriteLine("Opening main service host...");
                tutorHost.Open();
                Console.WriteLine("Main service host ready");
                Console.Beep(700, 90);
                Console.Beep(800, 90);
                Console.Beep(700, 90);
                Console.Beep(800, 90);
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("Services are now ready to accept connections");
                Console.WriteLine("Press ENTER to exit");
                Console.Read();
            }
          
        }
    }
}

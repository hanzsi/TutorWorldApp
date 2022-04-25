using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teszt
{
    class Program
    {
        static void Main(string[] args)
        {
            beg:
            Console.WriteLine("Your username is test!\nNow give me your password!");
            string password = Console.ReadLine();
            Console.WriteLine("One more time!");
            string password2 = Console.ReadLine();
            if (password == password2)
            {
                Console.WriteLine("Good job! You successfully wrote your password 2 times!");
            }
            else
            {
                Console.WriteLine("Try it one more time. You failed it!");
                goto beg;
            }
            
            RegHash x = new RegHash();

            Console.WriteLine("Your password's hashed version is: \n" + x.RegEncrypt(password) + "\n");
            Console.WriteLine("Now! I would like to ask you to write down your password one more time.\n" +
                "This time I'd like to check if the other method works.\n");
            string password3 = Console.ReadLine();
            LogHashCheck y = new LogHashCheck();

            Console.WriteLine("Your password, what you wrote this time is: " + password3 +
                " and the hashed version is: \n" + y.LogEncrypt(password3));

            if (y.LogEncrypt(password3) == x.RegEncrypt(password))
            {
                Console.WriteLine("It's a match!");
            }
            else
            {
                Console.WriteLine("Password incorrect!");
            }
            Console.ReadLine();
        }
    }
}

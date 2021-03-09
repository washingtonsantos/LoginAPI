using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isValid = LoginAPI.EfetuaLogin.SignEmailAndPassword("user_test1", "admin");
        }
    }
}

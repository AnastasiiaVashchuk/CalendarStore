using System;
using System.Collections.Generic;
using Models;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            UserMenu menu = new UserMenu();
            Tuple<string, string> name = menu.register();
            menu.customer = new Customer(name.Item1, name.Item2,new List<Calendar>());
            Console.Clear();
            menu.displayMainMenu();
        }
    }
}
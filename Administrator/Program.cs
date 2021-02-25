using System;
using Administrator;
using Models;

namespace Admonostrator
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminMenu menu = new AdminMenu();
            Tuple<string, string> name = menu.register();
            menu.admin = new Admin(name.Item1, name.Item2);
            Console.Clear();
            menu.displayMainMenu();
        }
    }
}
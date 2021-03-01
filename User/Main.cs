using System;
using System.Collections.Generic;
using Models;

namespace User
{
    public static class Main
    {
        public static void main()
        {
            UserMenu menu = new UserMenu();
            Tuple<string, string> name = menu.register();
            menu.Customer = new Customer(name.Item1, name.Item2, new List<Calendar>());
            menu.displayMainMenu();
        }
    }
}
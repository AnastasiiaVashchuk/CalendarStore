using System;
using Administrator;
using Models;


namespace Administrator
{
    public static  class Main
    {
        public static void main()
        {
            AdminMenu menu = new AdminMenu();
            Tuple<string, string> name = menu.Register();
            menu.Admin = new Admin(name.Item1, name.Item2);
            menu.DisplayMainMenu();
        }
    }
}
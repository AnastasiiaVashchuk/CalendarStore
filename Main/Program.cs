using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Login as:");
            List<string> items = new List<string>()
            {
                "Admin",
                "User"
            };
            int selectedMenuItem = -1;
            int index = 0;
            while (selectedMenuItem == -1)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(items[i]);
                    }
                    else
                    {
                        Console.WriteLine(items[i]);
                    }

                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == items.Count - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = items.Count - 1;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    selectedMenuItem = index;
                    break;
                }
                Console.Clear();
            }

            if (items[selectedMenuItem] == "Admin")
            { 
                
                Console.Clear();
                Administrator.Main.main();

            }
            else
            {
                Console.Clear();
                User.Main.main();
            }

        }
    }
}
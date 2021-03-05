using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Models
{
    public class Menu : IMenu
    {
        public const string calendarsFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\calendars.txt";
        
        public string Switcher(List<string> items, string head = "", bool back = false, bool exit = false, bool iscolor= false)
        {
            Console.Clear();
            if (back && !iscolor)
            {
                items.Add("Back");
            }

            if (exit)
            {
                items.Add("Exit");
            }

            List<string> items2 = new List<string>();
            int index2 = 0;
            if (iscolor)
            {
                items2 = new List<string>()
                {
                    items[0],
                    "Back"
                };
            }
            else
            {
                items2 = items;
            }

            int selectedMenuItem = -1;
            int index = 0;
            while (selectedMenuItem == -1)
            {
                Console.WriteLine("__________________" + head + "__________________");
                for (int i = 0; i < items2.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(items2[i]);
                    }
                    else
                    {
                        Console.WriteLine(items2[i]);
                    }

                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == items2.Count - 1)
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
                        index = items2.Count - 1;
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
                else if (ckey.Key == ConsoleKey.LeftArrow && iscolor && items2[index]!="Back")
                {
                    if (index2 == 0)
                    {
                        index2 = items.Count;
                    }

                    index2--;
                    items2[0] = items[index2];
                }
                else if (ckey.Key == ConsoleKey.RightArrow && iscolor && items2[index]!="Back")
                {
                    if (index2 == items.Count-1)
                    {
                        index2 = -1;
                    }

                    index2++;
                    items2[0] = items[index2];
                }
                Console.Clear();
            }
            return items2[selectedMenuItem];
        }

        public string ShowCatalog()
        {
            Console.Clear();
            List<string> items = new List<string>();
            string head = "catalog";
            int counter = 1;
            string line;
            StreamReader file = new StreamReader(calendarsFilePath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Length > 0)
                {
                    items.Add(counter + "." + line);
                    counter++;
                }

            }
            file.Close();
            string selectedItem = Switcher(items, head, back: true);
            return selectedItem;
        }

        public  Tuple<string, string> Register()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Calendar Store!");
            
            Console.WriteLine("Your first name: ");
            string fname = Console.ReadLine();
            
            Console.WriteLine("Your last name: ");
            string lname = Console.ReadLine();
            
            
            bool isWord1 = Regex.IsMatch( fname, @"^[A-Za-z]+$" );
            bool isWord2 = Regex.IsMatch( lname, @"^[A-Za-z]+$" );
            if (!isWord1 || !isWord2)
            {
                while (true)
                {
                    
                    Console.Write("Please enter valid name");
                    if (Console.ReadKey().Key != null)
                    {
                        Console.Clear();
                        break;
                    }
                }
                Register();
            }
            return new Tuple<string, string>(fname, lname);
        }
    }
}
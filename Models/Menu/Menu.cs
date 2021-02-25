using System;
using System.Collections.Generic;
using System.IO;

namespace Models
{
    public class Menu : IMenu
    {
        public const string calendarsFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\calendars.txt";

        public const string salesHistoryFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\sales_history.txt";
        public const string salesStatisticsFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\sales_statistics.txt";

        public string switcher(List<string> items, string head = "", bool back = false, bool exit = false, bool iscolor= false)
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

            List<string> kek = new List<string>();
            int lol = 0;
            if (iscolor)
            {
                kek = new List<string>()
                {
                    items[0],
                    "Back"
                };
            }
            else
            {
                kek = items;
            }

            int selectedMenuItem = -1;
            int index = 0;
            while (selectedMenuItem == -1)
            {
                Console.WriteLine("__________________" + head + "__________________");
                for (int i = 0; i < kek.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(kek[i]);
                    }
                    else
                    {
                        Console.WriteLine(kek[i]);
                    }

                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == kek.Count - 1)
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
                        index = kek.Count - 1;
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
                else if (ckey.Key == ConsoleKey.LeftArrow && iscolor && kek[index]!="Back")
                {
                    if (lol == 0)
                    {
                        lol = items.Count;
                    }

                    lol--;
                    kek[0] = items[lol];
                }
                else if (ckey.Key == ConsoleKey.RightArrow && iscolor && kek[index]!="Back")
                {
                    if (lol == items.Count-1)
                    {
                        lol = -1;
                    }

                    lol++;
                    kek[0] = items[lol];
                }
                Console.Clear();
            }
            return kek[selectedMenuItem];
        }

        public string showCatalog()
        {
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
            string selectedItem = switcher(items, head, back: true);
            return selectedItem;
        }

        public  Tuple<string, string> register()
        {
            Console.WriteLine("Welcome to Calendar Store!");
            Console.WriteLine("Your first name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Your last name: ");
            string lname = Console.ReadLine();
            return new Tuple<string, string>(fname, lname);
        }
    }
}
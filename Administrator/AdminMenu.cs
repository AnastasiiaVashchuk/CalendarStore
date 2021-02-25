using System;
using System.Collections.Generic;
using System.Drawing;
using Models;


namespace Administrator
{
  public class AdminMenu: Menu
    {
        public Admin admin;
        public AdminMenu(Admin admin=null)
        {
            this.admin = admin;
        }

        public void displayMainMenu()
        {
            List<string> items = new List<string>()
            {
                "catalog",
                "add calendar",
                "statistics",
                "sales history"
            };
            string head = "Main Menu";
            string selectedItem = switcher(items, head, exit: true);
            switch (selectedItem)
            {
                case "catalog":
                    string item=showCatalog();
                    if (item=="Back")
                    {
                        displayMainMenu();
                    }
                    else
                    {
                        deleteCalendar(item);
                    }
                    break;
                case "add calendar":
                    addCalendar();
                    break;
                case "statistics":
                    showStatistics();
                    break;
                case "sales history":
                    showSalesHistory();
                    break;
                case "Back":
                    break;
            }
            
        }

        public void addCalendar()
        {
            Console.WriteLine("__________________Add new Calendar__________________");
            List<string> items = new List<string>();
            Array colors  = Enum.GetValues(typeof(KnownColor));
            foreach(KnownColor knowColor in colors)
            {
                items.Add(knowColor.ToString());
            }
            string selectedColor=switcher(items, "Choose color", back: true, iscolor:true);
            if (selectedColor == "Back")
            {
                displayMainMenu();
            }
            KnownColor color = Color.FromName(selectedColor).ToKnownColor();
            items = new List<string>()
            {
                "cardboard",
                "plastic"
            };
            string selectedMaterial=switcher(items, "Choose material", back: true);
            if (selectedColor == "Back")
            {
                addCalendar();
            }
            string material = selectedMaterial;
            Console.Clear();
            Console.WriteLine("$ Price: ");
            int price = Int32.Parse(Console.ReadLine());
            Calendar calendar = new Calendar(price, material, color);
            Modifier.addCalendar(calendar); 
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Calendar was successfully added to catalog!");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    displayMainMenu();
                    break;
                }
            }
        }

        public void deleteCalendar(string item)
        {
            List<string> items = new List<string>()
            {
                "delete calendar"
            };
            string selected = switcher(items, back: true);
            if (selected == "Back")
            {
                string elem = showCatalog();
                if (elem=="Back")
                {
                    displayMainMenu();
                }
                else
                {
                    deleteCalendar(elem);
                }
                
            }
            else
            {
                item.Split(".");
                Calendar calendar = Calendar.parse(item.Split(".")[1]);
                Modifier.deleteCalendar(calendar);
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Calendar was successfully deleted from catalog!");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break;
                    }
                }
                string elem=showCatalog();
                if (elem=="Back")
                {
                    displayMainMenu();
                }
                else
                {
                    deleteCalendar(elem);
                }
            }
        }

        public void showStatistics()
        {
            string statistics = Modifier.getStatistics();
            while (true)
            {
                Console.Write(statistics);
                if (Console.ReadKey().Key != null)
                {
                    Console.Clear();
                    break;
                }
            }
            displayMainMenu();
        }

        public void showSalesHistory()
        {
            string history = Modifier.getSalesHistory();
            while (true)
            {
                Console.Write(history);
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
            displayMainMenu();
        }
        
    }
}
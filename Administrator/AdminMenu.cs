using System;
using System.Collections.Generic;
using System.Drawing;
using Models;


namespace Administrator
{
  public class AdminMenu: Menu
    {
        private Admin admin;
        
        public AdminMenu(Admin admin=null)
        {
            this.admin = admin;
        }

        public Admin Admin
        {
            get => admin;
            set => admin = value;
        }


        public void displayMainMenu()
        {
            Console.Clear();
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
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
            
        }

        public void addCalendar()
        {
            Console.Clear();
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
            Console.Write("$ Price: ");
            string n = Console.ReadLine();
            int price;
            bool isNumeric = int.TryParse(n, out price);
            while (!isNumeric)
            { 
                Console.WriteLine("Please enter valid value for price");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Console.Write("$ Price: ");
                n = Console.ReadLine();
                isNumeric = int.TryParse(n, out price);
                 
            }
            Calendar calendar = new Calendar(price, material, color);
            admin.addCalendar(calendar); 
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
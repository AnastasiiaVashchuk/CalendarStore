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


        public void DisplayMainMenu()
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
            string selectedItem = Switcher(items, head, exit: true);
            switch (selectedItem)
            {
                case "catalog":
                    string item=ShowCatalog();
                    if (item=="Back")
                    {
                        DisplayMainMenu();
                    }
                    else
                    {
                        DeleteCalendar(item);
                    }
                    break;
                case "add calendar":
                    AddCalendar();
                    break;
                case "statistics":
                    ShowStatistics();
                    break;
                case "sales history":
                    ShowSalesHistory();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
            
        }

        public void AddCalendar()
        {
            Console.Clear();
            Console.WriteLine("__________________Add new Calendar__________________");
            List<string> items = new List<string>();
            Array colors  = Enum.GetValues(typeof(KnownColor));
            foreach(KnownColor knowColor in colors)
            {
                items.Add(knowColor.ToString());
            }
            string selectedColor=Switcher(items, "Choose color", back: true, iscolor:true);
            if (selectedColor == "Back")
            {
                DisplayMainMenu();
            }
            KnownColor color = Color.FromName(selectedColor).ToKnownColor();
            items = new List<string>()
            {
                "cardboard",
                "plastic"
            };
            string selectedMaterial=Switcher(items, "Choose material", back: true);
            if (selectedColor == "Back")
            {
                AddCalendar();
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
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Console.Write("$ Price: ");
                n = Console.ReadLine();
                isNumeric = int.TryParse(n, out price);
                 
            }
            Calendar calendar = new Calendar(price, material, color);
            admin.AddCalendar(calendar); 
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Calendar was successfully added to catalog!");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    DisplayMainMenu();
                    break;
                }
            }
        }

        public void DeleteCalendar(string item)
        {
            Console.Clear();
            List<string> items = new List<string>()
            {
                "delete calendar"
            };
            string selected = Switcher(items, back: true);
            if (selected == "Back")
            {
                string elem = ShowCatalog();
                if (elem=="Back")
                {
                    DisplayMainMenu();
                }
                else
                {
                    DeleteCalendar(elem);
                }
                
            }
            else
            {
                item.Split(".");
                Calendar calendar = Calendar.Parse(item.Split(".")[1]);
                admin.DeleteCalendar(calendar);
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
                string elem=ShowCatalog();
                if (elem=="Back")
                {
                    DisplayMainMenu();
                }
                else
                {
                    DeleteCalendar(elem);
                }
            }
        }
        public void ShowStatistics()
        {
            Console.Clear();
            string statistics = Controller.GetStatistics();
            while (true)
            {
                Console.Write(statistics);
                if (Console.ReadKey().Key != null)
                {
                    Console.Clear();
                    break;
                }
            }
            DisplayMainMenu();
        }

        public void ShowSalesHistory()
        {
            Console.Clear();
            string history = Controller.GetSalesHistory();
            while (true)
            {
                Console.Write(history);
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
            DisplayMainMenu();
        }
        
    }
}
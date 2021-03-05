using System;
using System.Collections.Generic;
using Models;


namespace User
{
    public class UserMenu : Menu
    {
        private Customer customer;

        public Customer Customer
        {   
            get => customer;
            set => customer = value;
        }

        public UserMenu(Customer customer=null)
        {
            this.customer = customer;
        }

     
        public void DisplayMainMenu()
        {
            Console.Clear();
            List<string> items = new List<string>()
            {
                "catalog",
                "cart"
            };
            string head = "Main Menu";
            string selectedItem = Switcher(items, head, exit: true);
            switch (selectedItem)
            {
                case "catalog":
                    string item=ShowCatalog();
                    if (item.Equals("Back"))
                    {
                        DisplayMainMenu();
                    }
                    else
                    {
                        ShowAddToCart(item);
                    }
                    break;
                case "cart":
                    ShowCart();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
        public void ShowAddToCart(string calendar)
        {
            Console.Clear();
            List<string> items = new List<string>()
            {
                "put to cart",
            };
            string selectedItem = Switcher(items, back: true);
            switch (selectedItem)
            {
                case "put to cart":
                    Calendar c=Calendar.Parse(calendar.Split(".")[1]);
                    customer.putToCart(c);
                    Console.Clear();
                    while (true)
                    {
                        Console.Write("Calendar was successfully added to cart!");
                        if (Console.ReadKey().Key != null)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    goto case "Back";
                case "Back":
                    string item=ShowCatalog();
                    if (item=="Back")
                    {
                        DisplayMainMenu();
                    }
                    else
                    {
                        ShowAddToCart(item);
                    }
                    break;
            }
        }
        public void ShowCart()
        {
            Console.Clear();
            string head = "Cart";
            List<string> items = new List<string>();
            if (customer.Cart != null)
            {
                foreach (var calendar in customer.Cart)
                {
                    items.Add(calendar.ToString());
                }
            }

            items.Add("Buy all");
            string selectedItem = Switcher(items, back: true);
            switch (selectedItem)
            {
                case "Back":
                    DisplayMainMenu();
                    break;
                case "Buy all":

                    if (customer.Cart != null && customer.Cart.Count>0)
                    {
                        foreach (var calendar in customer.Cart)
                        {
                            Controller.AddToSalesHistory(calendar, customer);
                        }

                        while (true)
                        {
                            Console.Write("Thank you for purchase!");
                            if (Console.ReadKey().Key != null)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }

                    customer.Cart = new List<Calendar>();
                    ShowCart();
                    break;
                default:
                    ShowDeleteCalendarFromCart(Calendar.Parse(selectedItem));
                    break;
            }
        }

        public void ShowDeleteCalendarFromCart(Calendar calendar)
        {
            Console.Clear();
            List<string> items = new List<string>()
            {
                "delete from"+" cart"
            };
            string selectedItem = Switcher(items, back: true);
            switch (selectedItem)
            {
                case "delete from"+" cart":
                    
                    if (customer.DeleteCalendarFromCart(calendar))
                    {
                        goto case "Back";
                    }
                    break;
                case "Back":
                    ShowCart();
                    break;
            }
            
        }
    }

}
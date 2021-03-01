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

     
        public void displayMainMenu()
        {
            Console.Clear();
            List<string> items = new List<string>()
            {
                "catalog",
                "cart"
            };
            string head = "Main Menu";
            string selectedItem = switcher(items, head, exit: true);
            switch (selectedItem)
            {
                case "catalog":
                    string item=showCatalog();
                    if (item.Equals("Back"))
                    {
                        displayMainMenu();
                    }
                    else
                    {
                        showAddToCart(item);
                    }
                    break;
                case "cart":
                    showCart();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
        public void showAddToCart(string calendar)
        {
            Console.Clear();
            List<string> items = new List<string>()
            {
                "put to cart",
            };
            string selectedItem = switcher(items, back: true);
            switch (selectedItem)
            {
                case "put to cart":
                    Calendar c=Calendar.parse(calendar.Split(".")[1]);
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
                    string item=showCatalog();
                    if (item=="Back")
                    {
                        displayMainMenu();
                    }
                    else
                    {
                        showAddToCart(item);
                    }
                    break;
            }
        }
        public void showCart()
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
            string selectedItem = switcher(items, back: true);
            switch (selectedItem)
            {
                case "Back":
                    displayMainMenu();
                    break;
                case "Buy all":
                    if (customer.Cart != null)
                    {
                        foreach (var calendar in customer.Cart)
                        {
                            Modifier.addToSalesHistory(calendar, customer);
                        }
                    }
                    customer.Cart = new List<Calendar>();
                    showCart();
                    break;
                default:
                    showDeleteCalendarFromCart(Calendar.parse(selectedItem));
                    break;
            }
        }

        public void showDeleteCalendarFromCart(Calendar calendar)
        {
            Console.Clear();
            List<string> items = new List<string>()
            {
                "delete from"+" cart"
            };
            string selectedItem = switcher(items, back: true);
            switch (selectedItem)
            {
                case "delete from"+" cart":
                    
                    if (customer.deleteCalendarFromCart(calendar))
                    {
                        goto case "Back";
                    }
                    break;
                case "Back":
                    showCart();
                    break;
            }
            
        }
    }

}
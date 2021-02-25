using System;
using System.Collections.Generic;
using Models;


namespace User
{
    public class UserMenu : Menu
    {
        public Customer customer;
        public UserMenu(Customer customer=null)
        {
            this.customer = customer;
        }

        public void set(string f,string l)
        {
            
        }
        public void displayMainMenu()
        {
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
                        addToCart(item);
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
        public void addToCart(string calendar)
        {
            List<string> items = new List<string>()
            {
                "put to cart",
            };
            string selectedItem = switcher(items, back: true);
            switch (selectedItem)
            {
                case "put to cart":
                    Calendar c=Calendar.parse(calendar.Split(".")[1]);
                    customer.cart.Add(c);
                    Console.Clear();
                    Console.Write("Calendar was successfully added to cart!");
                    System.Threading.Thread.Sleep(20);
                    goto case "Back";
                case "Back":
                    string item=showCatalog();
                    if (item=="Back")
                    {
                        displayMainMenu();
                    }
                    else
                    {
                        addToCart(item);
                    }
                    break;
            }
        }
        public void showCart()
        {
            string head = "Cart";
            List<string> items = new List<string>();
            if (customer.cart != null)
            {
                foreach (var calendar in customer.cart)
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
                    if (customer.cart != null)
                    {
                        foreach (var calendar in customer.cart)
                        {
                            Modifier.addToSalesHistory(calendar, customer);
                        }
                    }
                    customer.cart = new List<Calendar>();
                    Console.Clear();
                    showCart();
                    break;
                default:
                    deleteCalendarFromCart(Calendar.parse(selectedItem));
                    break;
            }
        }

        public void deleteCalendarFromCart(Calendar calendar)
        {
            List<string> items = new List<string>()
            {
                "delete from"+" cart"
            };
            string selectedItem = switcher(items, back: true);
            switch (selectedItem)
            {
                case "delete from"+" cart":
                    
                    if (customer.cart.Remove(calendar))
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
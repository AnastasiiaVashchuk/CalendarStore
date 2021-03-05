using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer : Person
    {
        private List<Calendar> cart;
        
        public Customer(string fn = "", string ln = "", List<Calendar> cart=null)
            : base(fn, ln)
        {
            this.cart = cart;
        }
        public List<Calendar> Cart
        {
            get => cart;
            set => cart = value;
        }
        
        public override string ToString()
        {
            return base.ToString() + ", "+$"Cart : {cart.Count} calendars";
        }


        public void putToCart(Calendar calendar)
        {
            cart.Add(calendar);
        }

        public bool DeleteCalendarFromCart(Calendar calendar)
        {
            bool isDeleted = false;
            foreach (var clndr in cart)
            {
                if (calendar.ToString().Equals(clndr.ToString()))
                {
                    isDeleted=cart.Remove(clndr);
                    break;
                }
            }
            return isDeleted;
        }
    }
}
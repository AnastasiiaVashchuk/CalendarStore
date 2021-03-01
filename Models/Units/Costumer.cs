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

        public bool deleteCalendarFromCart(Calendar calendar)
        {
            bool isDeleted=cart.Remove(calendar);
            return isDeleted;
        }
    }
}
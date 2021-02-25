using System.Collections.Generic;

namespace Models
{
    public class Customer : Person
    {
        public List<Calendar> cart { get; set; }

        public Customer(string fn = "", string ln = "", List<Calendar> cart=null)
            : base(fn, ln)
        {

            this.cart = cart;
        }
        public override string ToString()
        {
            return base.ToString() + ","+$"Cart : {cart.Count} calendars";
        }
    }
}
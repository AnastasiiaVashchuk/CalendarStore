using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Models
{
    public class Calendar: Unit
    {
        private int price;
        private string material;
        private KnownColor color;

        public Calendar(int price,string material,KnownColor color)
        {
            this.price = price;
            this.material = material;
            this.color = color;
        }
        public int Price
        {
            get => price;
            set => price = value;
        }
        public string Material
        {
            get => material;
            set => material = value;
        }
        public KnownColor Color
        {
            get => color;
            set => color = value;
        }
        
        public static Calendar parse(string str)
        {
            Regex regex = new Regex(@"Color: (\w*)");
            int price;
            string material;
            KnownColor color;
            
            string[] fields = str.Split(", ");
            string[] value1 = fields[0].Split(": ");
            color = System.Drawing.Color.FromName(value1[1]).ToKnownColor();
            string[] value2 = fields[1].Split(": ");
            material = value2[1];
            string[] value3 = fields[2].Split(": ");
            price = Int32.Parse(value3[1]);
            
            return new Calendar(price, material, color);
        }
        

        public override string ToString()
        {
            return $"Color: {color}, Material: {material}, Price $: {price}";
        }
    }
}
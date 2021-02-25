using System;
using System.Drawing;
namespace Models
{
    public class Calendar: Unit
    {
        public int price { get; private set; }
        public string  material { get; private set; }
        public KnownColor color { get;}

        public Calendar(int price,string material,KnownColor color)
        {
            this.price = price;
            this.material = material;
            this.color = color;
        }

        public static Calendar parse(string str)
        {   
            Console.WriteLine(str);
            
            int price;
            string material;
            KnownColor color;
            
            string[] fields = str.Split(", ");
            string[] value1 = fields[0].Split(": ");
            color = Color.FromName(value1[1]).ToKnownColor();
            string[] value2 = fields[1].Split(": ");
            material = value2[1];
            string[] value3 = fields[2].Split(": ");
            price = Int32.Parse(value3[1]);
            
            return new Calendar(price, material, color);
        }
        public override string ToString()
        {
            return $"Color: {color}, Material: {material}, Price: {price}";
        }
    }
}
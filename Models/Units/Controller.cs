using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace Models
{
    public class Controller
    {
        public const string calendarsFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\calendars.txt";
        public const string salesHistoryFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\sales_history.txt";
        public const string incomeFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\income.txt";
        public const string colorFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\colors.txt";
        public const string materialFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\material.txt";
        static CultureInfo culture = new("ru-RU");

        public static void AddToSalesHistory(Calendar calendar,Customer customer)
        {
            DateTime localDate = DateTime.Now;
            string date=localDate.ToString(culture);
            string field = customer+", "+calendar+", "+date+"\n";
            
            //delete calendar from catalog
            string text = File.ReadAllText(calendarsFilePath);
            text = text.Replace(calendar.ToString(), "");
            File.WriteAllText(calendarsFilePath,text);
            
            File.AppendAllText(salesHistoryFilePath, field);
            File.AppendAllText(incomeFilePath, calendar.Price+"\n");
            File.AppendAllText(colorFilePath, calendar.Color+"\n");
            File.AppendAllText(materialFilePath, calendar.Material+"\n");
        }
        
        public static string GetStatistics()
        {   
            string line;
            int totalIncome=0;
            Console.Clear();
            DateTime localDate = DateTime.Now;
            string date = localDate.ToString(culture);
            string statictics;
            StreamReader file = new StreamReader(incomeFilePath);  
            while((line = file.ReadLine()) != null)  
            {
                if (line.Length != 0)
                {
                    totalIncome += Int32.Parse(line);
                }
            } 
            statictics = "Time: " + date + "\n"+"Total income: " + totalIncome+"$" + "\n" + "Statistics by color: " + "\n";
            Dictionary<KnownColor, int> colorsOfSoldCals = new Dictionary<KnownColor, int>();
            file=new StreamReader(colorFilePath);  
            while((line = file.ReadLine()) != null)  
            {
                if (colorsOfSoldCals.ContainsKey(Color.FromName(line).ToKnownColor()))
                {
                    colorsOfSoldCals[Color.FromName(line).ToKnownColor()]++;
                }
                else
                {
                    colorsOfSoldCals[Color.FromName(line).ToKnownColor()]=1;
                }
            }
            foreach (var eKey in colorsOfSoldCals.Keys)
            {
                statictics+=eKey + ": " + colorsOfSoldCals[eKey] + " calendars\n";
            }
            Dictionary<string, int> materialOfSoldCals = new Dictionary<string, int>();
            file=new StreamReader(materialFilePath);  
            while((line = file.ReadLine()) != null)  
            {
                if (materialOfSoldCals.ContainsKey(line) )
                {
                    materialOfSoldCals[line]++;
                }
                else if(line.Length!=0)
                {
                    materialOfSoldCals[line] = 1;
                }
            } 
            statictics+="Statistics by material: " + "\n";

            foreach (var eKey in materialOfSoldCals.Keys)
            {
                if (eKey.Length != 0)
                {
                    statictics += eKey + ": " + materialOfSoldCals[eKey] + " calendars\n";
                }
            }
            return statictics;
        }

        public static string GetSalesHistory()
        {
            string line;
            string content="";
            int counter = 1;
            StreamReader file=new StreamReader(salesHistoryFilePath);
            while ((line = file.ReadLine()) != null)
            {
                content += counter+". "+ line + "\n";
                counter++;
            }
            return content;

        }
    }
}
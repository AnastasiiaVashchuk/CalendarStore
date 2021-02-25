using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using Calendar = System.Globalization.Calendar;

namespace Models
{
    public class Admin: Person
    {
        const string salesHistoryFilePath = ".\\CalendarStore\\CalendarStore\\data\\sales_history.txt";
        const string salesStatisticsFilePath = ".\\CalendarStore\\CalendarStore\\data\\sales_statistics.txt";
        const string calendarsFilePath = ".\\CalendarStore\\CalendarStore\\data\\calendars.txt";
        
        static CultureInfo culture = new("ru-RU");
        
        static int ID=1;
        
        public static int totalIncome;
        
        static Dictionary<KnownColor, int> colorsOfSoldCals = new();
        static Dictionary<string, int> materialOfSoldCals = new();

        public Admin(string fn = "", string ln = "")
            : base(fn, ln)
        {
        }
        public void addCalendar(Calendar calendar)
        {
            File.AppendAllText(calendarsFilePath, calendar.ToString());
        }
        
    }
}
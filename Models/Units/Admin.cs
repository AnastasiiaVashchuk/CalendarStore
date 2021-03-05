using System.IO;
using System.Linq;


namespace Models
{
    public class Admin: Person
    {
        const string calendarsFilePath = "C:\\Users\\Anastasiia\\унік\\НавчальнаПрактика\\CalendarStore\\Models\\data\\calendars.txt";

        public Admin(string fn = "", string ln = "")
            : base(fn, ln)
        {
        }

        public bool DeleteCalendar(Calendar calendar)
        {
            var Lines = File.ReadAllLines(calendarsFilePath);
            var newLines = Lines.Where(line => !line.Contains(calendar.ToString()));
            File.WriteAllLines(calendarsFilePath, newLines);
            return true;
        }

        public bool AddCalendar(Calendar calendar)
        {
            File.AppendAllText(calendarsFilePath, calendar+"\n");
            return true;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Models
{
    public interface IMenu
    {
        public string Switcher(List<string> items, string head,bool back, bool exit,bool iscolor);
        public string ShowCatalog();
        public  Tuple<string,string> Register();
    }
}
using System;
using System.Collections.Generic;

namespace Models
{
    public interface IMenu
    {
        public string switcher(List<string> items, string head,bool back, bool exit,bool iscolor);
        public string showCatalog();
        public  Tuple<string,string> register();
    }
}
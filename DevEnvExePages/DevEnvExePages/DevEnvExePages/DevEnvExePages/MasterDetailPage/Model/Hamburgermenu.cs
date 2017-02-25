using System;

namespace DevEnvExePages
{
    public class Hamburgermenu
    {
        public Hamburgermenu(string menuname,string menuicon, Type navigation)
        {
            MenuName = menuname;
            Navigation = navigation;
            MenuIcon = menuicon;
        }
        public string MenuName
        {
            get;
            set;
        }
        public string MenuIcon
        {
            get;
            set;
        }
        public Type Navigation
        {
            get;
            set;
        }

    }

}

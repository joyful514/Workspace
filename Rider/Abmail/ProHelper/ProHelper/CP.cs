namespace ProHelper
{
    using System;

    public class CP
    {
        public static bool Copyright() => 
            DateTime.Now.Date < Convert.ToDateTime("2023-5-30");
    }
}


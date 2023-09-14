namespace ProHelper
{
    using System;
    using System.Collections.Specialized;

    public class UniqueStringCollection : StringCollection
    {
        public int Add(string value) => 
            base.Contains(value) ? -1 : base.Add(value);

        public void AddRange(string[] value)
        {
            foreach (string str in value)
            {
                if (!base.Contains(str))
                {
                    base.Add(str);
                }
            }
        }
    }
}


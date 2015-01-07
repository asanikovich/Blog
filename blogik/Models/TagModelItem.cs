using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class TagModelItem
    {
        public TagModelItem()
        {
            name = "dog";
            url = "123213";
        }

        public TagModelItem(string n)
        {
            name = n;
            url = "123213";
        }

        public string name { get; set; }
        public string url { get; set; }
    }
}
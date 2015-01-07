using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RCommModelItem
    {
        public RCommModelItem()
        {
            username = "alsan";
            text = "1232132132111111ds";
            url = "123";
            date = DateTime.Now.AddDays(-1);
        }

        public RCommModelItem(string u, string t, string url, DateTime d)
        {
            username = u;
            text = t;
            url = u;
            date = d;
        }

        public string username { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public DateTime date { get; set; }
    }
}
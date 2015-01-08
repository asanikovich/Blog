using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RCommModelItem
    {
        public RCommModelItem(string u, string t, string ur, DateTime d)
        {
            username = u;
            text = t;
            url = ur;
            date = d;
        }

        public string username { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public DateTime date { get; set; }
    }
}
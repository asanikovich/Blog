using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RPostModelItem
    {
        public RPostModelItem()
        {
            name = "post1";
            text = "1232132132111111ds";
            url = "123";
            date = DateTime.Now;
        }

        public string name { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public DateTime date { get; set; }
    }
}
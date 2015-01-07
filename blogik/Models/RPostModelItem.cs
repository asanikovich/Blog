using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RPostModelItem
    {
        public RPostModelItem(string name_, string url_, DateTime date_)
        {
            name = name_;
            url = url_;
            date = date_;
        }

        public RPostModelItem()
        {
            name = "post1";
            url = "123";
            date = DateTime.Now;
        }

        public string name { get; set; }
        public string url { get; set; }
        public DateTime date { get; set; }
    }
}
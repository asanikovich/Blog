using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class del_PostDataModel
    {
        public del_PostDataModel(int id, string n, string t, DateTime d, string u)
        {
            id_post = id;
            name = n;
            text = t;
            date = d;
            url = u;
        }

        public int id_post { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public string url { get; set; }
    }
}
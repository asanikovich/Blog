using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class PostCommentModel
    {
        public PostCommentModel(string u, string t, DateTime d)
        {
            username = u;
            text = t;
            date = d;
        }

        public string username { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
    }
}
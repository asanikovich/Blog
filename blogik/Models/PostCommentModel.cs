using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class PostCommentModel
    {
        public PostCommentModel(int id, string u, string t, DateTime d)
        {
            id_comm = id;
            username = u;
            text = t;
            date = d;
        }

        public int id_comm { get; set; }
        public string username { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class PostCommentModel
    {
        public PostCommentModel()
        {
            username = "admin";
            text = "1232132132111111ds";
            date = DateTime.Now;
        }

        public string username { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
    }
}
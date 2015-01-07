using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class PostModel
    {
        public PostModel()
        {
            name = "dog";
            text = "123213";
            date = DateTime.Now;
        }
        public string name { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }

        public ICollection<PostCommentModel> comments { get; set; }
    }
}
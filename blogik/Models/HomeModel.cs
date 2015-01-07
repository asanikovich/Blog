using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            Post = new PostModel();
            RPost = new RPostModel();
            RComm = new RCommModel();
        }

        public PostModel Post {get; set;}
        public RPostModel RPost { get; set; }
        public RCommModel RComm { get; set; }
    }

}
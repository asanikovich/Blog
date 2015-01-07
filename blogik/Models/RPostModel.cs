using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RPostModel
    {
        public RPostModel()
        {
            items = new Collection<RPostModelItem>();
            items.Add(new RPostModelItem());
            items.Add(new RPostModelItem());
            items.Add(new RPostModelItem());

        }
        public ICollection<RPostModelItem> items { get; set; }
    }
}
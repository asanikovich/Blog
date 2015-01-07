using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class AllPostModel
    {
        public AllPostModel()
        {
            items = new Collection<RPostModelItem>();
            for(int i=0; i<10; i++) {
                items.Add(new RPostModelItem());
            }
        }

        public ICollection<RPostModelItem> items { get; set; }
    }
}
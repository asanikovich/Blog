using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RCommModel
    {
        public RCommModel()
        {
            items = new Collection<RCommModelItem>();
            items.Add(new RCommModelItem());
            items.Add(new RCommModelItem());
            items.Add(new RCommModelItem());

        }

        public ICollection<RCommModelItem> items { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class TagModel
    {
        public TagModel()
        {
            tags = new Collection<TagModelItem>();
            tags.Add(new TagModelItem());
            tags.Add(new TagModelItem("cats") );
            tags.Add(new TagModelItem("dosg") );
        }

        public ICollection<TagModelItem> tags { get; set; }
    }
}
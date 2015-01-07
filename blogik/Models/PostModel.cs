using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class PostModel
    {
        public PostModel()
        {
            name = "Главное сдать сессию";
            text =  "<p>5 способов сдать сессию на «отлично».<br>И пережить экзамены без стресса и бессонных ночей.</p><blockquote>";
            text += "1. Соблюдай диету пятерочника<br>";
            text += "2. Не забывай о режиме дня<br>";
            text += "3. Составь график занятий<br>";
            text += "4. Не отвлекайся на частности<br>";
            text += "5. Настройся на позитив<br></blockquote>";
            date = DateTime.Now;
            comments = new Collection<PostCommentModel>();
            comments.Add(new PostCommentModel());
            comments.Add(new PostCommentModel());
        }
        public string name { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }

        public ICollection<PostCommentModel> comments { get; set; }
    }
}
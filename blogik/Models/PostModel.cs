using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //
using System.Configuration; //

namespace blogik.Models
{
    public class PostModel
    {
        public PostModel()
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format("SELECT TOP(1) name,date,text,id_post FROM post ORDER by date DESC")))
                {
                    query.Connection = DB;
                    using (var reader = query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            name = reader["name"].ToString();
                            text = reader["text"].ToString();
                            date = DateTime.Parse(reader["date"].ToString());
                            id_post = Convert.ToInt32(reader["id_post"].ToString());
                        }                        
                    }
                }
            }

            //name = "Главное сдать сессию";
            //text =  "<p>5 способов сдать сессию на «отлично».<br>И пережить экзамены без стресса и бессонных ночей.</p><blockquote>";
            //text += "1. Соблюдай диету пятерочника<br>";
            //text += "2. Не забывай о режиме дня<br>";
            //text += "3. Составь график занятий<br>";
            //text += "4. Не отвлекайся на частности<br>";
            //text += "5. Настройся на позитив<br></blockquote>";
            //date = DateTime.Now;
            comments = new Collection<PostCommentModel>();
            comments.Add(new PostCommentModel());
            comments.Add(new PostCommentModel());
        }

        public PostModel(string url)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT TOP(1) name,date,text,id_post 
                                        FROM post WHERE url=@url")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("url", url));
                    using (var reader = query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            name = reader["name"].ToString();
                            text = reader["text"].ToString();
                            date = DateTime.Parse(reader["date"].ToString());
                            id_post = Convert.ToInt32(reader["id_post"].ToString());
                        }
                    }
                }
            }

            comments = new Collection<PostCommentModel>();
            comments.Add(new PostCommentModel());
            comments.Add(new PostCommentModel());
        }


        public string name { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public int id_post { get; set; }

        public ICollection<PostCommentModel> comments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class AEditModel
    {
        public AEditModel(int id)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT TOP(1) name,text,date,url,tags
                                                            FROM post WHERE id_post = @id")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("id", id));
                    using (var reader = query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id_post = id;
                            name = reader["name"].ToString();
                            text = reader["text"].ToString();
                            date = DateTime.Parse(reader["date"].ToString());
                            url = reader["url"].ToString();
                            tags = reader["tags"].ToString();
                        }
                    }
                }
            }
        }

        public int id_post { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public string url { get; set; }
        public string tags { get; set; }
    }

    public class AUpdateModel
    {
        public AUpdateModel(int id_post, string name, string text, string url, string tags, DateTime date)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var query = new SqlCommand(String.Format(@"UPDATE post
                                        SET name=@name,text=@text,date=@date,url=@url, tags=@tags
                                        WHERE id_post = @id")))
                {
                    query.Parameters.Add(new SqlParameter("id", id_post));
                    query.Parameters.Add(new SqlParameter("name", name));
                    query.Parameters.Add(new SqlParameter("text", text));
                    query.Parameters.Add(new SqlParameter("date", date));
                    query.Parameters.Add(new SqlParameter("url", url));
                    query.Parameters.Add(new SqlParameter("tags", tags));

                    query.Connection = DB;
                    DB.Open();
                    query.ExecuteNonQuery();
                    urlnew = url;
                    var m1 = new ATagsUpdate(tags, id_post);
                }
            }  
        }

        public string retNewUrl(){
            return urlnew;
        }
        private string urlnew { get; set; }
    }

    public class ATagsUpdate
    {
        public ATagsUpdate(string tags, int id)
        {
            char[] charSeparators = new char[] { ',' };
            string[] tag_mas;
            tag_mas = tags.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                foreach (var item in tag_mas)
                {
                    string item1 = item.Trim();
                    using (var query = new SqlCommand(String.Format(@"INSERT INTO tags (tag_name, id_post)
                                values (@tag, @id_post)")))
                    {
                        query.Connection = DB;
                        query.Parameters.Add(new SqlParameter("tag", item1));
                        query.Parameters.Add(new SqlParameter("id_post", id));
                        query.ExecuteNonQuery();
                    }

                }
            }
        }

    }

}
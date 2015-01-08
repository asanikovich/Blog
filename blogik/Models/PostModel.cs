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
                using (var query = new SqlCommand(String.Format("SELECT TOP(1) name,date,text,id_post,url FROM post ORDER by date DESC")))
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
                            url_now = reader["url"].ToString();
                        }                        
                    }
                }
            }

            CommToPost(id_post);
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
                            url_now = url;
                        }
                    }
                }
            }

            CommToPost(id_post);
        }

        private void CommToPost(int id_post)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                comments = new Collection<PostCommentModel>();
                num_comm = 0;
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT date, username, comm 
                    FROM comment WHERE id_post = @id")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("id", id_post));
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            num_comm++;
                            comments.Add(new PostCommentModel(reader["username"].ToString(), reader["comm"].ToString(), DateTime.Parse(reader["date"].ToString()) ));
                        }
                    }
                }
            }
        }

        public string name { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public int id_post { get; set; }
        public int num_comm { get; set; }
        public string url_now { get; set; }

        public ICollection<PostCommentModel> comments { get; set; }
    }
}
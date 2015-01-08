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
                using (var query = new SqlCommand(String.Format(@"SELECT TOP(1) name,text,date,url
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
                            //UpdateData(item);
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
    }

    public class AUpdateModel
    {
        public AUpdateModel(int id_post, string name, string text, string url, DateTime date)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var query = new SqlCommand(String.Format(@"UPDATE post
                                        SET name=@name,text=@text,date=@date,url=@url 
                                        WHERE id_post = @id")))
                {
                    query.Parameters.Add(new SqlParameter("id", id_post));
                    query.Parameters.Add(new SqlParameter("name", name));
                    query.Parameters.Add(new SqlParameter("text", text));
                    query.Parameters.Add(new SqlParameter("date", date));
                    query.Parameters.Add(new SqlParameter("url", url));

                    query.Connection = DB;
                    DB.Open();
                    query.ExecuteNonQuery();
                    urlnew = url;
                }
            }  
        }

        public string retNewUrl(){
            return urlnew;
        }
        private string urlnew { get; set; }
    }

}
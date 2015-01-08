using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class AddPost
    {
        public AddPost(string name, string text, string url)
        {
            int k = 0;
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT name FROM post WHERE url = @url")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("url", url));
                    using (var reader = query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            k = 1;
                        }
                    }
                }
            }

            if (k == 0) { 
                using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
                {
                    using (var query = new SqlCommand(String.Format(@"INSERT INTO post (name, text, url) values
                                    (@name, @text, @url)")))
                    {
                        query.Parameters.Add(new SqlParameter("name", name));
                        query.Parameters.Add(new SqlParameter("text", text));
                        query.Parameters.Add(new SqlParameter("url", url));
                        query.Connection = DB;
                        DB.Open();
                        query.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
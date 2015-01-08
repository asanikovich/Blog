using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration; //
using System.Data.SqlClient; //
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RCommModel
    {
        public RCommModel() //string u, string t, string url, DateTime d
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                items = new Collection<RCommModelItem>();
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT TOP(3) username, C.date, comm, url 
                                                FROM comment C JOIN post P ON P.id_post=C.id_post
                                                ORDER by C.date DESC" )))
                {
                    query.Connection = DB;
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new RCommModelItem(reader["username"].ToString(), reader["comm"].ToString(), reader["url"].ToString(), DateTime.Parse(reader["date"].ToString())));
                        }
                    }
                }
            }

        }

        public ICollection<RCommModelItem> items { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class RPostModel
    {
        public RPostModel() //RPostModelItem(string name_, string url_, DateTime date_)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                items = new Collection<RPostModelItem>();
                DB.Open();
                using (var query = new SqlCommand(String.Format("SELECT TOP(3) name,date,url FROM post ORDER by date DESC")))
                {
                    query.Connection = DB;
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new RPostModelItem( reader["name"].ToString(), reader["url"].ToString(), DateTime.Parse(reader["date"].ToString()) ));
                        }
                    }
                }
            }

            //items = new Collection<RPostModelItem>();
            //items.Add(new RPostModelItem());
            //items.Add(new RPostModelItem());
            //items.Add(new RPostModelItem());
        }

        public ICollection<RPostModelItem> items { get; set; }
    }
}
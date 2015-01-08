using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class AllPostModel
    {
        private void NumPages()
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                num_pages = 0;
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT COUNT(*) as num FROM post")))
                {
                    query.Connection = DB;
                    using (var reader = query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            num_pages = Convert.ToInt32(reader["num"].ToString() ) ;
                            double t = num_pages / 10.0; ;
                            num_pages = Convert.ToInt32( Math.Ceiling(t) );
                        }
                    }
                }
            }
        }

        public AllPostModel(int page_num)
        {
            NumPages();
            cur_page = page_num;
            items = new Collection<RPostModelItem>();
            int propusk_post = (cur_page-1) * 10;
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT TOP 10 name,date,url
                                                FROM post WHERE id_post NOT IN 
                                                    (SELECT TOP(@propusk_post) id_post FROM post ORDER BY date DESC)
                                                        ORDER BY date DESC")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("propusk_post", propusk_post));
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new RPostModelItem(reader["name"].ToString(), reader["url"].ToString(), DateTime.Parse(reader["date"].ToString())));
                        }
                    }
                }
            }
        }

        public AllPostModel(string search)
        {
            search_t = search.Trim();
            items = new Collection<RPostModelItem>();
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT TOP(50) name,date,url
                                                FROM post WHERE text LIKE @search ORDER BY date DESC")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("search", "%" + search_t + "%"));
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new RPostModelItem(reader["name"].ToString(), reader["url"].ToString(), DateTime.Parse(reader["date"].ToString())));
                        }
                    }
                }
            }
        }

        public ICollection<RPostModelItem> items { get; set; }
        public int num_pages {get; set; }
        public int cur_page { get; set; }
        public string search_t { get; set; }
    }
}
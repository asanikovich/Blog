using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class TagModel
    {
        public TagModel()
        {
            tag_mas = new Collection<string>();
            string tag_name_url;
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT DISTINCT(tag_name) FROM tags")))
                {
                    query.Connection = DB;
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tag_name_url = reader["tag_name"].ToString();
                            tag_mas.Add(tag_name_url);
                        }
                    }
                }
            }
        }

        public ICollection<string> tag_mas { get; set; }
    }

    public class TagNameModel
    {
        public TagNameModel(string tag)
        {
            tagskol = 0;
            items = new Collection<RPostModelItem>();
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT name, url, date
                                                                FROM tags T
                                                                JOIN post P ON P.id_post=T.id_post
                                                                WHERE tag_name=@tag")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("tag", tag));
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tagskol++;
                            items.Add(new RPostModelItem(reader["name"].ToString(), reader["url"].ToString(), DateTime.Parse(reader["date"].ToString())));
                        }
                    }
                    tagname = tag;
                }
            }
        }

        public ICollection<RPostModelItem> items { get; set; }
        public string tagname { get; set; }
        public int tagskol { get; set; }
    }
}
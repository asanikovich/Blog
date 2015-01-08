using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class DelPost
    {
        public DelPost(int id_post)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var query = new SqlCommand(String.Format(@"DELETE FROM post WHERE id_post = @id")))
                {
                    query.Parameters.Add(new SqlParameter("id", id_post));
                    query.Connection = DB;
                    DB.Open();
                    query.ExecuteNonQuery();
                }
            }  
        }
    }

    public class DelComm
    {
        public DelComm(int id_comm)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var query = new SqlCommand(String.Format(@"DELETE FROM comment WHERE id_comm = @id")))
                {
                    query.Parameters.Add(new SqlParameter("id", id_comm));
                    query.Connection = DB;
                    DB.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
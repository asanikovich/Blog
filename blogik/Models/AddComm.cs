using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blogik.Models
{
    public class AddComm
    {
        public AddComm(string name, string comm, string id)
        {
            int id_post = Convert.ToInt32(id);
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {                
                using (var query = new SqlCommand(String.Format(@"INSERT INTO comment 
                    (username, comm, id_post) values(@name, @comm, @id)")))
                {
                    query.Parameters.Add(new SqlParameter("name", name));
                    query.Parameters.Add(new SqlParameter("comm", comm));
                    query.Parameters.Add(new SqlParameter("id", id_post));
                    query.Connection = DB;
                    DB.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
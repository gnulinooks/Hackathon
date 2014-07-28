using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sharester.Services
{
    public class User
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public static User GetUser(string name, bool isAuthenticated)
        {
            if (isAuthenticated)
            {
                
            }

            return null;
        }
    }

    public class UserService
    {
        public static User GetUser(string name)
        {
            try
            {
                using (
                    SqlConnection conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings[Constants.Constants.ConnectionString]
                                .ConnectionString))
                {
                    var query = string.Format("select * from Users where userName  = '{0}'", name);
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        return new User() {Name = reader[2].ToString(), UserId = (Guid) reader[0]};
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}
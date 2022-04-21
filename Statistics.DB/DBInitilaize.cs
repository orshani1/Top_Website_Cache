using Microsoft.Data.SqlClient;
using Statistics.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.DB
{
    public static class DBInitilaize
    {
        public static Random random { get; set; } = new Random();
        public static void Init()
        {


            using (var db = new ApplicationContext())
            {
                if (!db.Websites.Any()) 
                {

                    for (int i = 0; i <= 10000; i++)
                    {
                        var site = new Website()
                        {
                            Adress = $"Https://website{i}.com",
                            Title = $"Website_No {i + 1} ",
                            NumberOfEnters = random.Next(0, 214748364)
                        };
                        db.Websites.Add(site);
                    }
                    db.SaveChanges();
                }
            }
            #region FirstTry
            //    SqlConnection con = new SqlConnection(_connectionString);
            //    SqlCommand cmd = new SqlCommand("sp_insert", con);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "USE WebStats;SELECT * FROM Websites;";
            //    cmd.Connection = con;
            //    con.Open();
            //    cmd.ExecuteNonQuery();

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        if(reader.GetValue(0) == null)
            //        {
            //            ///////Here Loop for 10k 
            //            ///
            //            for (int i = 0; i <= 10000; i++)
            //            {
            //                cmd.CommandType = CommandType.Text;
            //                cmd.CommandText = $"INSERT Website(Title) VALUES (Website_No{i})";
            //                cmd.CommandText = $"INSERT Website(Adress) VALUES (Https://website{i}.com)";
            //                cmd.CommandText = $"INSERT Website(NumberOfEnters) VALUES ({random.Next(0,214748364)})";
            //            }
            //            cmd.Connection = con;
            //            con.Open();
            //            cmd.ExecuteNonQuery();
            //            con.Close();
            //        }
            //        reader.Close();
            //        con.Close();
            //        con.Dispose();
            //    }

            //} 
            #endregion

        }
    }
}

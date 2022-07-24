using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Utils;

namespace ExoTravelFullStack.Repositories
{
    public class AboutRepository : BaseRepository, IAboutRepository
    {
        public AboutRepository(IConfiguration configuration) : base(configuration) { }

        public List<About> GetAllAbouts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from About";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<About> abouts = new List<About>();
                        while (reader.Read())
                        {
                            About about = new About
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                CardDetail = DbUtils.GetString(reader, "CardDetail"),
                                Image = DbUtils.GetString(reader, "Image"),
                            };
                            abouts.Add(about);
                        }
                        return abouts; ;
                    }

                }
            }


        }


        public void Add(About about)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" INSERT Into About(Name)
	                   OUTPUT INSERTED.ID values(@Name)";
                    DbUtils.AddParameter(cmd, "@name", about.Name);

                    about.Id = (int)cmd.ExecuteScalar();
                };

            }
        }




        public About GetAboutById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, Detail, CardDetail, Image
                                        FROM About
                                        WHERE id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        About about = null;
                        if (reader.Read())
                        {
                            about = new About()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                CardDetail = DbUtils.GetString(reader, "CardDetail"),
                                Image = DbUtils.GetString(reader, "Image"),
                            };
                        }
                        return about;
                    }
                }


            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Delete from About Where id=@id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

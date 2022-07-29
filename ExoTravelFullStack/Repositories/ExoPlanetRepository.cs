using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Utils;

namespace ExoTravelFullStack.Repositories
{
    public class ExoPlanetRepository : BaseRepository, IExoPlanetRepository
    {
        public ExoPlanetRepository(IConfiguration configuration) : base(configuration) { }

        public List<ExoPlanet> GetAllExoPlanets()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from ExoPlanet";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ExoPlanet> exoPlanets = new List<ExoPlanet>();
                        while (reader.Read())
                        {
                            ExoPlanet exoPlanet = new ExoPlanet
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Mass = DbUtils.GetDec(reader, "Mass"),
                                Radius = DbUtils.GetDec(reader, "Radius"),
                                EqTemp = DbUtils.GetDec(reader, "EqTemp"),
                                Orbit = DbUtils.GetInt(reader, "Orbit"),
                                LightYears = DbUtils.GetInt(reader, "LightYears"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                Rating = DbUtils.GetInt(reader, "Rating")
                            };
                            exoPlanets.Add(exoPlanet);
                        }
                        return exoPlanets; ;
                    }
                }
            }
        }

        public List<ExoPlanet> GetByLightYearAsc()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * 
                                        FROM ExoPlanet
                                        ORDER BY LightYears";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ExoPlanet> exoPlanets = new List<ExoPlanet>();
                        while (reader.Read())
                        {
                            ExoPlanet exoPlanet = new ExoPlanet
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Mass = DbUtils.GetDec(reader, "Mass"),
                                Radius = DbUtils.GetDec(reader, "Radius"),
                                EqTemp = DbUtils.GetDec(reader, "EqTemp"),
                                Orbit = DbUtils.GetInt(reader, "Orbit"),
                                LightYears = DbUtils.GetInt(reader, "LightYears"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                Rating = DbUtils.GetInt(reader, "Rating")
                            };
                            exoPlanets.Add(exoPlanet);
                        }
                        return exoPlanets; ;
                    }
                }
            }
        }

        public List<ExoPlanet> GetByLightYearDesc()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * 
                                        FROM ExoPlanet
                                        ORDER BY LightYears DESC";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ExoPlanet> exoPlanets = new List<ExoPlanet>();
                        while (reader.Read())
                        {
                            ExoPlanet exoPlanet = new ExoPlanet
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Mass = DbUtils.GetDec(reader, "Mass"),
                                Radius = DbUtils.GetDec(reader, "Radius"),
                                EqTemp = DbUtils.GetDec(reader, "EqTemp"),
                                Orbit = DbUtils.GetInt(reader, "Orbit"),
                                LightYears = DbUtils.GetInt(reader, "LightYears"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                Rating = DbUtils.GetInt(reader, "Rating")
                            };
                            exoPlanets.Add(exoPlanet);
                        }
                        return exoPlanets; ;
                    }
                }
            }
        }

        public List<ExoPlanet> GetByRatingAsc()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * 
                                        FROM ExoPlanet
                                        ORDER BY Rating";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ExoPlanet> exoPlanets = new List<ExoPlanet>();
                        while (reader.Read())
                        {
                            ExoPlanet exoPlanet = new ExoPlanet
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Mass = DbUtils.GetDec(reader, "Mass"),
                                Radius = DbUtils.GetDec(reader, "Radius"),
                                EqTemp = DbUtils.GetDec(reader, "EqTemp"),
                                Orbit = DbUtils.GetInt(reader, "Orbit"),
                                LightYears = DbUtils.GetInt(reader, "LightYears"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                Rating = DbUtils.GetInt(reader, "Rating")
                            };
                            exoPlanets.Add(exoPlanet);
                        }
                        return exoPlanets; ;
                    }
                }
            }
        }

        public List<ExoPlanet> GetByRatingDesc()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * 
                                        FROM ExoPlanet
                                        ORDER BY Rating DESC";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ExoPlanet> exoPlanets = new List<ExoPlanet>();
                        while (reader.Read())
                        {
                            ExoPlanet exoPlanet = new ExoPlanet
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Mass = DbUtils.GetDec(reader, "Mass"),
                                Radius = DbUtils.GetDec(reader, "Radius"),
                                EqTemp = DbUtils.GetDec(reader, "EqTemp"),
                                Orbit = DbUtils.GetInt(reader, "Orbit"),
                                LightYears = DbUtils.GetInt(reader, "LightYears"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                Rating = DbUtils.GetInt(reader, "Rating")
                            };
                            exoPlanets.Add(exoPlanet);
                        }
                        return exoPlanets; ;
                    }
                }
            }
        }

        public void Add(ExoPlanet exoPlanet)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT Into ExoPlanet(Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating)
	                                    OUTPUT INSERTED.ID 
                                        VALUES(@name, @mass, @radius, @eqTemp, @orbit, @lightYears, @detail, @rating)";
                    DbUtils.AddParameter(cmd, "@name", exoPlanet.Name);
                    DbUtils.AddParameter(cmd, "@mass", exoPlanet.Mass);
                    DbUtils.AddParameter(cmd, "@radius", exoPlanet.Radius);
                    DbUtils.AddParameter(cmd, "@eqTemp", exoPlanet.EqTemp);
                    DbUtils.AddParameter(cmd, "@orbit", exoPlanet.Orbit);
                    DbUtils.AddParameter(cmd, "@lightYears", exoPlanet.LightYears);
                    DbUtils.AddParameter(cmd, "@detail", exoPlanet.Detail);
                    DbUtils.AddParameter(cmd, "@rating", exoPlanet.Rating);

                    exoPlanet.Id = (int)cmd.ExecuteScalar();
                };

            }
        }

        public ExoPlanet GetExoPlanetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        FROM ExoPlanet
                                        WHERE id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ExoPlanet exoPlanet = null;
                        if (reader.Read())
                        {
                            exoPlanet = new ExoPlanet()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Mass = DbUtils.GetDec(reader, "Mass"),
                                Radius = DbUtils.GetDec(reader, "Radius"),
                                EqTemp = DbUtils.GetDec(reader, "EqTemp"),
                                Orbit = DbUtils.GetInt(reader, "Orbit"),
                                LightYears = DbUtils.GetInt(reader, "LightYears"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                Rating = DbUtils.GetInt(reader, "Rating")
                            };
                        }
                        return exoPlanet;
                    }
                }


            }
        }

        public void Update(ExoPlanet exoPlanet)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE ExoPlanet
                                           SET Name = @name, 
                                               Mass = @mass, 
                                               Radius = @radius,
                                               EqTemp = @eqTemp, 
                                               Orbit = @orbit, 
                                               LightYears = @lightYears,
                                               Detail = @detail,
                                               Rating = @rating
                                         WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@name", exoPlanet.Name);
                    DbUtils.AddParameter(cmd, "@mass", exoPlanet.Mass);
                    DbUtils.AddParameter(cmd, "@radius", exoPlanet.Radius);
                    DbUtils.AddParameter(cmd, "@eqTemp", exoPlanet.EqTemp);
                    DbUtils.AddParameter(cmd, "@orbit", exoPlanet.Orbit);
                    DbUtils.AddParameter(cmd, "@lightYears", exoPlanet.LightYears);
                    DbUtils.AddParameter(cmd, "@detail", exoPlanet.Detail);
                    DbUtils.AddParameter(cmd, "@rating", exoPlanet.Rating);
                    DbUtils.AddParameter(cmd, "@id", exoPlanet.Id);

                    cmd.ExecuteNonQuery();
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
                    cmd.CommandText = "Delete FROM ExoPlanet WHERE id=@id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

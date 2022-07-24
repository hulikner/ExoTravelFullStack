using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Utils;

namespace ExoTravelFullStack.Repositories
{
    public class LogRepository : BaseRepository, ILogRepository
    {
        public LogRepository(IConfiguration configuration) : base(configuration) { }

        public List<Log> GetAllLogs()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT l.Id AS LogId, l.UserProfileId, l.ExoPlanetId, l.DepartureDate, l.ReturnDate, l.ReviewId, l.Mode,
                                               e.Id, e.Name, e.Mass, e.Radius, e.EqTemp, e.Orbit, e.LightYears, e.Detail, e.Rating,
                                               up.FirebaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId
                                        FROM Log l
                                        LEFT JOIN UserProfile up ON l.UserProfileId = up.Id
                                        LEFT JOIN ExoPlanet e ON l.ExoPlanetId = e.Id
                                        ORDER BY l.DepartureDate DESC
                                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Log> logs = new List<Log>();
                        while (reader.Read())
                        {
                            Log log = new Log
                            {
                                Id = DbUtils.GetInt(reader, "LogId"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                DepartureDate = DbUtils.GetInt(reader, "DepartureDate"),
                                ReturnDate = DbUtils.GetInt(reader, "ReturnDate"),
                                ReviewId = DbUtils.GetInt(reader, "ReviewId"),
                                Mode = DbUtils.GetString(reader, "Mode"),
                                ExoPlanet = new ExoPlanet()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Mass = DbUtils.GetInt(reader, "Mass"),
                                    Radius = DbUtils.GetInt(reader, "Radius"),
                                    EqTemp = DbUtils.GetInt(reader, "EqTemp"),
                                    Orbit = DbUtils.GetInt(reader, "Orbit"),
                                    LightYears = DbUtils.GetInt(reader, "LightYears"),
                                    Detail = DbUtils.GetString(reader, "Detail"),
                                    Rating = DbUtils.GetInt(reader, "Rating")
                                },
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                }

                            };
                            logs.Add(log);
                        }
                        return logs; ;
                    }

                }
            }


        }

        public List<Log> GetLogsByUserProfileId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT l.Id AS LogId, l.UserProfileId, l.ExoPlanetId, l.DepartureDate, l.ReturnDate, l.ReviewId, l.Mode,
                                               e.Id, e.Name, e.Mass, e.Radius, e.EqTemp, e.Orbit, e.LightYears, e.Detail, e.Rating,
                                               up.FirebaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId
                                        FROM Log l
                                        LEFT JOIN UserProfile up ON l.UserProfileId = up.Id
                                        LEFT JOIN ExoPlanet e ON l.ExoPlanetId = e.Id
                                        WHERE l.UserProfileId = @id
                                        ORDER BY l.DepartureDate DESC
                                        ";
                    DbUtils.AddParameter(cmd, "@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Log> logs = new List<Log>();
                        while (reader.Read())
                        {
                            Log log = new Log
                            {
                                Id = DbUtils.GetInt(reader, "LogId"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                DepartureDate = DbUtils.GetInt(reader, "DepartureDate"),
                                ReturnDate = DbUtils.GetInt(reader, "ReturnDate"),
                                ReviewId = DbUtils.GetInt(reader, "ReviewId"),
                                Mode = DbUtils.GetString(reader, "Mode"),
                                ExoPlanet = new ExoPlanet()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Mass = DbUtils.GetInt(reader, "Mass"),
                                    Radius = DbUtils.GetInt(reader, "Radius"),
                                    EqTemp = DbUtils.GetInt(reader, "EqTemp"),
                                    Orbit = DbUtils.GetInt(reader, "Orbit"),
                                    LightYears = DbUtils.GetInt(reader, "LightYears"),
                                    Detail = DbUtils.GetString(reader, "Detail"),
                                    Rating = DbUtils.GetInt(reader, "Rating")
                                },
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                }

                            };
                            logs.Add(log);
                        }
                        return logs; ;
                    }
                }
            }
        }


        public void Add(Log log)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT Into Log(UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode)
	                                    OUTPUT INSERTED.ID 
                                        VALUES(@userProfileId, @exoPlanetId, @departureDate, @returnDate, @reviewId, @mode)";
                    DbUtils.AddParameter(cmd, "@userProfileId", log.UserProfileId);
                    DbUtils.AddParameter(cmd, "@exoPlanetId", log.ExoPlanetId);
                    DbUtils.AddParameter(cmd, "@departureDate", log.DepartureDate);
                    DbUtils.AddParameter(cmd, "@returnDate", log.ReturnDate);
                    DbUtils.AddParameter(cmd, "@reviewId", log.ReviewId);
                    DbUtils.AddParameter(cmd, "@mode", log.Mode);
                    log.Id = (int)cmd.ExecuteScalar();
                };

            }
        }




        public Log GetLogById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT l.Id, l.UserProfileId, l.ExoPlanetId, l.DepartureDate, l.ReturnDate, l.ReviewId, l.Mode,
                                               e.Name, e.Mass, e.Radius, e.EqTemp, e.Orbit, e.LightYears, e.Detail, e.Rating,
                                               up.FirebaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId
                                        FROM Log l
                                        LEFT JOIN UserProfile up ON l.UserProfileId = up.Id
                                        LEFT JOIN ExoPlanet e ON l.ExoPlanetId = e.Id
                                        WHERE l.id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Log log = null;
                        if (reader.Read())
                        {
                            log = new Log()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                DepartureDate = DbUtils.GetInt(reader, "DepartureDate"),
                                ReturnDate = DbUtils.GetInt(reader, "ReturnDate"),
                                ReviewId = DbUtils.GetInt(reader, "ReviewId"),
                                Mode = DbUtils.GetString(reader, "Mode"),
                                ExoPlanet = new ExoPlanet()
                                {
                                    Id = DbUtils.GetInt(reader, "ExoPlanetId"),
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Mass = DbUtils.GetInt(reader, "Mass"),
                                    Radius = DbUtils.GetInt(reader, "Radius"),
                                    EqTemp = DbUtils.GetInt(reader, "EqTemp"),
                                    Orbit = DbUtils.GetInt(reader, "Orbit"),
                                    LightYears = DbUtils.GetInt(reader, "LightYears"),
                                    Detail = DbUtils.GetString(reader, "Detail"),
                                    Rating = DbUtils.GetInt(reader, "Rating")
                                },
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                    UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                                }
                            };
                        }
                        return log;
                    }
                }


            }
        }

        public void Update(Log log)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Log
                                           SET UserProfileId = @userProfileId, 
                                               ExoPlanetId = @exoPlanetId,
                                               DepartureDate = @departureDate, 
                                               ReturnDate = @returnDate, 
                                               ReviewId = @reviewId,
                                               Mode = @mode,
                                         WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@userProfileId", log.UserProfileId);
                    DbUtils.AddParameter(cmd, "@exoPlanetId", log.ExoPlanetId);
                    DbUtils.AddParameter(cmd, "@departureDate", log.DepartureDate);
                    DbUtils.AddParameter(cmd, "@returnDate", log.ReturnDate);
                    DbUtils.AddParameter(cmd, "@reviewId", log.ReviewId);
                    DbUtils.AddParameter(cmd, "@mode", log.Mode);
                    DbUtils.AddParameter(cmd, "@id", log.Id);

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
                    cmd.CommandText = "Delete from Log Where id=@id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

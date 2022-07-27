using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Utils;

namespace ExoTravelFullStack.Repositories
{
    public class ReceiptRepository : BaseRepository, IReceiptRepository
    {
        public ReceiptRepository(IConfiguration configuration) : base(configuration) { }

        public List<Receipt> GetAllReceipts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id, r.UserProfileId, r.ExoPlanetId, r.DepartureDate, r.ReturnDate, r.LogId, r.Paid, r.Mode,
                                               up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.ImageLocation, up.UserTypeId,
                                               ex.Name, ex.Mass, ex.Radius, ex.EqTemp, ex.Orbit, ex.LightYears, ex.Detail, ex.Rating,
                                               l.ReviewId,
                                               ut.Name AS UserTypeName
                                        FROM Receipt r
                                        LEFT JOIN UserProfile up ON r.UserProfileId = up.Id
                                        LEFT JOIN UserType ut ON up.UserTypeId = ut.Id
                                        LEFT JOIN ExoPlanet ex ON r.ExoPlanetId = ex.Id
                                        LEFT JOIN Log l ON r.LogId = l.Id";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Receipt> receipts = new List<Receipt>();
                        while (reader.Read())
                        {
                            Receipt receipt = new Receipt
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                DepartureDate = DbUtils.GetInt(reader, "DepartureDate"),
                                ReturnDate = DbUtils.GetInt(reader, "ReturnDate"),
                                LogId = DbUtils.GetInt(reader, "LogId"),
                                Paid = DbUtils.GetInt(reader, "Paid"),
                                Mode = DbUtils.GetString(reader, "Mode"),
                                UserType = new UserType()
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                },
                                UserProfile = new UserProfile()
                                {
                                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    //CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                },
                                Log = new Log()
                                {
                                    ReviewId = DbUtils.GetInt(reader, "ReviewId"),
                                },
                                ExoPlanet = new ExoPlanet()
                                {
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Mass = DbUtils.GetInt(reader, "Mass"),
                                    Radius = DbUtils.GetInt(reader, "Radius"),
                                    EqTemp = DbUtils.GetInt(reader, "EqTemp"),
                                    Orbit = DbUtils.GetInt(reader, "Orbit"),
                                    LightYears = DbUtils.GetInt(reader, "LightYears"),
                                    Detail = DbUtils.GetString(reader, "Detail"),
                                    Rating = DbUtils.GetInt(reader, "Rating")
                                }
                            };
                            receipts.Add(receipt);
                        }
                        return receipts; ;
                    }
                }
            }
        }

        public List<Receipt> GetAllReceiptsByUserId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id, r.UserProfileId, r.ExoPlanetId, r.DepartureDate, r.ReturnDate, r.LogId, r.Paid, r.Mode,
                                               up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId,
                                               ex.Name, ex.Mass, ex.Radius, ex.EqTemp, ex.Orbit, ex.LightYears, ex.Detail, ex.Rating,
                                               l.ReviewId,
                                               ut.Name AS UserTypeName
                                        FROM Receipt r
                                        LEFT JOIN UserProfile up ON r.UserProfileId = up.Id
                                        LEFT JOIN UserType ut ON up.UserTypeId = ut.Id
                                        LEFT JOIN ExoPlanet ex ON r.ExoPlanetId = ex.Id
                                        LEFT JOIN Log l ON r.LogId = l.Id
                                        WHERE up.id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Receipt> receipts = new List<Receipt>();
                        while (reader.Read())
                        {
                            Receipt receipt = new Receipt
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                DepartureDate = DbUtils.GetInt(reader, "DepartureDate"),
                                ReturnDate = DbUtils.GetInt(reader, "ReturnDate"),
                                LogId = DbUtils.GetInt(reader, "LogId"),
                                Paid = DbUtils.GetInt(reader, "Paid"),
                                Mode = DbUtils.GetString(reader, "Mode"),
                                UserType = new UserType()
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                },
                                UserProfile = new UserProfile()
                                {
                                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                },
                                Log = new Log()
                                {
                                    ReviewId = DbUtils.GetInt(reader, "ReviewId"),
                                },
                                ExoPlanet = new ExoPlanet()
                                {
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Mass = DbUtils.GetInt(reader, "Mass"),
                                    Radius = DbUtils.GetInt(reader, "Radius"),
                                    EqTemp = DbUtils.GetInt(reader, "EqTemp"),
                                    Orbit = DbUtils.GetInt(reader, "Orbit"),
                                    LightYears = DbUtils.GetInt(reader, "LightYears"),
                                    Detail = DbUtils.GetString(reader, "Detail"),
                                    Rating = DbUtils.GetInt(reader, "Rating")
                                }
                            };
                            receipts.Add(receipt);
                        }
                        return receipts; ;
                    }
                }
            }
        }


        public void Add(Receipt receipt)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT Into Receipt(UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, LogId, Paid, Mode)
	                                    OUTPUT INSERTED.ID 
                                        VALUES(@userProfileId, @exoPlanetId, @departureDate, @returnDate, @logId, @paid, @mode)";
                    DbUtils.AddParameter(cmd, "@userProfileId", receipt.UserProfileId);
                    DbUtils.AddParameter(cmd, "@exoPlanetId", receipt.ExoPlanetId);
                    DbUtils.AddParameter(cmd, "@departureDate", receipt.DepartureDate);
                    DbUtils.AddParameter(cmd, "@returnDate", receipt.ReturnDate);
                    DbUtils.AddParameter(cmd, "@logId", receipt.LogId);
                    DbUtils.AddParameter(cmd, "@paid", receipt.Paid);
                    DbUtils.AddParameter(cmd, "@mode", receipt.Mode);

                    receipt.Id = (int)cmd.ExecuteScalar();
                };

            }
        }




        public Receipt GetReceiptById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id, r.UserProfileId, r.ExoPlanetId, r.DepartureDate, r.ReturnDate, r.LogId, r.Paid, r.Mode,
                                               up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.ImageLocation, up.UserTypeId,
                                               ex.Name, ex.Mass, ex.Radius, ex.EqTemp, ex.Orbit, ex.LightYears, ex.Detail, ex.Rating,
                                               l.ReviewId,
                                               ut.Name AS UserTypeName
                                        FROM Receipt r
                                        LEFT JOIN UserProfile up ON r.UserProfileId = up.Id
                                        LEFT JOIN UserType ut ON up.UserTypeId = ut.Id
                                        LEFT JOIN ExoPlanet ex ON r.ExoPlanetId = ex.Id
                                        LEFT JOIN Log l ON r.LogId = l.Id
                                        WHERE r.id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Receipt receipt = null;
                        if (reader.Read())
                        {
                            receipt = new Receipt
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                DepartureDate = DbUtils.GetInt(reader, "DepartureDate"),
                                ReturnDate = DbUtils.GetInt(reader, "ReturnDate"),
                                LogId = DbUtils.GetInt(reader, "LogId"),
                                Paid = DbUtils.GetInt(reader, "Paid"),
                                Mode = DbUtils.GetString(reader, "Mode"),
                                UserType = new UserType()
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                },
                                UserProfile = new UserProfile()
                                {
                                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    //CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                },
                                Log = new Log()
                                {
                                    ReviewId = DbUtils.GetInt(reader, "ReviewId"),
                                },
                                ExoPlanet = new ExoPlanet()
                                {
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Mass = DbUtils.GetInt(reader, "Mass"),
                                    Radius = DbUtils.GetInt(reader, "Radius"),
                                    EqTemp = DbUtils.GetInt(reader, "EqTemp"),
                                    Orbit = DbUtils.GetInt(reader, "Orbit"),
                                    LightYears = DbUtils.GetInt(reader, "LightYears"),
                                    Detail = DbUtils.GetString(reader, "Detail"),
                                    Rating = DbUtils.GetInt(reader, "Rating")
                                }
                            };
                        }
                        return receipt;
                    }
                }


            }
        }


        public Receipt GetReceiptByLogId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id, r.UserProfileId, r.ExoPlanetId, r.DepartureDate, r.ReturnDate, r.LogId, r.Paid, r.Mode,
                                               up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId,
                                               ex.Name, ex.Mass, ex.Radius, ex.EqTemp, ex.Orbit, ex.LightYears, ex.Detail, ex.Rating,
                                               l.ReviewId,
                                               ut.Name AS UserTypeName
                                        FROM Receipt r
                                        LEFT JOIN UserProfile up ON r.UserProfileId = up.Id
                                        LEFT JOIN UserType ut ON up.UserTypeId = ut.Id
                                        LEFT JOIN ExoPlanet ex ON r.ExoPlanetId = ex.Id
                                        LEFT JOIN Log l ON r.LogId = l.Id
                                        WHERE r.LogId = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Receipt receipt = null;
                        if (reader.Read())
                        {
                            receipt = new Receipt
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                DepartureDate = DbUtils.GetInt(reader, "DepartureDate"),
                                ReturnDate = DbUtils.GetInt(reader, "ReturnDate"),
                                LogId = DbUtils.GetInt(reader, "LogId"),
                                Paid = DbUtils.GetInt(reader, "Paid"),
                                Mode = DbUtils.GetString(reader, "Mode"),
                                UserType = new UserType()
                                {
                                    Name = DbUtils.GetString(reader, "UserTypeName"),
                                },
                                UserProfile = new UserProfile()
                                {
                                    FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                                    FirstName = DbUtils.GetString(reader, "FirstName"),
                                    LastName = DbUtils.GetString(reader, "LastName"),
                                    DisplayName = DbUtils.GetString(reader, "DisplayName"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                    CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                                    ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                                },
                                Log = new Log()
                                {
                                    ReviewId = DbUtils.GetInt(reader, "ReviewId"),
                                },
                                ExoPlanet = new ExoPlanet()
                                {
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Mass = DbUtils.GetInt(reader, "Mass"),
                                    Radius = DbUtils.GetInt(reader, "Radius"),
                                    EqTemp = DbUtils.GetInt(reader, "EqTemp"),
                                    Orbit = DbUtils.GetInt(reader, "Orbit"),
                                    LightYears = DbUtils.GetInt(reader, "LightYears"),
                                    Detail = DbUtils.GetString(reader, "Detail"),
                                    Rating = DbUtils.GetInt(reader, "Rating")
                                }
                            };
                        }
                        return receipt;
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
                    cmd.CommandText = "Delete from Receipt Where id=@id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

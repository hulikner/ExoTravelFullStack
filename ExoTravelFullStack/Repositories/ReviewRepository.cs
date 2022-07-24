using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Utils;

namespace ExoTravelFullStack.Repositories
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(IConfiguration configuration) : base(configuration) { }

        public List<Review> GetAllReviews()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from Review";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Review> reviews = new List<Review>();
                        while (reader.Read())
                        {
                            Review review = new Review
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                CreateDate = DbUtils.GetInt(reader, "CreateDate"),
                                EditDate = DbUtils.GetInt(reader, "EditDate"),
                                Star = DbUtils.GetInt(reader, "Star"),
                                Message = DbUtils.GetString(reader, "Message")
                            };
                            reviews.Add(review);
                        }
                        return reviews; ;
                    }

                }
            }


        }

        public List<Review> GetAllReviewsByExoPlanet(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.Id, r.UserProfileId, r.ExoPlanetId, r.CreateDate, r.EditDate, r.Star, r.Message,
                                               up.FireBaseUserId, up.DisplayName, up.FirstName, up.LastName, up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId,
                                               ex.Name, ex.Mass, ex.Radius, ex.EqTemp, ex.Orbit, ex.LightYears, ex.Detail, ex.Rating
                                        FROM Review r
                                        LEFT JOIN UserProfile up ON r.UserProfileId = up.Id
                                        LEFT JOIN ExoPlanet ex ON r.ExoPlanetId = ex.Id
                                        WHERE ex.id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Review> reviews = new List<Review>();
                        while (reader.Read())
                        {
                            Review review = new Review
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                CreateDate = DbUtils.GetInt(reader, "CreateDate"),
                                EditDate = DbUtils.GetInt(reader, "EditDate"),
                                Star = DbUtils.GetInt(reader, "Star"),
                                Message = DbUtils.GetString(reader, "Message"),
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
                            reviews.Add(review);
                        }
                        return reviews; ;
                    }

                }
            }


        }


        public void Add(Review review)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT Into Review(UserProfileId, ExoPlanetId, CreateDate, EditDate, Star, Message)
	                                    OUTPUT INSERTED.ID 
                                        VALUES(@userProfileId, @exoPlanetId, @createDate, @editDate, @star, @message)";
                    DbUtils.AddParameter(cmd, "@userProfileId", review.UserProfileId);
                    DbUtils.AddParameter(cmd, "@exoPlanetId", review.ExoPlanetId);
                    DbUtils.AddParameter(cmd, "@createDate", review.CreateDate);
                    DbUtils.AddParameter(cmd, "@editDate", review.EditDate);
                    DbUtils.AddParameter(cmd, "@star", review.Star);
                    DbUtils.AddParameter(cmd, "@message", review.Message);

                    review.Id = (int)cmd.ExecuteScalar();
                };

            }
        }




        public Review GetReviewById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        FROM Review
                                        WHERE id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Review review = null;
                        if (reader.Read())
                        {
                            review = new Review()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                ExoPlanetId = DbUtils.GetInt(reader, "ExoPlanetId"),
                                CreateDate = DbUtils.GetInt(reader, "CreateDate"),
                                EditDate = DbUtils.GetInt(reader, "EditDate"),
                                Star = DbUtils.GetInt(reader, "Star"),
                                Message = DbUtils.GetString(reader, "Message")
                            };
                        }
                        return review;
                    }
                }


            }
        }

        public void Update(Review review)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Review
                                           SET ExoPlanetId = @exoPlanetId, 
                                               EditDate = @editDate, 
                                               Star = @star,
                                               Message = @message, 
                                               UserProfileId = @userProfileId, 
                                               CreateDate = @createDate,
                                               Detail = @detail,
                                               Rating = @rating
                                         WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@exoPlanetId", review.ExoPlanetId);
                    DbUtils.AddParameter(cmd, "@editDate", review.EditDate);
                    DbUtils.AddParameter(cmd, "@star", review.Star);
                    DbUtils.AddParameter(cmd, "@message", review.Message);
                    DbUtils.AddParameter(cmd, "@userProfileId", review.UserProfileId);
                    DbUtils.AddParameter(cmd, "@createDate", review.CreateDate);
                    DbUtils.AddParameter(cmd, "@id", review.Id);

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
                    cmd.CommandText = "Delete from Review Where id=@id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Utils;

namespace ExoTravelFullStack.Repositories
{
    public class HubDriveRepository : BaseRepository, IHubDriveRepository
    {
        public HubDriveRepository(IConfiguration configuration) : base(configuration) { }

        public List<HubDrive> GetAllHubDrives()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from HubDrive";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<HubDrive> hubDrives = new List<HubDrive>();
                        while (reader.Read())
                        {
                            HubDrive hubDrive = new HubDrive
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                CardDetail = DbUtils.GetString(reader, "CardDetail"),
                                Image = DbUtils.GetString(reader, "Image"),
                            };
                            hubDrives.Add(hubDrive);
                        }
                        return hubDrives; ;
                    }

                }
            }


        }


        public void Add(HubDrive hubDrive)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" INSERT Into HubDrive(Name)
	                   OUTPUT INSERTED.ID values(@Name)";
                    DbUtils.AddParameter(cmd, "@name", hubDrive.Name);

                    hubDrive.Id = (int)cmd.ExecuteScalar();
                };

            }
        }




        public HubDrive GetHubDriveById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, Detail, CardDetail, Image
                                        FROM HubDrive
                                        WHERE id = @id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        HubDrive hubDrive = null;
                        if (reader.Read())
                        {
                            hubDrive = new HubDrive()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Detail = DbUtils.GetString(reader, "Detail"),
                                CardDetail = DbUtils.GetString(reader, "CardDetail"),
                                Image = DbUtils.GetString(reader, "Image"),
                            };
                        }
                        return hubDrive;
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
                    cmd.CommandText = "Delete from HubDrive Where id=@id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

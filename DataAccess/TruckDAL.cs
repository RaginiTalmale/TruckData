using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TruckData.Models;

namespace TruckData.DataAccess
{
    public class TruckDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString;
        public List<Truck> GetAllTrucks()
        {
            List<Truck> trucks = new List<Truck>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select * from Trucks";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trucks.Add(new Truck
                    {
                        TruckId = Convert.ToInt32(reader["TruckId"]),
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString(),
                        Status = reader["Status"].ToString(),
                        Description = reader["Description"]?.ToString()
                    });

                }
            }
            return trucks;
        }
        public void CreateTruck(Truck truck)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Trucks (Code, Name, Status, Description) VALUES (@Code, @Name, @Status, @Description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Code", truck.Code);
                cmd.Parameters.AddWithValue("@Name", truck.Name);
                cmd.Parameters.AddWithValue("@Status", truck.Status);
                cmd.Parameters.AddWithValue("@Description", (object)truck.Description ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTruck(Truck truck)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Trucks SET Code = @Code, Name = @Name, Status = @Status, Description = @Description WHERE TruckId = @TruckId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TruckId", truck.TruckId);
                cmd.Parameters.AddWithValue("@Code", truck.Code);
                cmd.Parameters.AddWithValue("@Name", truck.Name);
                cmd.Parameters.AddWithValue("@Status", truck.Status);
                cmd.Parameters.AddWithValue("@Description", (object)truck.Description ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteTruck(int truckId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Trucks WHERE TruckId = @TruckId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TruckId", truckId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public Truck GetTruckById(int truckId)
        {
            Truck truck = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Trucks WHERE TruckId = @TruckId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TruckId", truckId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    truck = new Truck
                    {
                        TruckId = Convert.ToInt32(reader["TruckId"]),
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString(),
                        Status = reader["Status"].ToString(),
                        Description = reader["Description"]?.ToString()
                    };
                }
            }
            return truck;
        }
    }
}

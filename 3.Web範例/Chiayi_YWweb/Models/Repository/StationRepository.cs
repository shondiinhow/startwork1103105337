using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YW.Repository
{
    public class StationRepsitory
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MotorcycleDB.mdf;Integrated Security=True";
        public void Create(List<Models.StationData> stations)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            foreach(var station in stations)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT          INTO    Motorcycle(Siteid, Site, Address, Phonenumber)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}')
", station.Siteid, station.Site, station.Address, station.Phonenumber);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public List<Models.StationData> FindAllStations()
        {
            var result = new List<Models.StationData>();
            var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.ConnectionString = _connectionString;
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Motorcycle";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Models.StationData item = new Models.StationData();
                item.Siteid = reader["Siteid"].ToString();
                item.Site = reader["Site"].ToString();
                item.Address = reader["Address"].ToString();
                item.Phonenumber = reader["Phonenumber"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }
    }
}

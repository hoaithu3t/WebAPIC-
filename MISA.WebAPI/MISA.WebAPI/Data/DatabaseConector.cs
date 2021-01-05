using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;


namespace MISA.WebAPI.Data
{
    public class Databaseconector<TEntity>
    {

        public IEnumerable<TEntity> GetAll()
        {
            var className = typeof(TEntity).Name;
            string connectionString = "User Id=nvmanh;Host=103.124.92.43;port=3306;password=12345678;Database=MS03_09_NTTHIEM_CukCuk;Character Set=utf8";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var sql = $"SELECT * FROM {className}";
            var entities = dbConnection.Query<TEntity>(sql);
            return entities;
        }

    }
}

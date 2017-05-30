using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TorServices.Repositary
{
    public class Connection : IConnection
    {
        private readonly string _connectionString;

        public Connection(string connectioString)
        {
            if (string.IsNullOrEmpty(connectioString))
                throw new ArgumentNullException("connection string");
            _connectionString = connectioString;
        }

        public void Dispose()
        {
            
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
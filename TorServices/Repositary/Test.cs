using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TorServices.Repositary
{
    public class Test : IConnection
    {
        private readonly string _test;
        public Test(string test)
        {
            _test = test;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public SqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
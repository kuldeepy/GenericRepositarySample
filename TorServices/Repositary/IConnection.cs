using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorServices.Repositary
{
    public interface IConnection: IDisposable
    {
        SqlConnection GetConnection();
    }
}

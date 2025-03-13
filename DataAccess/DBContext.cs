using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class DBContext
    {
        public IDbConnection Conn(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

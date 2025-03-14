using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Contracts;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class ErrorLog : IErrorLog
    {
        private readonly DBContext _dBContext;
        private readonly IConfiguration _config;

        public ErrorLog(DBContext dBContext, IConfiguration config)
        {
            _dBContext = dBContext;
            _config = config;
        }

        public void Register(string method, string error)
        {
            string sqlQuery = "INSERT INTO TBL_ErrorLog (Method, Error) VALUES(@Method, @Error);";

            var parameters = new
            {
                Method = "Api_UserCRUD/" + method,
                Error = error
            };

            try
            {
                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    _context.Execute(sqlQuery, parameters, commandTimeout: 600);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

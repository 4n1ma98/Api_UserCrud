using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Contracts;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DataAccess
{
    public class UserLogin : IUserLogin
    {
        private readonly DBContext _dBContext;
        private readonly IConfiguration _config;

        public UserLogin(DBContext dBContext, IConfiguration config)
        {
            _dBContext = dBContext;
            _config = config;
        }

        public User Execute(Login login)
        {
            try
            {
                var parameters = new
                {
                    Option = 6,
                    login.Email,
                    login.Pass
                };

                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    return _context.Query<User>("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure).FirstOrDefault()!;
                }
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}

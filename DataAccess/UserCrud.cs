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
    public class UserCrud : IUserCrud
    {
        private readonly DBContext _dBContext;
        private readonly IConfiguration _config;

        public UserCrud(DBContext dBContext, IConfiguration config)
        {
            _dBContext = dBContext;
            _config = config;
        }

        public void Create(User user, Credentials credentials)
        {
            var parameters = new
            {
                Option=1,
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                credentials.Pass,
            };

            try
            {
                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    _context.Execute("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> Read(User user)
        {
            try
            {
                var parameters = new
                {
                    Option = 2,
                    user.Id,
                };

                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    return _context.Query<User>("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User user)
        {
            var parameters = new
            {
                Option = 3,
                user.Id,
                user.Email,
                user.Active,
            };

            try
            {
                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    _context.Execute("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(User user)
        {
            var parameters = new
            {
                Option = 4,
                user.Id,
            };

            try
            {
                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    _context.Execute("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> ReadAll()
        {
            try
            {
                var parameters = new
                {
                    Option = 5,
                };

                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    return _context.Query<User>("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

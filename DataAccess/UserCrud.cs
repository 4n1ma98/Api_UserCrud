using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Contracts;
using Microsoft.Extensions.Configuration;
using Models.Dtos;
using Models.Entities;

namespace DataAccess
{
    public class UserCrud : IUserCrud
    {
        private readonly DBContext _dBContext;
        private readonly IConfiguration _config;
        private readonly IErrorCode _errorCode;
        private readonly IErrorLog _errorLog;

        public UserCrud(DBContext dBContext, IConfiguration config, IErrorCode errorCode, IErrorLog errorLog)
        {
            _dBContext = dBContext;
            _config = config;
            _errorCode = errorCode;
            _errorLog = errorLog;
        }

        public Response Create(User user, Credentials credentials)
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
                    return _errorCode.GetError(0);
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("UserCrud/Create", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response Read(User user)
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
                    return _errorCode.GetError(0, _context.Query<User>("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure).ToList());
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("UserCrud/Read", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response Update(User user)
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
                    return _errorCode.GetError(0);
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("UserCrud/Update", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response Delete(User user)
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
                    return _errorCode.GetError(0);
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("UserCrud/Delete", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response ReadAll()
        {
            try
            {
                var parameters = new
                {
                    Option = 5,
                };

                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    return _errorCode.GetError(0, _context.Query<User>("SP_UserCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure).ToList());
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("UserCrud/ReadAll", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }
    }
}

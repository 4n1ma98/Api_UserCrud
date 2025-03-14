using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using DataAccess.Contracts;
using Models.Dtos;
using Models.Entities;

namespace Business
{
    public class UserValidation : IUserValidation
    {
        private readonly IUserCrud _userCrud;
        private readonly IEncrypter _encrypter;

        public UserValidation(IUserCrud userCrud, IEncrypter encrypter)
        {
            _userCrud = userCrud;
            _encrypter = encrypter;
        }

        public Response Create_User(CreateUserRequest request)
        {
            User user = new()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            Credentials credentials = new()
            {
                Pass = _encrypter.Encrypt(request.Pass),
            };

            return _userCrud.Create(user, credentials);
        }

        public Response Read_User(string id)
        {
            User user = new()
            {
                Id = id,
            };

            return _userCrud.Read(user);
        }

        public Response Update_User(UpdateUserRequest request)
        {
            User user = new()
            {
                Id = request.Id,
                Email = request.Email,
                Active = request.Active,
            };

            return _userCrud.Update(user);
        }

        public Response Delete_User(string id)
        {
            User user = new()
            {
                Id = id,
            };

            return _userCrud.Delete(user);
        }

        public Response Read_Users()
        {
            return _userCrud.ReadAll();
        }
    }
}

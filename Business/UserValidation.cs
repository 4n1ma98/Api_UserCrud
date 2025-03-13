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

        public UserValidation(IUserCrud userCrud)
        {
            _userCrud = userCrud;
        }

        public void Create_User(CreateUserRequest request)
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
                Pass = request.Pass,
            };

            _userCrud.Create(user, credentials);
        }

        public List<User> Read_User(string id)
        {
            User user = new()
            {
                Id = id,
            };

            return _userCrud.Read(user);
        }

        public void Update_User(UpdateUserRequest request)
        {
            User user = new()
            {
                Id = request.Id,
                Email = request.Email,
                Active = request.Active,
            };

            _userCrud.Update(user);
        }

        public void Delete_User(string id)
        {
            User user = new()
            {
                Id = id,
            };

            _userCrud.Delete(user);
        }

        public List<User> Read_Users()
        {
            return _userCrud.ReadAll();
        }
    }
}

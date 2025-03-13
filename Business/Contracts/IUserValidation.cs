using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Dtos;
using Models.Entities;

namespace Business.Contracts
{
    public interface IUserValidation
    {
        void Create_User(CreateUserRequest request);
        List<User> Read_User(string id);
        void Update_User(UpdateUserRequest request);
        void Delete_User(string id);
        List<User> Read_Users();
    }
}

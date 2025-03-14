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
        Response Create_User(CreateUserRequest request);
        Response Read_User(string id);
        Response Update_User(UpdateUserRequest request);
        Response Delete_User(string id);
        Response Read_Users();
    }
}

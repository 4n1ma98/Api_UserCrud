using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Dtos;
using Models.Entities;

namespace Business.Contracts
{
    public interface ILoginValidation
    {
        User User_Login(LoginRequest request);
    }
}

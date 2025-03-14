using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Dtos;
using Models.Entities;

namespace DataAccess.Contracts
{
    public interface IUserCrud
    {
        Response Create(User user, Credentials credentials);
        Response Read(User user);
        Response Update(User user);
        Response Delete(User user);
        Response ReadAll();
    }
}

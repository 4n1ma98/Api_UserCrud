using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace DataAccess.Contracts
{
    public interface IUserCrud
    {
        void Create(User user, Credentials credentials);
        List<User> Read(User user);
        void Update(User user);
        void Delete(User user);
        List<User> ReadAll();
    }
}

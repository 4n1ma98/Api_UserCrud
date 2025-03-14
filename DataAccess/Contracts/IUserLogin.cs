using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace DataAccess.Contracts
{
    public interface IUserLogin
    {
        User Execute(Login login);
    }
}

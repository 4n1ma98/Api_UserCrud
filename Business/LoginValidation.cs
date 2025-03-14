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
    public class LoginValidation : ILoginValidation
    {
        private readonly IUserLogin _userLogin;
        private readonly IEncrypter _encrypter;

        public LoginValidation(IUserLogin userLogin, IEncrypter encrypter)
        {
            _userLogin = userLogin;
            _encrypter = encrypter;
        }

        public User User_Login(LoginRequest request)
        {
            Login login = new()
            {
                Email = request.Email,
                Pass = _encrypter.Encrypt(request.Pass),
            };

            return _userLogin.Execute(login);
        }
    }
}

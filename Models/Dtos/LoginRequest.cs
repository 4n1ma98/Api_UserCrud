using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}

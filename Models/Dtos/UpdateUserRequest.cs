﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class UpdateUserRequest
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}

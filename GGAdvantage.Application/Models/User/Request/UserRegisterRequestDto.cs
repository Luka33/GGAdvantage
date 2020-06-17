using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.User
{
    public class UserRegisterRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

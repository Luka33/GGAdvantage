using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.User
{
    public class UserLoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}

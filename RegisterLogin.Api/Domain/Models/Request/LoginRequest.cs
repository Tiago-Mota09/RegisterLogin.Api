using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterLogin.Api.Domain.Models.Request
{
    public class LoginRequest
    {
        public string Nome{ get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

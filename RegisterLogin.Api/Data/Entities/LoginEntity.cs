using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterLogin.Api.Data.Entities
{
    public class LoginEntity
    {
        public int IdUsers { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }
    }
}

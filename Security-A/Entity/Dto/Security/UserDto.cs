using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? roleString { get; set; }
        public List<DataSelectDto>? Roles { get; set; }
        public bool State { get; set; }
        public int PersonId { get; set; }
    }
}

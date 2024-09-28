using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? viewString { get; set; }
        public List<DataSelectDto>? Views { get; set; }
        public bool State { get; set; }
    }
}

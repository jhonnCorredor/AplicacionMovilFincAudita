using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class RoleViewDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ViewId { get; set; }
        public bool State { get; set; }
    }
}

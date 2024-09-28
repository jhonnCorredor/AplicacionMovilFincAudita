using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class MenuDto
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int? roleID { get; set; }
        public string? role { get; set; }
        public List<moduloDao>? ListView { get; set; }
    }
}

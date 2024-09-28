using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class ModuloDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
    }
}

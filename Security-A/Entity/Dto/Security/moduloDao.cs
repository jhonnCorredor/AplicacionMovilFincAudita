using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class moduloDao
    {
        public string Modulo {  get; set; }
        public string ModuloDescription { get; set; }
        public List<ViewDao> Views { get; set; }
    }
}

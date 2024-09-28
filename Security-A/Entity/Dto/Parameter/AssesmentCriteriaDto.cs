using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class AssesmentCriteriaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating_range { get; set; }
        public string Type_criterian { get; set; }
        public bool State { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class ChecklistDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Calification_total { get; set; }
        public bool? State { get; set; }
        public List<QualificationDto>? qualifications {  get; set; }
    }
}

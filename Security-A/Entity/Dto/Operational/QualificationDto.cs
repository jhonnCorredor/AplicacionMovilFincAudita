using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class QualificationDto
    {
        public int Id { get; set; }
        public string Observation { get; set; }
        public int Qualification_criteria { get; set; }
        public int? AssessmentCriteriaId { get; set; }
        public int? ChecklistId { get; set; }
        public Boolean? State { get; set; }
    }
}

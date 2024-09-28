using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Parameter;

namespace Entity.Model.Operational
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Observation { get; set; }
        public int Qualification_criteria { get; set; }
        public int AssessmentCriteriaId {  get; set; }
        public AssessmentCriteria AssessmentCriteria { get; set; }
        public int ChecklistId { get; set; }
        public Checklist Checklist { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}

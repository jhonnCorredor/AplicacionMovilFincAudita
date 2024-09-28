using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class ReviewTechnical
    {
        public int Id { get; set; }
        public DateTime Date_review {get; set; }
        public string Code { get; set; }
        public string Observation {  get; set; }
        public int LotId { get; set; }
        public Lot Lot { get; set; } 
        public int TecnicoId { get; set; }
        public User Tecnico { get; set; }
        public int ChecklistId {  get; set; }
        public Checklist Checklist { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

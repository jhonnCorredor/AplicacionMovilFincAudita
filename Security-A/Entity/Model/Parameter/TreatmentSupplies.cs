using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Operational;

namespace Entity.Model.Parameter
{
    public class TreatmentSupplies
    {
        public int Id { get; set; }
        public string Dose { get; set; }
        public int SuppliesId { get; set; }
        public Supplies Supplies { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

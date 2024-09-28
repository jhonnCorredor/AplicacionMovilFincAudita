using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class LotTreatment
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public Lot Lot { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class TreatmentSuppliesDto
    {
        public int Id { get; set; }
        public string Dose { get; set; }
        public int? SuppliesId { get; set; }
        public int? TreatmentId { get; set; }
        public bool? State { get; set; }
        public string? supplie {  get; set; }
    }
}

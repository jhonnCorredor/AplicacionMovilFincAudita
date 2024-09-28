using Entity.Dto.Parameter;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class TreatmentDto
    {
        public int Id { get; set; }
        public DateTime DateTreatment { get; set; }
        public string TypeTreatment { get; set; }
        public string QuantityMix { get; set; }
        public Boolean State { get; set; }
        public string? lotString { get; set; }
        public string? supplieString { get; set; }
        public List<LotTreatmentDto>? lotList { get; set; }
        public List<TreatmentSuppliesDto>? supplieList { get; set; }
    }
}

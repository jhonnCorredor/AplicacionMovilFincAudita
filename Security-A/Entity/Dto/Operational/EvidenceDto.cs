using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class EvidenceDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string Document { get; set; }
        public int? ReviewId { get; set; }
        public Boolean? State { get; set; }
    }
}

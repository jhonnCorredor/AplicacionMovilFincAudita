using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Evidence
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Document {  get; set; }
        public int ReviewId { get; set; }
        public ReviewTechnical? Review { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

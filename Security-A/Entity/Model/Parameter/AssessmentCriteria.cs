using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class AssessmentCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating_range { get; set; }
        public string Type_criterian { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}

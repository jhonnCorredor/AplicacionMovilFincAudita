using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class AlertDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public int UserId { get; set; }
        public bool State { get; set; }
    }
}

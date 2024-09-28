using Entity.Model.Parameter;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Farm
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string Addres { get; set; }
        public int Dimension { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

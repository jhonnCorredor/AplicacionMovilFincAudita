using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Addres { get; set; }
        public long Phone { get; set; }
        public string Type_document { get; set; }
        public string Document { get; set; }
        public bool State { get; set; }
        public DateTime Birth_of_date { get; set; }
        public int CityId {  get; set; }
    }
}

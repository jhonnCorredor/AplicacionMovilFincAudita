using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface IQualificationData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Qualification> GetById(int id);
        Task<Qualification> Save(Qualification entity);
        Task Update(Qualification entity);
        Task<IEnumerable<Qualification>> GetAll();
    }
}

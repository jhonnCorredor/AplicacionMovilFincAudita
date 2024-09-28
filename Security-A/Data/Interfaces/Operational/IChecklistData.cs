using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface IChecklistData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Checklist> GetById(int id);
        Task<Checklist> Save(Checklist entity);
        Task Update(Checklist entity);
        Task<IEnumerable<Checklist>> GetAll();
    }
}

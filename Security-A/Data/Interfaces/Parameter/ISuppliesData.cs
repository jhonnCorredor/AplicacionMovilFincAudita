using Entity.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface ISuppliesData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Supplies> GetById(int id);
        Task<Supplies> Save(Supplies entity);
        Task Update(Supplies entity);
        Task<IEnumerable<Supplies>> GetAll();
    }
}

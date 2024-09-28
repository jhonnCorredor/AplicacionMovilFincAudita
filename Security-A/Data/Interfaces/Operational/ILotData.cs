using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface ILotData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Lot> GetById(int id);
        Task<Lot> Save(Lot entity);
        Task Update(Lot entity);
        Task<IEnumerable<Lot>> GetAll();
        Task DeleteLots(int id);
    }
}

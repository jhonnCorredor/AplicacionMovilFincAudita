using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Operational;
using Entity.Dto.Operational;

namespace Business.Interfaces.Operational
{
    public interface ILotBusiness
    {
        Task Delete(int id);
        Task DeleteLots(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<LotDto> GetById(int id);
        Task<Lot> Save(LotDto entity);
        Task Update(LotDto entity);
        Lot mapearDatos(Lot lot, LotDto entity);
        Task<IEnumerable<LotDto>> GetAll();
    }
}

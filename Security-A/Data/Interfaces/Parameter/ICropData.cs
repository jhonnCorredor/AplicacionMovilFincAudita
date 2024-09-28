using Entity.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface ICropData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Crop> GetById(int id);
        Task<Crop> Save(Crop entity);
        Task Update(Crop entity);
        Task<IEnumerable<Crop>> GetAll();
    }
}

using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface IEvidenceData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Evidence> GetById(int id);
        Task DeleteEvidences(int id);
        Task<Evidence> Save(Evidence entity);
        Task Update(Evidence entity);
        Task<IEnumerable<Evidence>> GetAll();
    }
}

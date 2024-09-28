using Entity.Dto.Operational;
using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Operational
{
    public interface IEvidenceBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<EvidenceDto> GetById(int id);
        Task<Evidence> Save(EvidenceDto entity);
        Task Update(EvidenceDto entity);
        Task DeleteEvidences(int id);
        Evidence mapearDatos(Evidence evidence, EvidenceDto entity);
        Task<IEnumerable<EvidenceDto>> GetAll();
    }
}

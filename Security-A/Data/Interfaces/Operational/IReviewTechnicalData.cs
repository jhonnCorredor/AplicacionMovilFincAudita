using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface IReviewTechnicalData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ReviewTechnical> GetById(int id);
        Task<ReviewTechnical> Save(ReviewTechnical entity);
        Task Update(ReviewTechnical entity);
        Task<ReviewTechnicalDto> GetByIdPivote(int id);
        Task<IEnumerable<ReviewTechnicalDto>> GetAll();
    }
}

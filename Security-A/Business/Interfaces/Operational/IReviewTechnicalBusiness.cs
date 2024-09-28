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
    public interface IReviewTechnicalBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ReviewTechnicalDto> GetById(int id);
        Task<ReviewTechnical> Save(ReviewTechnicalDto entity);
        Task Update(ReviewTechnicalDto entity);
        ReviewTechnical mapearDatos(ReviewTechnical reviewTechnical, ReviewTechnicalDto entity);
        Task<IEnumerable<ReviewTechnicalDto>> GetAll();
    }
}

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
    public interface IQualificationBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<QualificationDto> GetById(int id);
        Task<Qualification> Save(QualificationDto entity);
        Task Update(QualificationDto entity);
        Qualification mapearDatos(Qualification qualification, QualificationDto entity);
        Task<IEnumerable<QualificationDto>> GetAll();
    }
}

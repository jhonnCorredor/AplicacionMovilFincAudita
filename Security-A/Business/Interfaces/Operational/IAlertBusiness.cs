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
    public interface IAlertBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<AlertDto> GetById(int id);
        Task<Alert> Save(AlertDto entity);
        Task Update(AlertDto entity);
        Alert mapearDatos(Alert Alert, AlertDto entity);
        Task<IEnumerable<AlertDto>> GetAll();
        Task<IEnumerable<AlertDto>> GetByUser(DataSelectDto dto);
    }
}

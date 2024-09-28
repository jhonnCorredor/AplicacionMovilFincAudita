using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Operational
{
    public interface IAlertData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Alert> GetById(int id);
        Task<Alert> Save(Alert entity);
        Task Update(Alert entity);
        Task<IEnumerable<Alert>> GetAll();
        Task<IEnumerable<Alert>> GetByUser(int id);
    }
}

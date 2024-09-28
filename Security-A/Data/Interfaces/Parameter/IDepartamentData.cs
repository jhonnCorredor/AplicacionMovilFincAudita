using Entity.Dto;
using Entity.Model.Parameter;

namespace Data.Interfaces.Parameter
{
    public interface IDepartamentData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Departament> GetById(int id);
        Task<Departament> Save(Departament entity);
        Task Update(Departament entity);
        Task<IEnumerable<Departament>> GetAll();
    }
}

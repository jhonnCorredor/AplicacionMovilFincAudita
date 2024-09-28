using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IPersonData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Person> GetById(int id);
        Task<Person> Save(Person entity);
        Task Update(Person entity);
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetByFirst_name(string first_name);
    }
}

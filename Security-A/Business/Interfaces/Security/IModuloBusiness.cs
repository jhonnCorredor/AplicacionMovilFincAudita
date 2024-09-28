using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Business.Interfaces.Security
{
    public interface IModuloBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ModuloDto> GetById(int id);
        Task<Modulo> Save(ModuloDto entity);
        Task Update(ModuloDto entity);
        Modulo mapearDatos(Modulo modulo, ModuloDto entity);
        Task<IEnumerable<ModuloDto>> GetAll();
    }
}

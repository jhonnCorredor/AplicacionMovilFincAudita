using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IUserData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<User> GetById(int id);
        Task<User> Save(User entity);
        Task Update(User entity);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetByIdAndRoles(int id);
        Task<User> GetByUsername(string username);
        Task<User> GetByPassword(string password);
        Task<IEnumerable<LoginDto>> Login(string username, string password);

    }
}

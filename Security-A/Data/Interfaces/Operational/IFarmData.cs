using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Data.Interfaces.Operational
{
    public interface IFarmData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Farm> GetById(int id);
        Task<Farm> Save(Farm entity);
        Task<FarmDto> GetByIdLot(int id);
        Task Update(Farm entity);
        Task<IEnumerable<FarmDto>> GetAll();
    }
}

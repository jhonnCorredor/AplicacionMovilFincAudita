using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Business.Implements.Security
{
    public class RoleViewBusiness : IRoleViewBusiness
    {
        protected readonly IRoleViewData data;

        public RoleViewBusiness(IRoleViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task DeleteViews(int id)
        {
            await data.DeleteViews(id);
        }

        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            IEnumerable<RoleView> roleViews = await data.GetAll();
            var roleViewDtos = roleViews.Select(roleView => new RoleViewDto
            {
                Id = roleView.Id,
                RoleId = roleView.RoleId,
                ViewId = roleView.ViewId,
                State = roleView.State
            });

            return roleViewDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<RoleViewDto> GetById(int id)
        {
            RoleView roleView = await data.GetById(id);
            RoleViewDto roleViewDto = new RoleViewDto();

            roleViewDto.Id = roleView.Id;
            roleViewDto.RoleId = roleView.RoleId;
            roleViewDto.ViewId = roleView.ViewId;
            roleViewDto.State = roleView.State;
            return roleViewDto;
        }

        public RoleView mapearDatos(RoleView roleView, RoleViewDto entity)
        {
            roleView.Id = entity.Id;
            roleView.RoleId = entity.RoleId;
            roleView.ViewId = entity.ViewId;
            roleView.State = entity.State;
            return roleView;
        }

        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleView = new RoleView();
            roleView = mapearDatos(roleView, entity);
            roleView.CreatedAt = DateTime.Now;
            roleView.State = true;
            roleView.DeletedAt = null;
            roleView.UpdatedAt = null;

            return await data.Save(roleView);
        }

        public async Task Update(RoleViewDto entity)
        {
            RoleView roleView = await data.GetById(entity.Id);
            if (roleView == null)
            {
                throw new Exception("Registro no encontrado");
            }
            roleView = mapearDatos(roleView, entity);
            roleView.UpdatedAt = DateTime.Now;

            await data.Update(roleView);
        }
    }
}

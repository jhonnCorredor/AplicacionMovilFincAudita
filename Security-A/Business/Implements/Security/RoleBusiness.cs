using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;
using System.Text.Json;

namespace Business.Implements.Security
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly IRoleData data;
        private readonly IRoleViewBusiness roleViewBusiness;

        public RoleBusiness(IRoleData data, IRoleViewBusiness roleViewBusiness)
        {
            this.data = data;
            this.roleViewBusiness = roleViewBusiness;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            IEnumerable<RoleDto> roles = await data.GetAll();
            List<RoleDto> roleDtos = new List<RoleDto>();
            foreach (var rol in roles)
            {
                RoleDto role = new RoleDto();
                role.Id = rol.Id;
                role.Name = rol.Name;
                role.Description = rol.Description;
                role.State = rol.State;
                if(rol.viewString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    role.Views = JsonSerializer.Deserialize<List<DataSelectDto>>(rol.viewString, options);
                }
                roleDtos.Add(role);
            }
            return roleDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<RoleDto> GetById(int id)
        {
            RoleDto role = await data.GetByIdAndViews(id);
            RoleDto roleDto = new RoleDto();

            roleDto.Id = role.Id;
            roleDto.Name = role.Name;
            roleDto.Description = role.Description;
            roleDto.State = role.State;
            if (role.viewString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                roleDto.Views = JsonSerializer.Deserialize<List<DataSelectDto>>(role.viewString, options);
            }
            
            return roleDto;
        }

        public Role mapearDatos(Role role, RoleDto entity)
        {
            role.Id = entity.Id;
            role.Name = entity.Name;
            role.Description = entity.Description;
            role.State = entity.State;
            return role;
        }

        public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();
            role = mapearDatos(role, entity);
            role.CreatedAt = DateTime.Now;
            role.State = true;
            role.UpdatedAt = null;
            role.DeletedAt = null;

            Role save = await data.Save(role);

            if (entity.Views != null && entity.Views.Count > 0)
            {
                foreach(var view in entity.Views)
                {
                    RoleViewDto roleview = new RoleViewDto();
                    roleview.ViewId = view.Id;
                    roleview.RoleId = save.Id;
                    roleview.State = true;
                    await roleViewBusiness.Save(roleview);
                }
            }

            return save;
        }

        public async Task Update(RoleDto entity)
        {
            Role role = await data.GetById(entity.Id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = mapearDatos(role, entity);
            role.UpdatedAt = DateTime.Now;

            await roleViewBusiness.DeleteViews(role.Id);

            if (entity.Views.Count > 0 && entity.Views != null)
            {
                foreach (var view in entity.Views)
                {
                    RoleViewDto roleview = new RoleViewDto();
                    roleview.ViewId = view.Id;
                    roleview.RoleId = role.Id;
                    roleview.State = true;
                    await roleViewBusiness.Save(roleview);
                }
            }

            await data.Update(role);
        }
    }
}

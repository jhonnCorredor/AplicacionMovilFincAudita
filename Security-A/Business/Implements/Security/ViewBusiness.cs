using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Business.Implements.Security
{
    public class ViewBusiness : IViewBusiness
    {
        protected readonly IViewData data;

        public ViewBusiness(IViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            IEnumerable<View> views = await data.GetAll();
            var viewDtos = views.Select(view => new ViewDto
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                Route = view.Route,
                ModuloId = view.ModuloId,
                State = view.State
            });

            return viewDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await data.GetById(id);
            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.Name = view.Name;
            viewDto.Description = view.Description;
            viewDto.Route = view.Route;
            viewDto.ModuloId = view.ModuloId;
            viewDto.State = view.State;
            return viewDto;
        }

        public View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.Name = entity.Name;
            view.Description = entity.Description;
            view.Route = entity.Route;
            view.ModuloId = entity.ModuloId;
            view.State = entity.State;
            return view;
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view = mapearDatos(view, entity);
            view.CreatedAt = DateTime.Now;
            view.State = true;
            view.UpdatedAt = null;
            view.DeletedAt = null;


            return await data.Save(view);
        }

        public async Task Update(ViewDto entity)
        {
            View view = await data.GetById(entity.Id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = mapearDatos(view, entity);
            view.UpdatedAt = DateTime.Now;

            await data.Update(view);
        }
    }
}

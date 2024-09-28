using Data.Interfaces.Security;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Security
{
    public class ViewData : IViewData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ViewData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            entity.State = false;
            context.Views.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Description , ' - ', Route) AS TextoMostrar 
                    FROM 
                        Views
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM Views WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }

        public async Task<View> Save(View entity)
        {
            context.Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(View entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<View> GetByName(string name)
        {
            return await context.Views.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<View>> GetAll()
        {
            var sql = @"SELECT * FROM Views Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<View>(sql);
        }
    }
}

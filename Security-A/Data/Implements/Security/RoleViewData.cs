using Data.Interfaces.Security;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Security
{
    public class RoleViewData : IRoleViewData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public RoleViewData(ApplicationDBContext context, IConfiguration configuration)
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
            context.RoleViews.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteViews(int id)
        {
            var entitys = await GetByRoleId(id);
            foreach (var entity in entitys)
            {
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            entity.State = false;
            context.RoleViews.Update(entity);
            await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Role_id, ' - ', View_id) AS TextoMostrar 
                    FROM 
                        RoleViews
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM RoleViews WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
        }

        public async Task<IEnumerable<RoleView>> GetByRoleId(int id)
        {
            var sql = @"SELECT * FROM RoleViews WHERE RoleId = @Id ORDER BY Id ASC";
            return await context.QueryAsync<RoleView>(sql, new { Id = id });
        }

        public async Task<RoleView> Save(RoleView entity)
        {
            context.RoleViews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RoleView entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleView>> GetAll()
        {
            var sql = @"SELECT * FROM RoleViews Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<RoleView>(sql);
        }
    }
}

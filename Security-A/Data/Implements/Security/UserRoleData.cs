using Data.Interfaces.Security;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Security
{
    public class UserRoleData : IUserRoleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public UserRoleData(ApplicationDBContext context, IConfiguration configuration)
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
            context.UserRoles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRoles(int id)
        {
            var entitys = await GetByUserId(id);
            foreach (var entity in entitys)
            {
                if (entity == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
                entity.State = false;
                context.UserRoles.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Role_id, ' - ', User_id) AS TextoMostrar 
                    FROM 
                        UserRoles
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM UserRoles WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<UserRole>(sql, new { Id = id });
        }

        public async Task<IEnumerable<UserRole>> GetByUserId(int id)
        {
            var sql = @"SELECT * FROM UserRoles WHERE UserId = @Id ORDER BY Id ASC";
            return await context.QueryAsync<UserRole>(sql, new { Id = id });
        }

        public async Task<UserRole> Save(UserRole entity)
        {
            context.UserRoles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(UserRole entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRole>> GetAll()
        {
            var sql = @"SELECT * FROM UserRoles Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<UserRole>(sql);
        }
    }
}

using Data.Interfaces.Security;
using Entity.Context;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Security
{
    public class RoleData : IRoleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public RoleData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Roles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Description) AS TextoMostrar 
                    FROM 
                        Roles
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM Roles WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }

        public async Task<RoleDto> GetByIdAndViews(int id)
        {
            var sql = @"SELECT 
                            r.Id,
                            r.Name,
                            r.Description,
                            r.State
                            (
                                SELECT 
                                    v.Id,
                                    v.Name AS textoMostrar
                                FROM Views AS v
                                LEFT JOIN RoleViews AS rv2 ON rv2.ViewId = v.Id
                                WHERE rv2.RoleId = r.Id AND rv2.DeletedAt IS NULL
                                FOR JSON PATH
                            ) AS viewString
                            FROM Roles AS r
                            WHERE r.DeletedAt IS NULL AND r.Id = @Id
                            GROUP BY r.Id, r.Name, r.Description, r.State
                            ORDER BY r.Id ASC;";
            return await context.QueryFirstOrDefaultAsync<RoleDto>(sql, new { Id = id });
        }

        public async Task<Role> Save(Role entity)
        {
            context.Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Role entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Role> GetByName(string name)
        {
            return await context.Roles.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            var sql = @"SELECT 
                            r.Id,
                            r.Name,
                            r.Description,
                            r.State,
                            (
                                SELECT 
                                    v.Id,
                                    v.Name AS textoMostrar
                                FROM Views AS v
                                LEFT JOIN RoleViews AS rv2 ON rv2.ViewId = v.Id
                                WHERE rv2.RoleId = r.Id AND rv2.DeletedAt IS NULL
                                FOR JSON PATH
                            ) AS viewString
                            FROM Roles AS r
                            WHERE r.DeletedAt IS NULL
                            GROUP BY r.Id, r.Name, r.Description, r.State
                            ORDER BY r.Id ASC;";
            return await context.QueryAsync<RoleDto>(sql);
        }
    }
}

using Data.Interfaces.Parameter;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Parameter
{
    public class DepartamentData : IDepartamentData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public DepartamentData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Departaments.Update(entity);
            await context.SaveChangesAsync();
        }

         public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Code, ' - ', Name) AS TextoMostrar 
                    FROM 
                        Departaments
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

         public async Task<Departament> GetById(int id)
        {
            var sql = @"SELECT * FROM Departaments WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Departament>(sql, new { Id = id });
        }

         public async Task<Departament> Save(Departament entity)
        {
            context.Departaments.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

         public async Task Update(Departament entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

         public async Task<IEnumerable<Departament>> GetAll()
        {
            var sql = @"SELECT * FROM Departaments Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Departament>(sql);
        }
    }
}

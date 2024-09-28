using Data.Interfaces.Parameter;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Parameter
{
    public class CityData : ICityData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Citys.Update(entity);
            await context.SaveChangesAsync();
        }

         public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Code, ' - ', Name) AS TextoMostrar 
                    FROM 
                        Citys
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

         public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM Citys WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

         public async Task<City> Save(City entity)
        {
            context.Citys.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

         public async Task Update(City entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

         public async Task<IEnumerable<City>> GetAll()
        {
            var sql = @"SELECT * FROM Citys Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<City>(sql);
        }
    }
}

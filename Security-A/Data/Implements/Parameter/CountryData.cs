using Data.Interfaces.Parameter;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Parameter
{
    public class CountryData : ICountryData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CountryData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Countrys.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Code, ' - ', Name) AS TextoMostrar 
                    FROM 
                        Countrys
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Country> GetById(int id)
        {
            var sql = @"SELECT * FROM Countrys WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        public async Task<Country> Save(Country entity)
        {
            context.Countrys.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Country entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            var sql = @"SELECT * FROM Countrys Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Country>(sql);
        }
    }
}

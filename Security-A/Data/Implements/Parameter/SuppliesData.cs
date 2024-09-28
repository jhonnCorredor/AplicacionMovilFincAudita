using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Parameter
{
    public class SuppliesData : ISuppliesData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public SuppliesData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Supplies.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Name AS TextoMostrar 
                    FROM 
                        Supplies
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Supplies> GetById(int id)
        {
            var sql = @"SELECT * FROM Supplies WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Supplies>(sql, new { Id = id });
        }

        public async Task<Supplies> Save(Supplies entity)
        {
            context.Supplies.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Supplies entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplies>> GetAll()
        {
            var sql = @"SELECT * FROM Supplies Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Supplies>(sql);
        }
    }
}

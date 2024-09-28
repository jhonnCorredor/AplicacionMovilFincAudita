using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Operational;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class LotData : ILotData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public LotData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Lots.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteLots(int id)
        {
            var entitys = await GetByFarmId(id);
            foreach (var entity in entitys)
            {
                if (entity == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
                entity.State = false;
                context.Lots.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Num_hectareas AS TextoMostrar 
                    FROM 
                        Lots
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<Lot>> GetByFarmId(int id)
        {
            var sql = @"SELECT * FROM Lots WHERE FarmId = @Id ORDER BY Id ASC";
            return await context.QueryAsync<Lot>(sql, new { Id = id });
        }

        public async Task<Lot> GetById(int id)
        {
            var sql = @"SELECT * FROM Lots WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Lot>(sql, new { Id = id });
        }

        public async Task<Lot> Save(Lot entity)
        {
            context.Lots.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Lot entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lot>> GetAll()
        {
            var sql = @"SELECT * FROM Lots Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Lot>(sql);
        }
    }
}

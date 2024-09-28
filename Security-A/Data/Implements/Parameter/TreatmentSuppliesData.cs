using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Parameter
{
    public class TreatmentSuppliesData : ITreatmentSuppliesData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public TreatmentSuppliesData(ApplicationDBContext context, IConfiguration configuration)
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
            context.TreatmentSupplies.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSupplie(int id)
        {
            var entitys = await GetByTreatmeId(id);
            foreach (var entity in entitys)
            {
                if (entity == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
                entity.State = false;
                context.TreatmentSupplies.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Dose AS TextoMostrar 
                    FROM 
                        TreatmentSupplies
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<TreatmentSupplies> GetById(int id)
        {
            var sql = @"SELECT * FROM TreatmentSupplies WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<TreatmentSupplies>(sql, new { Id = id });
        }

        public async Task<IEnumerable<TreatmentSupplies>> GetByTreatmeId(int id)
        {
            var sql = @"SELECT * FROM TreatmentSupplies WHERE TreatmentId = @Id ORDER BY Id ASC";
            return await context.QueryAsync<TreatmentSupplies>(sql, new { Id = id });
        }

        public async Task<TreatmentSupplies> Save(TreatmentSupplies entity)
        {
            context.TreatmentSupplies.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(TreatmentSupplies entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TreatmentSupplies>> GetAll()
        {
            var sql = @"SELECT * FROM TreatmentSupplies Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<TreatmentSupplies>(sql);
        }
    }
}

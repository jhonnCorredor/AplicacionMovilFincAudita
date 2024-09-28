using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class LotTreatmentData : ILotTreatmentData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public LotTreatmentData(ApplicationDBContext context, IConfiguration configuration)
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
            context.LotTreatments.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteLots(int id)
        {
            var entitys = await GetByTreatmenId(id);
            foreach (var entity in entitys)
            {
                if (entity == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
                entity.State = false;
                context.LotTreatments.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Role_id, ' - ', View_id) AS TextoMostrar 
                    FROM 
                        LotTreatments
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<LotTreatment> GetById(int id)
        {
            var sql = @"SELECT * FROM LotTreatments WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<LotTreatment>(sql, new { Id = id });
        }

        public async Task<IEnumerable<LotTreatment>> GetByTreatmenId(int id)
        {
            var sql = @"SELECT * FROM LotTreatments WHERE TreatmentId = @Id ORDER BY Id ASC";
            return await context.QueryAsync<LotTreatment>(sql, new { Id = id });
        }

        public async Task<LotTreatment> Save(LotTreatment entity)
        {
            context.LotTreatments.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(LotTreatment entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LotTreatment>> GetAll()
        {
            var sql = @"SELECT * FROM LotTreatments Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<LotTreatment>(sql);
        }
    }
}

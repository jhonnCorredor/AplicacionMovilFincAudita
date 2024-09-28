using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class EvidenceData : IEvidenceData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public EvidenceData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Evidences.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteEvidences(int id)
        {
            var entitys = await GetByReviewId(id);
            foreach (var entity in entitys)
            {
                if (entity == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
                entity.State = false;
                context.Evidences.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Code AS TextoMostrar 
                    FROM 
                        Evidences
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Evidence> GetById(int id)
        {
            var sql = @"SELECT * FROM Evidences WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Evidence>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Evidence>> GetByReviewId(int id)
        {
            var sql = @"SELECT * FROM Evidences WHERE ReviewId = @Id ORDER BY Id ASC";
            return await context.QueryAsync<Evidence>(sql, new { Id = id });
        }

        public async Task<Evidence> Save(Evidence entity)
        {
            context.Evidences.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Evidence entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Evidence>> GetAll()
        {
            var sql = @"SELECT * FROM Evidences Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Evidence>(sql);
        }
    }
}

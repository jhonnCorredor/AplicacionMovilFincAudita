using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class QualificationData : IQualificationData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public QualificationData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Qualifications.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Observation AS TextoMostrar 
                    FROM 
                        Qualifications
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Qualification> GetById(int id)
        {
            var sql = @"SELECT * FROM Qualifications WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Qualification>(sql, new { Id = id });
        }

        public async Task<Qualification> Save(Qualification entity)
        {
            context.Qualifications.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Qualification entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Qualification>> GetAll()
        {
            var sql = @"SELECT * FROM Qualifications Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Qualification>(sql);
        }
    }
}

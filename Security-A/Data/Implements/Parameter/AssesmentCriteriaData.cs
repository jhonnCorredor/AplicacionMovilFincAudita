using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements.Parameter
{
    public class AssesmentCriteriaData : IAssesmentCriteriaData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public AssesmentCriteriaData(ApplicationDBContext context, IConfiguration configuration)
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
            context.AssessmentCriterias.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Name AS TextoMostrar 
                    FROM 
                        AssessmentCriterias
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<AssessmentCriteria> GetById(int id)
        {
            var sql = @"SELECT * FROM AssessmentCriterias WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<AssessmentCriteria>(sql, new { Id = id });
        }

        public async Task<AssessmentCriteria> Save(AssessmentCriteria entity)
        {
            context.AssessmentCriterias.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(AssessmentCriteria entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AssessmentCriteria>> GetAll()
        {
            var sql = @"SELECT * FROM AssessmentCriterias Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<AssessmentCriteria>(sql);
        }
    }
}

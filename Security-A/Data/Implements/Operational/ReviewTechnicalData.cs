using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class ReviewTechnicalData : IReviewTechnicalData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ReviewTechnicalData(ApplicationDBContext context, IConfiguration configuration)
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
            context.ReviewTechnicals.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Code AS TextoMostrar 
                    FROM 
                        ReviewTechnicals
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<ReviewTechnical> GetById(int id)
        {
            var sql = @"SELECT * FROM ReviewTechnicals WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<ReviewTechnical>(sql, new { Id = id });
        }

        public async Task<ReviewTechnicalDto> GetByIdPivote(int id)
        {
            var sql = @"SELECT 
	                        rt.Id,
	                        rt.Date_review,
	                        rt.Code,
	                        rt.Observation,
	                        rt.LotId,
							u.Username AS 'Tecnico',
							CONCAT('',f.Name, ': ', c.Name) AS 'lot',
	                        rt.TecnicoId,
	                        rt.ChecklistId,
	                        rt.State,
	                        (
	                          SELECT 
	                          e.Id,
	                          e.Document
	                          FROM Evidences AS e
	                          WHERE e.ReviewId = rt.Id AND e.DeletedAt IS NULL
	                        FOR JSON PATH
	                        )AS evidenceString,
	                        (
	                          SELECT 
	                          c.Id,
	                          c.Code,
	                          c.Calification_total,
	                          (
		                        SELECT
		                        q.Id,
		                        q.Observation,
		                        q.Qualification_criteria,
		                        q.AssessmentCriteriaId
		                        FROM Qualifications AS q
		                        WHERE q.ChecklistId = c.Id AND q.DeletedAt IS Null
		                        FOR JSON PATH
	                          ) AS qualifications
	                          FROM Checklists AS c
	                          WHERE c.Id = rt.ChecklistId AND c.DeletedAt IS NULL
	                         FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
	                        )AS checklistString
                        FROM ReviewTechnicals AS rt
						INNER JOIN Users AS u ON u.Id = rt.TecnicoId
						INNER JOIN Lots AS l ON l.Id = rt.LotId
						INNER JOIN Farms AS f ON f.Id = l.FarmId
						INNER JOIN Crops AS c ON c.Id = l.CropId
                        WHERE rt.DeletedAt IS NULL AND rt.Id = @Id
                        GROUP BY rt.Id, rt.Date_review, rt.Code, rt.Observation, rt.LotId, rt.TecnicoId, rt.ChecklistId, rt.State, u.Username, f.Name, c.Name
                        ORDER BY rt.Id ASC;";
            return await context.QueryFirstOrDefaultAsync<ReviewTechnicalDto>(sql, new { Id = id });
        }

        public async Task<ReviewTechnical> Save(ReviewTechnical entity)
        {
            context.ReviewTechnicals.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(ReviewTechnical entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewTechnicalDto>> GetAll()
        {
            var sql = @"SELECT 
	                        rt.Id,
	                        rt.Date_review,
	                        rt.Code,
	                        rt.Observation,
	                        rt.LotId,
							u.Username AS 'Tecnico',
							CONCAT('',f.Name, ': ', c.Name) AS 'lot',
	                        rt.TecnicoId,
	                        rt.ChecklistId,
	                        rt.State,
	                        (
	                          SELECT 
	                          e.Id,
	                          e.Document
	                          FROM Evidences AS e
	                          WHERE e.ReviewId = rt.Id AND e.DeletedAt IS NULL
	                        FOR JSON PATH
	                        )AS evidenceString,
	                        (
	                          SELECT 
	                          c.Id,
	                          c.Code,
	                          c.Calification_total,
	                          (
		                        SELECT
		                        q.Id,
		                        q.Observation,
		                        q.Qualification_criteria,
		                        q.AssessmentCriteriaId
		                        FROM Qualifications AS q
		                        WHERE q.ChecklistId = c.Id AND q.DeletedAt IS Null
		                        FOR JSON PATH
	                          ) AS qualifications
	                          FROM Checklists AS c
	                          WHERE c.Id = rt.ChecklistId AND c.DeletedAt IS NULL
	                         FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
	                        )AS checklistString
                        FROM ReviewTechnicals AS rt
						INNER JOIN Users AS u ON u.Id = rt.TecnicoId
						INNER JOIN Lots AS l ON l.Id = rt.LotId
						INNER JOIN Farms AS f ON f.Id = l.FarmId
						INNER JOIN Crops AS c ON c.Id = l.CropId
                        WHERE rt.DeletedAt IS NULL 
                        GROUP BY rt.Id, rt.Date_review, rt.Code, rt.Observation, rt.LotId, rt.TecnicoId, rt.ChecklistId, rt.State, u.Username, f.Name, c.Name
                        ORDER BY rt.Id ASC;";
            return await context.QueryAsync<ReviewTechnicalDto>(sql);
        }
    }
}

using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class TreatmentData : ITreatmentData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public TreatmentData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Treatments.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        TypeTreatment AS TextoMostrar 
                    FROM 
                        Treatments
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Treatment> GetById(int id)
        {
            var sql = @"SELECT * FROM Treatments WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Treatment>(sql, new { Id = id });
        }

        public async Task<TreatmentDto> GetByIdPivote(int id)
        {
            var sql = @"SELECT 
                           t.Id,
                           t.QuantityMix,
                           t.TypeTreatment,
                           t.DateTreatment,
                           t.State,
                           (
                              SELECT 
                                 lt.Id,
                                 lt.LotId,
		                         CONCAT(f.Name, ': ',  c.Name) AS lot
                                 FROM LotTreatments AS lt
		                         Inner join Lots AS l ON l.Id = lt.LotId
		                         Inner join Farms AS f ON f.Id = l.FarmId
		                         Inner join Crops AS c ON c.Id = l.CropId
                                 WHERE lt.TreatmentId = t.Id AND lt.DeletedAt IS NULL
                                 FOR JSON PATH
	                        )AS lotString,
	                        (
                              SELECT 
                                 ts.Id,
		                         ts.Dose,
                                 ts.SuppliesId,
		                         s.Name AS supplie
                                 FROM TreatmentSupplies AS ts
		                         Inner join Supplies AS s ON s.Id = ts.SuppliesId
                                 WHERE ts.TreatmentId = t.Id AND ts.DeletedAt IS NULL
                                 FOR JSON PATH
	                        )AS supplieString
                        FROM Treatments AS t
                        WHERE t.DeletedAt IS NULL AND t.Id = @Id
                        GROUP BY t.Id, t.QuantityMix, t.TypeTreatment, t.DateTreatment, t.State
                        ORDER BY t.Id ASC;";
            return await context.QueryFirstOrDefaultAsync<TreatmentDto>(sql, new { Id = id });
        }

        public async Task<Treatment> Save(Treatment entity)
        {
            context.Treatments.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Treatment entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TreatmentDto>> GetAll()
        {
                var sql = @"SELECT 
                               t.Id,
                               t.QuantityMix,
                               t.TypeTreatment,
                               t.DateTreatment,
                               t.State,
                               (
                                  SELECT 
                                     lt.Id,
                                     lt.LotId,
		                             CONCAT(f.Name, ': ',  c.Name) AS lot
                                     FROM LotTreatments AS lt
		                             Inner join Lots AS l ON l.Id = lt.LotId
		                             Inner join Farms AS f ON f.Id = l.FarmId
		                             Inner join Crops AS c ON c.Id = l.CropId
                                     WHERE lt.TreatmentId = t.Id AND lt.DeletedAt IS NULL
                                     FOR JSON PATH
	                            )AS lotString,
	                            (
                                  SELECT 
                                     ts.Id,
		                             ts.Dose,
                                     ts.SuppliesId,
		                             s.Name AS supplie
                                     FROM TreatmentSupplies AS ts
		                             Inner join Supplies AS s ON s.Id = ts.SuppliesId
                                     WHERE ts.TreatmentId = t.Id AND ts.DeletedAt IS NULL
                                     FOR JSON PATH
	                            )AS supplieString
                            FROM Treatments AS t
                            WHERE t.DeletedAt IS NULL 
                            GROUP BY t.Id, t.QuantityMix, t.TypeTreatment, t.DateTreatment, t.State
                            ORDER BY t.Id ASC;";
            return await context.QueryAsync<TreatmentDto>(sql);
        }

  
    }
}

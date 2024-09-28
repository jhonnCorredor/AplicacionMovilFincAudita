using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class FarmData : IFarmData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public FarmData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Farms.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Name AS TextoMostrar 
                    FROM 
                        Farms
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Farm> GetById(int id)
        {
            var sql = @"SELECT * FROM Farms WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Farm>(sql, new { Id = id });
        }

        public async Task<FarmDto> GetByIdLot(int id)
        {
            var sql = @"SELECT 
                           f.Id,
                           f.Name,
                           f.CityId,
                           f.UserId,
                           f.Addres,
                           f.Dimension,
                           f.State,
                           (
                              SELECT 
                                 l.Id,
                                 l.Num_hectareas,
                                 l.CropId,
		                         c.Name AS cultivo
                                 FROM Lots AS l
		                         Inner join Crops AS c ON c.Id = l.CropId
                                 WHERE l.FarmId = f.Id AND l.DeletedAt IS NULL
                                 FOR JSON PATH
	                        )AS lotString
                        FROM Farms AS f
                        WHERE f.DeletedAt IS NULL AND f.Id = @Id
                        GROUP BY f.Id, f.Name, f.CityId, f.UserId, f.Addres, f.Dimension, f.State
                        ORDER BY f.Id ASC;";
            return await context.QueryFirstOrDefaultAsync<FarmDto>(sql, new { Id = id });
        }


        public async Task<Farm> Save(Farm entity)
        {
            context.Farms.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Farm entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FarmDto>> GetAll()
        {
            var sql = @"SELECT 
                           f.Id,
                           f.Name,
                           f.CityId,
                           f.UserId,
                           f.Addres,
                           f.Dimension,
                           f.State,
                           (
                              SELECT 
                                 l.Id,
                                 l.Num_hectareas,
                                 l.CropId,
		                         c.Name AS cultivo
                                 FROM Lots AS l
		                         Inner join Crops AS c ON c.Id = l.CropId
                                 WHERE l.FarmId = f.Id AND l.DeletedAt IS NULL
                                 FOR JSON PATH
	                        )AS lotString
                        FROM Farms AS f
                        WHERE f.DeletedAt IS NULL
                        GROUP BY f.Id, f.Name, f.CityId, f.UserId, f.Addres, f.Dimension, f.State
                        ORDER BY f.Id ASC;";
            return await context.QueryAsync<FarmDto>(sql);
        }
    }
}

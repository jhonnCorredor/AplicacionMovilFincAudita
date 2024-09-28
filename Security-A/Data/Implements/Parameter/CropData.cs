using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Parameter
{
    public class CropData : ICropData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CropData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Crops.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Name AS TextoMostrar 
                    FROM 
                        Crops
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Crop> GetById(int id)
        {
            var sql = @"SELECT * FROM Crops WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Crop>(sql, new { Id = id });
        }

        public async Task<Crop> Save(Crop entity)
        {
            context.Crops.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Crop entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Crop>> GetAll()
        {
            var sql = @"SELECT * FROM Crops Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Crop>(sql);
        }
    }
}

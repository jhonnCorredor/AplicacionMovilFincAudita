using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Operational
{
    public class ChecklistData : IChecklistData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ChecklistData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Checklists.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Code AS TextoMostrar 
                    FROM 
                        Checklists
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Checklist> GetById(int id)
        {
            var sql = @"SELECT * FROM Checklists WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Checklist>(sql, new { Id = id });
        }

        public async Task<Checklist> Save(Checklist entity)
        {
            context.Checklists.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Checklist entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Checklist>> GetAll()
        {
            var sql = @"SELECT * FROM Checklists Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Checklist>(sql);
        }
    }
}

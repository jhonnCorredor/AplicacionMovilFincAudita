using Data.Interfaces.Security;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Security
{
    public class ModuloData : IModuloData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ModuloData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Modulos.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Description) AS TextoMostrar 
                    FROM 
                        Modulos
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM Modulos WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Modulo>(sql, new { Id = id });
        }

        public async Task<Modulo> GetByName(string name)
        {
            return await context.Modulos.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Modulo> Save(Modulo entity)
        {
            context.Modulos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Modulo>> GetAll()
        {
            var sql = @"SELECT * FROM Modulos Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Modulo>(sql);
        }
    }
}

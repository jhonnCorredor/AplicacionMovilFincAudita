using Data.Interfaces.Security;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements.Security
{
    public class PersonData : IPersonData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public PersonData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Persons.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(First_name, ' - ', Last_name, Type_document, ' - ', Document) AS TextoMostrar 
                    FROM 
                        Persons
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM Persons WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }

        public async Task<Person> Save(Person entity)
        {
            context.Persons.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Person entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Person> GetByFirst_name(string first_name)
        {
            return await context.Persons.AsNoTracking().Where(item => item.First_name == first_name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var sql = @"SELECT * FROM Persons Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Person>(sql);
        }
    }
}

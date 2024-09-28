using Data.Interfaces.Operational;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements.Operational
{
    public class AlertData : IAlertData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public AlertData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Alerts.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Title AS TextoMostrar 
                    FROM 
                        Alerts
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Alert> GetById(int id)
        {
            var sql = @"SELECT * FROM Alerts WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Alert>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Alert>> GetByUser(int id)
        {
            var sql = @"SELECT al.* FROM Alerts AS al WHERE al.UserId = @Id AND al.Date >= @Date ORDER BY Id ASC;";
            var currentDate = DateTime.Now;
            return await context.QueryAsync<Alert>(sql, new { Id = id, Date = currentDate });
        }


        public async Task<Alert> Save(Alert entity)
        {
            context.Alerts.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Alert entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Alert>> GetAll()
        {
            var sql = @"SELECT * FROM Alerts Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<Alert>(sql);
        }
    }
}

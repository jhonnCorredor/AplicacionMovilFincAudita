using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dto.Operational;
using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements.Operational
{
    public class AlertBusiness : IAlertBusiness
    {
        private readonly IAlertData data;

        public AlertBusiness(IAlertData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<AlertDto>> GetAll()
        {
            IEnumerable<Alert> Alerts = await data.GetAll();
            var AlertDtos = Alerts.Select(Alert => new AlertDto
            {
                Id = Alert.Id,
                Title = Alert.Title,
                Theme = Alert.Theme,
                Date = Alert.Date,
                UserId = Alert.UserId,
                State = Alert.State,
            });

            return AlertDtos;
        }

        public async Task<IEnumerable<AlertDto>> GetByUser(DataSelectDto dto)
        {
            IEnumerable<Alert> Alerts = await data.GetByUser(dto.Id);
            var AlertDtos = Alerts.Select(Alert => new AlertDto
            {
                Id = Alert.Id,
                Title = Alert.Title,
                Theme = Alert.Theme,
                Date = Alert.Date,
                UserId = Alert.UserId,
                State = Alert.State,
            });

            return AlertDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<AlertDto> GetById(int id)
        {
            Alert Alert = await data.GetById(id);
            AlertDto AlertDto = new AlertDto();
            AlertDto.Id = Alert.Id;
            AlertDto.Title = Alert.Title;
            AlertDto.Theme = Alert.Theme;
            AlertDto.Date = Alert.Date;
            AlertDto.UserId = Alert.UserId;
            AlertDto.State = Alert.State;
            return AlertDto;
        }

        public Alert mapearDatos(Alert Alert, AlertDto entity)
        {
            Alert.Id = entity.Id;
            Alert.Title = entity.Title;
            Alert.Theme = entity.Theme;
            Alert.Date = entity.Date;
            Alert.UserId = entity.UserId;
            Alert.State = entity.State;
            return Alert;
        }

        public async Task<Alert> Save(AlertDto entity)
        {
            Alert Alert = new Alert();
            Alert = mapearDatos(Alert, entity);
            Alert.CreatedAt = DateTime.Now;
            Alert.State = true;
            Alert.UpdatedAt = null;
            Alert.DeletedAt = null;

            return await data.Save(Alert);
        }

        public async Task Update(AlertDto entity)
        {
            Alert Alert = await data.GetById(entity.Id);
            if (Alert == null)
            {
                throw new Exception("Registro no encontrado");
            }
            Alert = mapearDatos(Alert, entity);
            Alert.UpdatedAt = DateTime.Now;

            await data.Update(Alert);
        }
    }
}

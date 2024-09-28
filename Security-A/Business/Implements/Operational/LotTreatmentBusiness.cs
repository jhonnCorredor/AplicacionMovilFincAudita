using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dto.Security;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dto.Operational;

namespace Business.Implements.Operational
{
    public class LotTreatmentBusiness : ILotTreatmentBusiness
    {
        protected readonly ILotTreatmentData data;

        public LotTreatmentBusiness(ILotTreatmentData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task DeleteLots(int id)
        {
            await data.DeleteLots(id);
        }

        public async Task<IEnumerable<LotTreatmentDto>> GetAll()
        {
            IEnumerable<LotTreatment> LotTreatments = await data.GetAll();
            var LotTreatmentDtos = LotTreatments.Select(LotTreatment => new LotTreatmentDto
            {
                Id = LotTreatment.Id,
                LotId = LotTreatment.LotId,
                TreatmentId = LotTreatment.TreatmentId,
                State = LotTreatment.State
            });

            return LotTreatmentDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<LotTreatmentDto> GetById(int id)
        {
            LotTreatment LotTreatment = await data.GetById(id);
            LotTreatmentDto LotTreatmentDto = new LotTreatmentDto();

            LotTreatmentDto.Id = LotTreatment.Id;
            LotTreatmentDto.LotId = LotTreatment.LotId;
            LotTreatmentDto.TreatmentId = LotTreatment.TreatmentId;
            LotTreatmentDto.State = LotTreatment.State;
            return LotTreatmentDto;
        }

        public LotTreatment mapearDatos(LotTreatment LotTreatment, LotTreatmentDto entity)
        {
            LotTreatment.Id = entity.Id;
            LotTreatment.LotId = (int)entity.LotId;
            LotTreatment.TreatmentId = (int)entity.TreatmentId;
            LotTreatment.State = (Boolean)entity.State;
            return LotTreatment;
        }

        public async Task<LotTreatment> Save(LotTreatmentDto entity)
        {
            LotTreatment LotTreatment = new LotTreatment();
            LotTreatment = mapearDatos(LotTreatment, entity);
            LotTreatment.CreatedAt = DateTime.Now;
            LotTreatment.State = true;
            LotTreatment.DeletedAt = null;
            LotTreatment.UpdatedAt = null;

            return await data.Save(LotTreatment);
        }

        public async Task Update(LotTreatmentDto entity)
        {
            LotTreatment LotTreatment = await data.GetById(entity.Id);
            if (LotTreatment == null)
            {
                throw new Exception("Registro no encontrado");
            }
            LotTreatment = mapearDatos(LotTreatment, entity);
            LotTreatment.UpdatedAt = DateTime.Now;

            await data.Update(LotTreatment);
        }
    }
}

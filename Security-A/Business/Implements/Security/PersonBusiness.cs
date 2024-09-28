using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Business.Implements.Security
{
    public class PersonBusiness : IPersonBusiness
    {
        protected readonly IPersonData data;

        public PersonBusiness(IPersonData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<Person> persons = await data.GetAll();
            var personDtos = persons.Select(person => new PersonDto
            {
                Id = person.Id,
                First_name = person.First_name,
                Last_name = person.Last_name,
                Addres = person.Addres,
                Birth_of_date = person.Birth_of_date,
                Phone = person.Phone,
                Email = person.Email,
                Type_document = person.Type_document,
                Document = person.Document,
                CityId = person.CityId,
                State = person.State
            });

            return personDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person person = await data.GetById(id);
            PersonDto personDto = new PersonDto();

            personDto.Id = person.Id;
            personDto.First_name = person.First_name;
            personDto.Last_name = person.Last_name;
            personDto.Addres = person.Addres;
            personDto.Birth_of_date = person.Birth_of_date;
            personDto.Phone = person.Phone;
            personDto.Email = person.Email;
            personDto.Type_document = person.Type_document;
            personDto.Document = person.Document;
            personDto.CityId = person.CityId;
            personDto.State = person.State;
            return personDto;
        }

        public Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.First_name = entity.First_name;
            person.Last_name = entity.Last_name;
            person.Addres = entity.Addres;
            person.Birth_of_date = entity.Birth_of_date;
            person.Phone = entity.Phone;
            person.Email = entity.Email;
            person.Type_document = entity.Type_document;
            person.Document = entity.Document;
            person.CityId = entity.CityId;
            person.State = entity.State;
            return person;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person = mapearDatos(person, entity);
            person.CreatedAt = DateTime.Now;
            person.State = true;
            person.DeletedAt = null;
            person.UpdatedAt = null;

            return await data.Save(person);
        }

        public async Task Update(PersonDto entity)
        {
            Person person = await data.GetById(entity.Id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = mapearDatos(person, entity);
            person.UpdatedAt = DateTime.Now;

            await data.Update(person);
        }
    }
}

using AutoMapper;
using Movies.Api.Interfaces;
using Movies.Api.Models;
using Movies.Data.Interfaces;
using Movies.Data.Models;

namespace Movies.Api.Managers
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonManager(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public IList<PersonDto> GetAllPeople(PersonRole personRole, int page = 0, int pageSize = int.MaxValue)
        {
            IList<Person> people = personRepository.GetAll(personRole, page, pageSize);
            return mapper.Map<IList<PersonDto>>(people);
        }

        public PersonDto? GetPerson(uint personId)
        {
            Person? person = personRepository.FindById(personId);
            if (person is null)
            {
                return null;
            }

            return mapper.Map<PersonDto>(person);
        }

        public PersonDto AddPerson(PersonDto personDto)
        {
            Person person = mapper.Map<Person>(personDto);
            person.PersonId = default;
            Person addedPerson = personRepository.Insert(person);

            return mapper.Map<PersonDto>(addedPerson);
        }

        public PersonDto? UpdatePerson(uint personId, PersonDto personDto)
        {
            if (!personRepository.ExistsWithId(personId))
                return null;

            Person person = mapper.Map<Person>(personDto);
            person.PersonId = personId;
            Person updatedPerson = personRepository.Update(person);

            return mapper.Map<PersonDto>(updatedPerson);
        }

        public PersonDto? DeletePerson(uint personId)
        {
            if (!personRepository.ExistsWithId(personId))
                return null;

            Person person = personRepository.FindById(personId)!;
            PersonDto personDto = mapper.Map<PersonDto>(person);

            person.MoviesAsActor.Clear();
            person.MoviesAsDirector.Clear();
            personRepository.Update(person);

            personRepository.Delete(personId);

            return personDto;
        }
    }
}
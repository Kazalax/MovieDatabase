using Movies.Api.Models;
using Movies.Data.Models;

namespace Movies.Api.Interfaces
{
    public interface IPersonManager
    {
        PersonDto AddPerson(PersonDto personDto);
        PersonDto? DeletePerson(uint personId);
        IList<PersonDto> GetAllPeople(PersonRole personRole, int page = 0, int pageSize = int.MaxValue);
        PersonDto? GetPerson(uint personId);
        PersonDto UpdatePerson(uint personId, PersonDto personDto);
    }
}

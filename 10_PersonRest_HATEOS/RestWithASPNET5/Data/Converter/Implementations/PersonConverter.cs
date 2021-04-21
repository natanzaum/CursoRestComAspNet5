using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parser(Person origem)
        {
            if (origem == null) return null;

            return new PersonVO
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public Person Parser(PersonVO origem)
        {
            if (origem == null) return null;

            return new Person
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };

        }

        public List<PersonVO> Parser(List<Person> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parser(item)).ToList();
        }

        public List<Person> Parser(List<PersonVO> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parser(item)).ToList();
        }
    }
}

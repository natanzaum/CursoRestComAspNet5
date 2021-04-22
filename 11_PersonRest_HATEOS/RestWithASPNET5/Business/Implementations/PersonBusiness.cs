using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IRepository<Person> _personRepository;
        private readonly PersonConverter _converter;

        public PersonBusiness(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            personEntity = _personRepository.Create(personEntity);

            return _converter.Parser(personEntity);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parser(_personRepository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parser(_personRepository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            personEntity = _personRepository.Update(personEntity);

            return _converter.Parser(personEntity);
        }

    }
}

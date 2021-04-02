using RestWithASPNET5.Model;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
        List<Person> FindAll();
    }
}

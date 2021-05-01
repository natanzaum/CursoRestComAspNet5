using RestWithASPNET5.Model;
using System.Collections.Generic;

namespace RestWithASPNET5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindPersonByName(string fristName, string lastName);
    }
}

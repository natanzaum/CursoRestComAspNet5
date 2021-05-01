using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using RestWithASPNET5.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepository(MySQLContext context) : base (context) { }

        public List<Person> FindPersonByName(string fristName, string lastName)
        {
            if (!String.IsNullOrWhiteSpace(fristName) && !String.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(x => x.FirstName.Contains(fristName) && x.LastName.Contains(lastName)).ToList();
            }
            else if (String.IsNullOrWhiteSpace(fristName) && !String.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(x => x.LastName.Contains(lastName)).ToList();
            }
            else if (!String.IsNullOrWhiteSpace(fristName) && String.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(x => x.FirstName.Contains(fristName)).ToList();
            }

            return null;
        }
    }
}            

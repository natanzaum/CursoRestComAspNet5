using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        List<PersonVO> FindAll();
    }
}

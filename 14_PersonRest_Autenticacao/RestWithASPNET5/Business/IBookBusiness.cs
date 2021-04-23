using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        BookVO Update(BookVO book);
        void Delete(long id);
        List<BookVO> FindAll();
    }
}

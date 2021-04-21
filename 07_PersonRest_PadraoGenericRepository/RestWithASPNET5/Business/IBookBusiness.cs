﻿using RestWithASPNET5.Model;
using System.Collections.Generic;

namespace RestWithASPNET5.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long id);
        Book Update(Book book);
        void Delete(long id);
        List<Book> FindAll();
    }
}

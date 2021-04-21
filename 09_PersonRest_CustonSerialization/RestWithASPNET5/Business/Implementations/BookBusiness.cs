using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter _converter;

        public BookBusiness(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parser(book);
            bookEntity = _bookRepository.Create(bookEntity);

            return _converter.Parser(bookEntity);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parser(_bookRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parser(_bookRepository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parser(book);
            bookEntity = _bookRepository.Update(bookEntity);

            return _converter.Parser(bookEntity);
        }

    }
}

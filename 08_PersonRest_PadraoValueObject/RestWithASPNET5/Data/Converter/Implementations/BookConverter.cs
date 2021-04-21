using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parser(Book origem)
        {
            if (origem == null) return null;

            return new BookVO
            {
                Id = origem.Id,
                Title = origem.Title,
                Price = origem.Price,
                Autor = origem.Autor,
                LaunchDate = origem.LaunchDate
            };
        }

        public Book Parser(BookVO origem)
        {
            if (origem == null) return null;

            return new Book
            {
                Id = origem.Id,
                Title = origem.Title,
                Price = origem.Price,
                Autor = origem.Autor,
                LaunchDate = origem.LaunchDate
            };

        }

        public List<BookVO> Parser(List<Book> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parser(item)).ToList();
        }

        public List<Book> Parser(List<BookVO> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parser(item)).ToList();
        }
    }
}

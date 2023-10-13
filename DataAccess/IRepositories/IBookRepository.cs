using Entities.Dtos;
using Entities.RequestModels;

namespace DataAccess.IRepositories;

public interface IBookRepository
{
    public List<BookDto> GetBooks();
    public BookDto? GetBookById(int id);
    public BookDto AddBook(AddBookRequest request);
    public BookDto UpdateBook(BookDto request);
    public void DeleteBook(int id);
}
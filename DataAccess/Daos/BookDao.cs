using Entities.Entity;
using Entities.Migration;
using Entities.RequestModels;

namespace DataAccess.Daos;

public class BookDao
{
    public static List<Book> GetBooks()
    {
        try
        {
            using var context = new BookDbContext();
            return context.Books.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static Book? GetBookById(int id)
    {
        try
        {
            using var context = new BookDbContext();
            return context.Books.FirstOrDefault(x => x.BookId == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static Book AddBook(Book request)
    {
        try
        {
            using var context = new BookDbContext();
            context.Books.Add(request);
            context.SaveChanges();
            return request;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static Book UpdateBook(Book book)
    {
        try
        {
            using var context = new BookDbContext();
            var oldBook = context.Books.FirstOrDefault(x => x.BookId == book.BookId);
            if (oldBook == null)
                throw new Exception("Not found");
            oldBook.Title = book.Title;
            oldBook.Type = book.Type;
            oldBook.PubId = book.PubId;
            oldBook.Price = book.Price;
            oldBook.Advance = book.Advance;
            oldBook.Royalty = book.Royalty;
            oldBook.YtdSales = book.YtdSales;
            oldBook.Notes = book.Notes;
            oldBook.PublishedDate = book.PublishedDate;
            context.Books.Update(oldBook);
            context.SaveChanges();
            return oldBook;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void DeleteBook(int id)
    {
        try
        {
            using var context = new BookDbContext();
            var book = context.Books.FirstOrDefault(x => x.BookId == id);
            if (book == null)
                throw new Exception("Not found");
            context.Books.Remove(book);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
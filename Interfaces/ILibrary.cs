using Models.Book;

namespace Interfaces.ILibrary;

public interface ILibrary {
    public List<Book>? GetBooks();
    public Book? GetBookByID(int ID);
    public Book? GetBookByPublishedYear(int published_year);
    public Book? GetBookByTitle(string book_title);
    public int UpdateBook(int Id,Book book);
    public int PostBook(Book book);
    public int DeleteBook(int ID);
    public List<Book> sortBooks(string field);
}
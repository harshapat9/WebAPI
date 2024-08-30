using Interfaces.ILibrary;
using Models.Book;
using System.Reflection;

namespace Repositories.BookImplementation;

public class BookImplementation : ILibrary{
    public List<Book> books = new List<Book>();
    public List<Book> GetBooks() {
        return books;
    }
    public Book? GetBookByID(int ID) {
        Book? temp= books.Find(u=>u.ID == ID);
        return temp;
    }
    public Book? GetBookByPublishedYear(int published_year) {
        Book? temp= books.Find(u=>u.published_year == published_year);
        return temp;
    }

    public Book? GetBookByTitle(string Name)
    {
        Book? temp=null;

        foreach (Book i in books) {
            if(i.book_title.ToLower().Contains(Name.ToLower()))  temp=i;
        }
        return temp;
    }
    
    public int PostBook(Book book)
    {   
        int flag=0;
        Book? res=books.Find(u=>u.ID==book.ID);
        if(res!=null) flag = 1;
        else books.Add(book);
        return flag;
    }

    public int UpdateBook(int ID, Book book)
    {
        int flag=0;
        Book? temp = books.FirstOrDefault(u=>u.ID == ID);
        if(temp != null){
            books.Remove(temp);
            books.Add(book);
        }
        else{
            books.Add(book);
            flag=1;
        }
        return flag;
    }

    public int DeleteBook(int ID)
    {
        Book? temp=books.Find(u=>u.ID==ID);
        if(temp!=null)
            books.Remove(temp);
        else
            return -1;
        return 1;
    }

    
    public List<Book> sortBooks(string field) {
        // if(books.Count == 0) return new List<Book>();
        // List<Book> tmp = books.OrderBy(x => x.ID).ToList<Book>();
        // return tmp;


        PropertyInfo? propInfo = typeof(Book).GetProperty(field);
        if (propInfo != null && books.Count != 0) {
            List<Book> sortedBooks = books.OrderBy(b => propInfo.GetValue(b)).ToList();
            return sortedBooks;
            // System.Console.WriteLine(sortedBooks[0].ID);
        }
        else
        {
            return new List<Book>();
        }
    }
}
using Interfaces.ILibrary;
using Microsoft.AspNetCore.Mvc;
using Models.Book;

namespace Controllers;

[ApiController]
[Route("[Controller]")]

public class BookController : ControllerBase {
    private readonly ILibrary _book;
    public BookController(ILibrary book) {
        _book = book;
    }

    [HttpGet]
    public IActionResult get() {
        return Ok(_book.GetBooks());
    }

    [HttpGet("sort/{field}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult sort(string field) {
        List<Book> tmp = _book.sortBooks(field);
        Console.WriteLine(tmp[0].ID);
        return Ok(tmp);
    }


    [HttpPost]
    public IActionResult post([FromBody] Book book) {
       int rs = _book.PostBook(book);
       return (rs!=0)? Conflict($"Book already existed i.e\n {book}"):Ok($"{book}");
    }

    [HttpPut]
    public IActionResult put(int ID,[FromBody] Book book) {
        int res=_book.UpdateBook(ID, book);
        return (res==0)? Ok($"Book updated with ID : {ID}") : BadRequest($"New Book added with ID : {ID}");
    }
        
    [HttpGet("ID:{ID:int:min(1):max(100)}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetByID(int ID){
    
        Book? res=_book.GetBookByID(ID);
        
        return Ok(res);
    }

    [HttpGet("published_year:{published_year:int:min(1000):max(9999)}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetByPublishedYear(int published_year){
    
        Book? res=_book.GetBookByPublishedYear(published_year);
        
        return Ok(res);
    }

    

    [HttpDelete]
    public IActionResult delete(int ID)
    {
        int res=_book.DeleteBook(ID);
        return (res==-1)? NotFound("Book Not found to Delete") : Ok("Book Deleted Successfully");
    }
}

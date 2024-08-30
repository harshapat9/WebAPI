namespace Models.Book;

public class Book {
    public int ID { get; set; }
    public string? book_title { get; set; }
    public string? book_author { get; set; }
    public int published_year { get; set; }
    public string? book_genre { get; set; }
}
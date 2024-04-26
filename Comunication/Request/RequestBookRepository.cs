namespace ApiBookStore.Comunication.Request;

public class RequestBookRepository
{
    private static List<RequestRegisterBook> _books = new List<RequestRegisterBook>();

    public void AddBook(RequestRegisterBook book)
    {
        book.Id = _books.Count + 1;
        _books.Add(book);

    }

    public List<RequestRegisterBook> GetAllBooks()
    {
        return _books;
    }
    public RequestRegisterBook GetBookById(int id)
    {
        return _books.FirstOrDefault(book => book.Id == id);
    }
    public void RemoveBook(int id)
    {
        var bookToRemove = _books.FirstOrDefault(book => book.Id == id);
        if (bookToRemove != null)
        {
            _books.Remove(bookToRemove);
        }
    }
}

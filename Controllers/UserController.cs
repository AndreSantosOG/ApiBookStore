using ApiBookStore.Comunication.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApiBookStore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase

{
    private readonly RequestBookRepository _bookRepository;

    public UserController()
    {
        _bookRepository = new RequestBookRepository();
    }

    [HttpPost ("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] RequestRegisterBook request)
    {
        var book = new RequestRegisterBook
        {
            Title = request.Title,
            Author = request.Author,
            Gender = request.Gender,
            Price = request.Price,
            Amount = request.Amount,
        };
        _bookRepository.AddBook(book);

        return Created(string.Empty, book);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    public IActionResult GetBook()
    {
        var books = _bookRepository.GetAllBooks();
        return Ok(books);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateBook(int id, [FromBody] RequestRegisterBook request)
    {
        var existingBook = _bookRepository.GetBookById(id);
        if (existingBook == null)
        {
            return NotFound();
        }

        existingBook.Title = request.Title;
        existingBook.Author = request.Author;
        existingBook.Gender = request.Gender;
        existingBook.Price = request.Price;
        existingBook.Amount = request.Amount;

        return Ok(existingBook);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var existingBook = _bookRepository.GetBookById(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        _bookRepository.RemoveBook(id);
        return NoContent();
    }

}

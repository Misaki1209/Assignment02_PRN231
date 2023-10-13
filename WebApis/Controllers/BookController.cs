using DataAccess.IRepositories;
using Entities.Dtos;
using Entities.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace WebApis.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : Controller
{
    private IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    [EnableQuery]
    [HttpGet("Get")]
    public IActionResult GetBooks()
    {
        return Ok(_bookRepository.GetBooks());
    }

    [HttpGet("Get/{id:int}")]
    public IActionResult GetBookById(int id)
    {
        return Ok(_bookRepository.GetBookById(id));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Add")]
    public IActionResult AddBook(AddBookRequest request)
    {
        return Ok(_bookRepository.AddBook(request));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Update")]
    public IActionResult UpdateBook(BookDto bookDto)
    {
        return Ok(_bookRepository.UpdateBook(bookDto));
    } 

    [Authorize(Roles = "Admin")]
    [HttpDelete("Delete/{id:int}")]
    public IActionResult DeleteBook(int id)
    {
        _bookRepository.DeleteBook(id);
        return Ok();
    }
}
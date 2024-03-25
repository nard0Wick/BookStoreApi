using BookStoreApi.Service;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService; 

        public BookController(BookService bookService) => _bookService = bookService;

        [HttpGet]
        public async Task<List<Book>> GetBooks() => await _bookService.GetBooksAsync();
        
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Book>> GetBook(string id)
        {
            var book = await _bookService.GetBookAsync(id); 
            if(book == null)
            {
                return NotFound();
            } 
            return Ok(book);
        } 

        [HttpPost] 
        public async Task<IActionResult> AddBook(Book newBook)
        {
            await _bookService.AddBookAsync(newBook);

            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id:length(24)}")] 
        public async Task<IActionResult> UpdateBook(string id, Book updatedBook)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.UpdateBookAsync(id, updatedBook); 
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")] 
        public async Task<IActionResult> DeleteBook(string id)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            } 

            await _bookService.RemoveBookAsync(id); 
            return NoContent();
        }


    }
}

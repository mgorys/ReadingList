using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ReadingList.Abstractions.IServices;
using ReadingList.Models.Dto;
using System.Net;
using Microsoft.AspNetCore.JsonPatch;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;
using ReadingList.Entities;

namespace ReadingList.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("GetBooks")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBook()
        {
            var books =await _bookService.GetAllBooksAsync();

            return Ok(books);
        }
        [HttpGet("GetBookBy/{name}")]
        public async Task<ActionResult<BookDto>> GetBookById([FromRoute] string name)
        {
            var book = await _bookService.GetBookByNameAsync(name);

            return Ok(book);
        }
        [HttpPost("PostBook")]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookDto createDto)
        {
            await _bookService.CreateBookAsync(createDto);
            return StatusCode(201);
        }
        [HttpDelete("DeleteBook/{name}")]
        public async Task<ActionResult> DeleteBookAsync([FromRoute] string name)
        {
            await _bookService.DeleteBookAsync(name);
            return NoContent();
        }
        [HttpPut("ChangeBookFinished/{name}")]
        public async Task<ActionResult> ChangeBookFinishedAsync([FromRoute] string name, [FromBody] bool finished)
        {
            await _bookService.ChangeBookFinishedAsync(name,finished);
            return StatusCode(201);
        }
        [HttpPut("UpdateBookImg/{name}")]
        public async Task<ActionResult> UpdateBookImgAsync([FromRoute] string name, [FromBody] string updateImageUrl)
        {
            await _bookService.UpdateBookImageAsync(name, updateImageUrl);
            return StatusCode(201);
        }
        [HttpPut("MoveBookPriority/{name}")]
        public async Task<ActionResult> MoveBookPriorityAsync([FromRoute] string name, [FromBody] string move)
        {
            await _bookService.MoveBookPriorityAsync(name, move);
            return StatusCode(201);
        }
    }
}

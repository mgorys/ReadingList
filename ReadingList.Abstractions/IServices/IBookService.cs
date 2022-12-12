using ReadingList.Models.Dto;
using ReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using ReadingList.Entities;
using Microsoft.AspNetCore.JsonPatch;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace ReadingList.Abstractions.IServices
{
    public interface IBookService
    {
        Task<ServerResponse<IEnumerable<BookDto>>> GetAllBooksAsync();
        Task<ServerResponse<BookDto>> GetBookByNameAsync(string name);
        Task<ServerResponse<BookDto>> CreateBookAsync(CreateBookDto createDto);
        Task<ServerResponse<BookDto>> DeleteBookAsync(string name);
        Task<ServerResponse<BookDto>> ChangeBookFinishedAsync(string name, bool finished);
        Task<ServerResponse<BookDto>> UpdateBookImageAsync(string name, string updateImageUrl);
        Task<ServerResponse<BookDto>> ChangeBookPriorityAsync(string name, int newPriority);
    }
}

using Azure;
using ReadingList.Entities;
using ReadingList.Models;
using Microsoft.AspNetCore.JsonPatch;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace ReadingList.Abstractions.IRepositories
{
    public interface IBookRepository
    {
        Task<ServerResponse<IEnumerable<Book>>> GetAllBooksAsync();
        Task<ServerResponse<Book>> GetBookByNameAsync(string name);
        Task<ServerResponse<Book>> CreateBookAsync(Book book);
        Task<ServerResponse<Book>> DeleteBookAsync(string name);
        Task<ServerResponse<Book>> ChangeBookFinishedAsync(string name, bool finished);
        Task<ServerResponse<Book>> UpdateBookImageAsync(string name, string updateImageUrl);
        Task<ServerResponse<Book>> ChangeBookPriorityAsync(string name, Priority newPriority);
    }
}

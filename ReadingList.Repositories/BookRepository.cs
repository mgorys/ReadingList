using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using ReadingList.Abstractions.IRepositories;
using ReadingList.Entities;
using ReadingList.Models;
using ReadingList.Models.Dto;
using ReadingList.Persistence;
using Microsoft.AspNetCore.JsonPatch;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;

namespace ReadingList.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ReadingListDbContext _dbContext;

        public BookRepository(ReadingListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<ServerResponse<IEnumerable<Book>>> GetAllBooksAsync()
        {
            var response = new ServerResponse<IEnumerable<Book>>();
            var result = await _dbContext.Books.ToArrayAsync();
            
            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            response.DataFromServer = result;
            return response;
        }
        public async Task<ServerResponse<Book>> GetBookByNameAsync(string name)
        {
            var response = new ServerResponse<Book>();
            var result = await _dbContext.Books.FirstOrDefaultAsync(r => r.Name == name);

            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            response.DataFromServer = result;
            return response;
        }
        public async Task<ServerResponse<Book>> CreateBookAsync(Book book)
        {
            var response = new ServerResponse<Book>();
            if (book.Id != 0)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return response;
        }
        public async Task<ServerResponse<Book>> DeleteBookAsync(string name)
        {
            var response = new ServerResponse<Book>();
            var book = await _dbContext.Books.FirstOrDefaultAsync(r => r.Name == name);
            if(book == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return response;
        }
        public async Task<ServerResponse<Book>> ChangeBookFinishedAsync(string name, bool finished)
        {
            var response = new ServerResponse<Book>();
            var result = await _dbContext.Books.FirstOrDefaultAsync(r => r.Name == name);
            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            result.Finished = finished;
            await _dbContext.SaveChangesAsync();
            return response;
        }
        public async Task<ServerResponse<Book>> UpdateBookImageAsync(string name, string updateImageUrl)
        {
            var response = new ServerResponse<Book>();
            var result = await _dbContext.Books.FirstOrDefaultAsync(r => r.Name == name);
            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                response.Success = true;
            }
            result.ImgUrl = updateImageUrl;
            await _dbContext.SaveChangesAsync();
            return response;
        }
        
        public async Task<ServerResponse<Book>> MoveDownBookPriorityAsync(string name)
        {
            var response = new ServerResponse<Book>();
            var result = await _dbContext.Books.FirstOrDefaultAsync(r => r.Name == name);
            
            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                int resultId = result.PriorityNumber;
                var resultNeighbor = await _dbContext.Books.FirstOrDefaultAsync(n => n.PriorityNumber == resultId + 1);
                if (resultNeighbor != null)
                {
                    result.PriorityNumber++;
                    resultNeighbor.PriorityNumber--;
                }
                response.Success = true;
            }
            await _dbContext.SaveChangesAsync();
            return response;
        }
        public async Task<ServerResponse<Book>> MoveUpBookPriorityAsync(string name)
        {
            var response = new ServerResponse<Book>();
            var result = await _dbContext.Books.FirstOrDefaultAsync(r => r.Name == name);
            if (result == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                int resultId = result.PriorityNumber;
                var resultNeighbor = await _dbContext.Books.FirstOrDefaultAsync(n => n.PriorityNumber == resultId - 1);
                if (resultNeighbor != null)
                {
                    result.PriorityNumber--;
                    resultNeighbor.PriorityNumber++;
                }
                response.Success = true;
            }
            await _dbContext.SaveChangesAsync();
            return response;
        }
    }
}

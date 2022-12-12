using AutoMapper;
using Azure;
using ReadingList.Abstractions.IRepositories;
using ReadingList.Abstractions.IServices;
using ReadingList.Entities;
using ReadingList.Models;
using ReadingList.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using JsonPatchDocument = Microsoft.AspNetCore.JsonPatch.JsonPatchDocument;
using ReadingList.Infrastructure.Exceptions;

namespace ReadingList.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ServerResponse<IEnumerable<BookDto>>> GetAllBooksAsync()
        {
            var resultDto = new ServerResponse<IEnumerable<BookDto>>();
            var result = await _bookRepository.GetAllBooksAsync();
            if (result.Success == false)
                throw new NotFoundException("Sorry, books have been not found");
            resultDto.DataFromServer = _mapper.Map<IEnumerable<BookDto>>(result.DataFromServer);
            resultDto.Success = result.Success;
            return resultDto;
        }

        public async Task<ServerResponse<BookDto>> GetBookByNameAsync(string name)
        {
            var resultDto = new ServerResponse<BookDto>();
            var result = await _bookRepository.GetBookByNameAsync(name);
            if(result.Success == false)
                throw new NotFoundException("Sorry, book with that name has been not found");
            resultDto.DataFromServer = _mapper.Map<BookDto>(result.DataFromServer);
            resultDto.Success = result.Success;
            return resultDto;
        }
        public async Task<ServerResponse<BookDto>> CreateBookAsync(CreateBookDto createDto)
        {
            var resultDto = new ServerResponse<BookDto>();
            var book = new Book();
            book = _mapper.Map<Book>(createDto);
            var result = await _bookRepository.CreateBookAsync(book);
            resultDto.Success = result.Success;
            return resultDto;
        }
        public async Task<ServerResponse<BookDto>> DeleteBookAsync(string name)
        {
            var resultDto = new ServerResponse<BookDto>();
            var result = await _bookRepository.DeleteBookAsync(name);
            if (result.Success == false)
                throw new NotFoundException("Sorry, book with that name has been not found");
            resultDto.Success = result.Success;
            return resultDto;
        }
        public async Task<ServerResponse<BookDto>> ChangeBookFinishedAsync(string name, bool finished)
        {
            var resultDto = new ServerResponse<BookDto>();
            var result = await _bookRepository.ChangeBookFinishedAsync(name,finished);
            if (result.Success == false)
                throw new NotFoundException("Sorry, book with that name has been not found");
            resultDto.Success = result.Success;
            return resultDto;
        }
        public async Task<ServerResponse<BookDto>> UpdateBookImageAsync(string name, string updateImageUrl)
        {
            var resultDto = new ServerResponse<BookDto>();
            var result = await _bookRepository.UpdateBookImageAsync(name, updateImageUrl);
            if (result.Success == false)
                throw new NotFoundException("Sorry, book with that name has been not found");
            resultDto.Success = result.Success;
            return resultDto;
        }
       
        public async Task<ServerResponse<BookDto>> MoveBookPriorityAsync(string name, string move)
        {
            var resultDto = new ServerResponse<BookDto>();
            var result = new ServerResponse<Book>();
            if (move == "up")
                result = await _bookRepository.MoveUpBookPriorityAsync(name);
            else if (move == "down")
                result = await _bookRepository.MoveDownBookPriorityAsync(name);
            else
                throw new BadRequestException("Incorrect value off change");


            if (result.Success == false)
                throw new NotFoundException("Sorry, book with that name has been not found");
            resultDto.Success = result.Success;
            return resultDto;
        }
    }
}

using AutoMapper;
using ReadingList.Entities;
using ReadingList.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingList.Infrastructure.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<BookDto, Book>();
            
            CreateMap<CreateBookDto, Book>();

        }
    }
}

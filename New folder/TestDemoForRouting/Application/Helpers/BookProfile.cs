using Application.ModelDTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
   public  class BookProfile : Profile
    {
        public BookProfile()
        {
            // CreateMap<Book, BookDto>();
            // CreateMap<BookDto , Book>();

            CreateMap<Book, BookDto>()
                .ForMember(d => d.IdDto, p => p.MapFrom(s => s.Id))
                .ForMember(d => d.TitleDto, p => p.MapFrom(s => s.Title))
                .ForMember(d => d.AuthorNameDto, p => p.MapFrom(s => s.AuthorName))
                .ForMember(d => d.DateDto, p => p.MapFrom(s => s.Date))
                .ForMember(d => d.EmailDto, p => p.MapFrom(s => s.Email))
                .ReverseMap();
               
        }
    }
}

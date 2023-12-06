using AutoMapper;
using BookService.Models;

namespace webapi.Models
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Title, 
                opt => opt.MapFrom(src => $"{src.Title}")
                )
                .ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => $"{src.Author}")
                )
                .ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => $"{src.Genre}")
                );
        }
    }
}
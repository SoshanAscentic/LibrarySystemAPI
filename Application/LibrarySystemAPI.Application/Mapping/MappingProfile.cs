using AutoMapper;
using LibrarySystemAPI.Application.DTOs;
using LibrarySystemAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book mappings
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));

            // Member mappings
            CreateMap<Member, MemberDto>()
                .ForMember(dest => dest.MemberType, opt => opt.MapFrom(src => src.GetMemberType()))
                .ForMember(dest => dest.CanBorrowBooks, opt => opt.MapFrom(src => src.CanBorrowBooks()))
                .ForMember(dest => dest.CanViewBooks, opt => opt.MapFrom(src => src.CanViewBooks()))
                .ForMember(dest => dest.CanViewMembers, opt => opt.MapFrom(src => src.CanViewMembers()))
                .ForMember(dest => dest.CanManageBooks, opt => opt.MapFrom(src => src.CanManageBooks()));

            // You can add reverse mappings if needed
            // CreateMap<CreateBookDto, Book>()
            //     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (Book.BookCategory)src.Category))
            //     .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => true));
        }
    }
}

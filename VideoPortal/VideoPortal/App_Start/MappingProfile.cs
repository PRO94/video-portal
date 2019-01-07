using AutoMapper;
using VideoPortal.Models;
using VideoPortal.Models.DTOs;

namespace VideoPortal
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();

            // DTO to Domain
            CreateMap<MovieDto, Movie>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<MembershipTypeDto, MembershipType>();
            CreateMap<GenreDto, Genre>();
        }
    }
}
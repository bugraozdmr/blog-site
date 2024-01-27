using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PostDto, Post>().ReverseMap();
        CreateMap<PostDtoForInsertion, Post>().ReverseMap();
        CreateMap<PostDtoForUpdate, Post>().ReverseMap();
    }
}
using AutoMapper;
using BlogSite.Mvc.Dtos.DefaultDto;
using Entities.Models;

namespace BlogSite.Mvc.Mapping;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<MainDto, Post>().ReverseMap();
    }
}
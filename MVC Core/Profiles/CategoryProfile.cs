using AutoMapper;

namespace MVC_Core.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoriesDto>()
                .ForMember(
                    dest => dest.CatName,
                    opt => opt.MapFrom(src => src.Name)).ReverseMap();
        }
    }
}
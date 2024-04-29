using AutoMapper;
using CustomerApp.Dataa;
using CustomerApp.Models.Entities;

public class UserProfile : Profile
{
    public UserProfile()
    {
     /*   CreateMap<User, ApplicationUser>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        // Add more mappings as needed
     */
    }
}

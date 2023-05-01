using AutoMapper;
using Present.Data;
using Present.Models;

namespace Present.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //source - destination
            CreateMap<ApplicationUser, SignInModel > ()
                .ForMember(dest => dest.PassWord, opt => opt.MapFrom(src => src.PasswordHash)).ReverseMap();

            CreateMap<ApplicationUser, SignUpModel>()
                .ForMember(dest => dest.PassWord, opt => opt.MapFrom(src => src.PasswordHash)).ReverseMap();
            CreateMap<ApplicationUser, UserModel>().ReverseMap();

            CreateMap<Chat, ChatModel>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Message))
            .ForMember(dest => dest.IndividualChatId, opt => opt.MapFrom(src => src.IndividualChatId))
            .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt)); ;
                
             
        }
    }
}

using api.Dtos;
using Api.Entities;
using AutoMapper;

namespace api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {   
            CreateMap<Contatos,ContatosDto>();
            
            CreateMap<ClientApp,ClientDto>()
                .ForMember(dest => dest.contatosDto, opt => opt.MapFrom(src => src.Contatos));

            
                
        }
    }
}
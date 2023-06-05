using api.Dtos;
using Api.DTOs;
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

            CreateMap<VendaPeca,VendaPecaDto>()
                .ForMember(dest => dest.NameClient, opt => opt.MapFrom(src => src.Cliente.NameClient))
                .ForMember(dest => dest.ItemPecaDto, opt => opt.MapFrom(src => src.ItemPeca));                
                
            CreateMap<ItemPeca,ItemPecaDto>()
                .ForMember(dest => dest.NamePeca, opt => opt.MapFrom(src => src.Peca.NamePeca));
            
                
                
        }
    }
}
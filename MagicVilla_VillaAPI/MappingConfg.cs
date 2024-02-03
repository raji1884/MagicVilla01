using AutoMapper;
using MagicVilla_VillaAPI.models;
using MagicVilla_VillaAPI.models.DTO;

namespace MagicVilla_VillaAPI
{
    public class MappingConfg: Profile
    {
        public MappingConfg() 
        {
            CreateMap<Villamodel, VillaDTO>();
            CreateMap<VillaDTO,Villamodel>();

            CreateMap<Villamodel,VillaCreatDTO>().ReverseMap();
            CreateMap<Villamodel,VillaUpdateDTO>().ReverseMap();   
        }
    }
}

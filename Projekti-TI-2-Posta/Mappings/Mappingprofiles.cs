using AutoMapper;
using Projekti_TI_2_Posta.Application.Dtos.Porosia;
using Projekti_TI_2_Posta.Models.Porosia;

namespace Projekti_TI_2_Posta.Mappings
{
    public class Mappingprofiles : Profile
    {
        public Mappingprofiles()
        {
            CreateMap<GetPorosiaDto, GetPorosiaModel>().ReverseMap();
            CreateMap<CreatePorosiaDto, CreatePorosiaModel>().ReverseMap();
            CreateMap<UpdatePorosiaDto, UpdatePorosiaModel>().ReverseMap();
            CreateMap<GetPorosiaDto, UpdatePorosiaModel>().ReverseMap();
        }
    }
}

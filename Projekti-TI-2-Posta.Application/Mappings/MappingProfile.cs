using AutoMapper;
using Projekti_TI_2_Posta.Application.Dtos.Porosia;
using Projekti_TI_2_Posta.Application.Dtos;
using Projekti_TI_2_Posta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Porosia, CreatePorosiaDto>().ReverseMap();
            CreateMap<Porosia, GetPorosiaDto>().ReverseMap();
            CreateMap<Porosia, UpdatePorosiaDto>().ReverseMap();
        }
    }
}

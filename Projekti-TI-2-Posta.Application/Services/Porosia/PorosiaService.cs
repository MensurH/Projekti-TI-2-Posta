using AutoMapper;
using Projekti_TI_2_Posta.Application.Dtos.Porosia;
using Projekti_TI_2_Posta.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Application.Services.Porosia
{
    public class PorosiaService : IPorosiaService
    {
        private readonly IPorosiaRepository _repository;
        private readonly IMapper _mapper;

        public PorosiaService(IPorosiaRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public void CreatePorosi(CreatePorosiaDto porosiaDto)
        {
            var porosia = _mapper.Map<Projekti_TI_2_Posta.Domain.Entities.Porosia>(porosiaDto);
            _repository.CreatePorosi(porosia);
            
        }

        public void DeletePorosi(int id)
        {
            _repository.DeletePorosi(id);
        }

        public async Task<IEnumerable<GetPorosiaDto>> GetAllPorosi(string userid, string postierid,string search)
        {
            var porosia = await _repository.GetAllPorosi(userid,postierid,search);
            return _mapper.Map<IEnumerable<GetPorosiaDto>>(porosia);
        }


        public async Task<GetPorosiaDto> GetPorosiById(int id)
        {
            var porosia = await _repository.GetPorosiaById(id);
            return _mapper.Map<GetPorosiaDto>(porosia);
        }

        public void UpdatePorosi(UpdatePorosiaDto updatePorosia)
        {
            var updateporosi = _mapper.Map<Projekti_TI_2_Posta.Domain.Entities.Porosia>(updatePorosia);
            _repository.UpdatePorosi(updateporosi);
        }
    }
}

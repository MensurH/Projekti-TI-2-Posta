using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekti_TI_2_Posta.Application.Dtos.Porosia;
using Projekti_TI_2_Posta.Application.Services.Porosia;
using Projekti_TI_2_Posta.Infrastructure.Identity;
using Projekti_TI_2_Posta.Models.Porosia;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace Projekti_TI_2_Posta.Controllers
{
    public class PorosiaController : Controller
    {
        private readonly IPorosiaService _service;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public PorosiaController(IPorosiaService service, IMapper mapper, UserManager<AppUser> usermanager)
        {
            _service = service;
            _mapper = mapper;
            _userManager = usermanager;
        }


        [HttpGet]
        [Route("Porosia")]
        public async Task<IActionResult> GetAllPorosi(string id, string id2, string search, int? page)
        {
            var porosi = await _service.GetAllPorosi(id, id2, search);
            var model = _mapper.Map<IEnumerable<GetPorosiaModel>>(porosi);
            return View(model.ToPagedList(page ?? 1, 4));
        }


        [HttpGet]
        [Authorize(Roles ="Customer")]
        public IActionResult CreatePorosi()
        {
            return View(new CreatePorosiaModel());
        }


        [HttpPost]
        public IActionResult CreatePorosiModel(CreatePorosiaModel model)
        {
            model.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                var porosi = _mapper.Map<CreatePorosiaDto>(model);
                _service.CreatePorosi(porosi);
                return RedirectToAction("GetAllPorosi", new { @id = model.UserID });
            }
            return View("CreatePorosi");
        }


        [HttpGet]
        [Route("Porosia/Delete/{id}")]
        public async Task<IActionResult> DeletePorosiById(int id)
        {
            var porosi = await _service.GetPorosiById(id);
            var model = _mapper.Map<GetPorosiaModel>(porosi);
            return View(model);

        }

        [HttpPost]
        public IActionResult DeletePorosiByIdPost(int ID)
        {
            _service.DeletePorosi(ID);
            return RedirectToAction("GetAllPorosi");
        }


        [HttpGet]
        [Route("Porosia/Edit/{id}")]
        public async Task<IActionResult> UpdatePorosiById(int ID)
        {
            var postier = _userManager.GetUsersInRoleAsync("Postier").Result;
            ViewBag.Postierat = new SelectList(postier, "Id", "Email");
            var porosi = await _service.GetPorosiById(ID);
            var model = _mapper.Map<UpdatePorosiaModel>(porosi);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdatePorosiModel(UpdatePorosiaModel model)
        {
            if (ModelState.IsValid)
            {
                var update = _mapper.Map<UpdatePorosiaDto>(model);
                update.ERegjistruar = true;
                _service.UpdatePorosi(update);
                return RedirectToAction("GetAllPorosi");
            }
            return View("UpdatePorosiById");
        }

        [HttpPost]
        public IActionResult UpdatePorosiModel2(UpdatePorosiaModel model)
        {
            if (ModelState.IsValid)
            {
                var update = _mapper.Map<UpdatePorosiaDto>(model);
                update.EDerguar = true;
                _service.UpdatePorosi(update);
                return RedirectToAction("GetAllPorosi", new { @id2 = model.PostierID });
            }
            return View("UpdatePorosiById");
        }

    }
}

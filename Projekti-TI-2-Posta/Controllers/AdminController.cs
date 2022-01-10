using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekti_TI_2_Posta.Application.Services.Porosia;
using Projekti_TI_2_Posta.Infrastructure.Identity;
using Projekti_TI_2_Posta.Models.Admin;
using Projekti_TI_2_Posta.Models.Porosia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projekti_TI_2_Posta.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPorosiaService _service;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IPorosiaService service, IMapper mapper, UserManager<AppUser> usermanager, RoleManager<IdentityRole> roleManager)
        {
            _service = service;
            _mapper = mapper;
            _userManager = usermanager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(string postierId,
        string userId, string w)
        {
            var porosit = await _service.GetAllPorosi(userId, postierId, w);

            var customers = _userManager.GetUsersInRoleAsync("Customer").Result;
            var postier = _userManager.GetUsersInRoleAsync("Postier").Result;
            ViewBag.PorositERegjistruara = porosit.Count();
            ViewBag.PorositEDerguara = porosit.Where(x => x.EDerguar == true).Count();
            ViewBag.Postierat = postier.Count();
            ViewBag.Konsumatoret = customers.Count();

            postierId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var porositepostierit = await _service.GetAllPorosi(userId, postierId, w);
            ViewBag.PostierDerguar = porositepostierit.Where(x => x.EDerguar == true).Count();
            ViewBag.PostierPaDerguar = porositepostierit.Where(x => x.EDerguar == false).Count();
            ViewBag.PostierPorosit = porositepostierit.Count();

            userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var porositeklientit = await _service.GetAllPorosi(userId, w, "");
            ViewBag.KlientRegjistruar = porositeklientit.Where(x => x.ERegjistruar == true).Count();
            ViewBag.KlientPaRegjistruar = porositeklientit.Where(x => x.ERegjistruar == false).Count();
            ViewBag.KlientPorosit = porositeklientit.Count();
            ViewBag.KlientDerguar = porositeklientit.Where(x => x.EDerguar == true).Count();

            var model = new DashboardViewModel
            {
                Porosiat = _mapper.Map<IEnumerable<GetPorosiaModel>>(porosit),
                PorosiatByUser = _mapper.Map<IEnumerable<GetPorosiaModel>>(porositeklientit),
                PorosiatByPostier = _mapper.Map<IEnumerable<GetPorosiaModel>>(porositepostierit)
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _userManager.GetUsersInRoleAsync("Customer").Result;
            return View(customers);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetPostier()
        {
            var postier = _userManager.GetUsersInRoleAsync("Postier").Result;
            return View(postier);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RegisterPostier()
        {
            return View(new RegisterPostierViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPostierPost(RegisterPostierViewModel model)
        {
            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Postier");
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

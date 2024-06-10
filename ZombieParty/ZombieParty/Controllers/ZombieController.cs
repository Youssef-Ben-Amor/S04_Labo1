using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieController : Controller
    {
        private readonly ZombiePartyDbContext _context;

        public ZombieController(ZombiePartyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Zombie> zombiesList = _context.Zombie.ToList();
            return View(zombiesList);
        }

        public IActionResult Create()
        {
            ZombieVM zombieVM = new ZombieVM();
            zombieVM.ZombieTypeSelectList = _context.ZombieType.Select(t => new SelectListItem
            {
                Text = t.TypeName,
                Value = t.Id.ToString()
            }).OrderBy(t => t.Text);
            return View(zombieVM);

        }

        [HttpPost]
        public IActionResult Create(ZombieVM zombieVM)
        {
            //Si le modèle est valide le zombie est ajouté et nous sommes redirigé vers index.
            if (ModelState.IsValid)
            {
                _context.Zombie.Add(zombieVM.Zombie);
                _context.SaveChanges();
                TempData["Success"] = $"Zombie {zombieVM.Zombie.Name} added";
                return this.RedirectToAction("Index");
            }
            zombieVM.ZombieTypeSelectList = _context.ZombieType.Select(t => new SelectListItem
            {
                Text = t.TypeName,
                Value = t.Id.ToString()
            }).OrderBy(t => t.Text);


            return View(zombieVM);
        }

    }
}

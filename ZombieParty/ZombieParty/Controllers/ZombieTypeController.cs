﻿using Microsoft.AspNetCore.Mvc;
using System;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private readonly ZombiePartyDbContext _context;

        public ZombieTypeController(ZombiePartyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ZombieType> zombieTypesList = _context.ZombieType.ToList();

            return View(zombieTypesList);
        }

        public IActionResult Details(int id)
        {
            var zombies = _context.Zombie.Where(z => z.ZombieTypeId == id);

            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = new(),
                ZombiesList = zombies.ToList(),
                ZombiesCount = zombies.Count(),
                PointsAverage = zombies.Average(p => p.Point)
            };

            zombieTypeVM.ZombieType = _context.ZombieType.FirstOrDefault(zt => zt.Id == id);
            return View(zombieTypeVM);
        }


        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _context.ZombieType.Add(zombieType);
                _context.SaveChanges();
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");
            }

            return this.View(zombieType);
        }

    }
}

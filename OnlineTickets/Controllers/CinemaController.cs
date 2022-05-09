﻿using Microsoft.AspNetCore.Mvc;
using OnlineTickets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext _context;

        public CinemaController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Cinemas.ToList();
            return View(data);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineTickets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data.Base;
using OnlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTickets.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor>, IActorsService
    {

        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context) : base(context) { }
    }
}

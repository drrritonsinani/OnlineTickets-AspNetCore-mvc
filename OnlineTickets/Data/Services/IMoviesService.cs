using OnlineTickets.Data.Base;
using OnlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
    }
}

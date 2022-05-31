﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data.Base;
using OnlineTickets.Data.ViewModels;
using OnlineTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context):base(context)
        {
            _context = context;
        }

        
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.ActorsMovies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                MovieUrl = data.MovieUrl,
                ProducerId = data.ProducerId,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Category = data.Category
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Movie actors
            foreach(var actorId in data.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.ActorsMovies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name="Movie name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Movie description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie poster is required")]
        [Display(Name = "Movie poster")]
        public string MovieUrl { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Select a category")]
        public MovieCategory Category { get; set; }


        //Relationships
        [Required(ErrorMessage = "Movie actors is required")]
        [Display(Name = "Select actors")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Movie cinema is required")]
        [Display(Name = "Select a cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Movie producer is required")]
        [Display(Name = "Select a producer")]
        public int ProducerId { get; set; }
        
    }
}

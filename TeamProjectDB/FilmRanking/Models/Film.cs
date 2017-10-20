using FilmRanking.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmRanking.Models
{
    public class Film
    {
        private ICollection<Actor> actors;

        public Film()
        {
            this.actors = new HashSet<Actor>();
        }
        
        public int Id { get; set; }

        [Range(1.0, 5.0, ErrorMessage = "The rate is not in range [1:5]!")]
        public double Rate { get; set; }
        
        public Genre Genre { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "First title is not in range[1:50]")]
        public string Title { get; set; }

        public virtual ICollection<Actor> Actors
        {
            get
            {
                return this.actors;
            }
            set
            {
                this.actors = value;
            }
        }

        public int? DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public int? StudioId { get; set; }

        public virtual Studio Studio { get; set; }
        
    }
}

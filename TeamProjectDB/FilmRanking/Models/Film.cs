using FilmRanking.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double Rate { get; set; }

        public Genre Genre { get; set; }

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

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
        public Film()
        {
        }
        
        public int Id { get; set; }

        public Genre Genre { get; set; }

        public string Title { get; set; }

        [NotMapped]
        public virtual ICollection<Actor> Actors { get; set; }

        [NotMapped]
        public  Director Director { get; set; }

        [NotMapped]
        public Studio Studio { get; set; }

        
    }
}

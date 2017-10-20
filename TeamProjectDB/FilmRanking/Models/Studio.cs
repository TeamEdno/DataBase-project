using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmRanking.Models
{
    public class Studio
    {
        private ICollection<Film> films;

        public Studio()
        {
            this.films = new HashSet<Film>();
        }

        public int Id { get; set; }

        [StringLength(35, MinimumLength = 1, ErrorMessage = "Length of studio's name is not in range[1:35]")]
        public string Name { get; set; }

        [Range(1800, 2150, ErrorMessage = "The year of studio's establishment is not in range!")]
        public int? YearEstablished { get; set; }

        public string Trivia { get; set; }

        public virtual ICollection<Film> Films
        {
            get
            {
                return this.films;
            }
            set
            {
                this.films = value;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Models
{
    public class Director
    {
        private ICollection<Film> films;

        public Director()
        {
            this.films = new HashSet<Film>();
        }

        public int Id { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "First name's length is not in range[1:25]")]
        public string FirstName { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "Last name's length is not in range[1:25]")]
        public string LastName { get; set; }

        [Range(1800, 2015, ErrorMessage = "Year of birth is not in range!")]
        public int? YearBorn { get; set; }

        public string ShortBio { get; set; }

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

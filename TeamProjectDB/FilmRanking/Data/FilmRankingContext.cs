using FilmRanking.Models;
using System.Data.Entity;

namespace FilmRanking.Data
{
    public class FilmRankingContext : DbContext, IFilmMakingContext
    {
        public FilmRankingContext()
            : base("FilmRankingConnection")
        {
        }

        public IDbSet<Film> Films { get; set; }
        public IDbSet<Director> Directors { get; set; }
        public IDbSet<Studio> Studios { get; set; }
        public IDbSet<Actor> Actors { get; set; }


    }
}

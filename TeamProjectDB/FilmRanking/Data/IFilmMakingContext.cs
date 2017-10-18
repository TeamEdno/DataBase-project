using FilmRanking.Models;
using System.Data.Entity;

namespace FilmRanking.Data
{
    public interface IFilmMakingContext
    {

        IDbSet<Film> Films { get; set; }
        IDbSet<Director> Directors { get; set; }
        IDbSet<Studio> Studios { get; set; }
        IDbSet<Actor> Actors { get; set; }

        int SaveChanges();
    }
}

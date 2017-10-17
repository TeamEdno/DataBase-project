using FilmRanking.Models;
using FilmRanking.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.BusinessLogic.Providers.Factories.Contracts
{
    public interface IFilmRankingFactory
    {
        Film CreateFilm(string Title, Genre genre);
        Actor AddActorToFilm(string FirstName, string LastName, int YearBorn, string ShortBio, );

    }
}

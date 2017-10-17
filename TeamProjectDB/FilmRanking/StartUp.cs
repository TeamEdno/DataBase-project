using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FilmRanking.Data;
using FilmRanking.Migrations;
using FilmRanking.Models;

namespace FilmRanking
{
    class StartUp
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilmRankingContext, Configuration>());

            using (var context = new FilmRankingContext())
            {
                context.Actors.ToList();

                //var studio = new Models.Studio();
                //studio.Name = "PeshoEnt";
                //studio.YearEstablished = 1987;
                //context.Studios.Add(studio);

                //var director = new Models.Director();
                //director.FirstName = "Pencho";
                //director.LastName = "Kobadynski";
                //director.YearBorn = 1980;
                //context.Directors.Add(director);

                //var film = new Film();
                //film.Genre = Models.Enums.Genre.Action;
                //film.Title = "Adventures of Little Mock";
                //film.Director = director;
                //film.Studio = studio;
                //context.Films.Add(film);

                //context.SaveChanges();
            }
        }
    }
}

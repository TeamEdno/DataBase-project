using FilmRanking.Data;
using FilmRanking.Models;
using System;

namespace FilmRanking.Commands.Modifying
{
    public class AddFilmToDataBaseCommand
    {
        private readonly IFilmMakingContext context;

        public AddFilmToDataBaseCommand(IFilmMakingContext context)
        {
            this.context = context;
        }


        public void AddToDB(Film film)
        {
            this.context.Films.Add(film);
            this.context.SaveChanges();

            var filmID = film.Id;
            //should check if it works

            Console.WriteLine("Film with ID {0} was added to Database", filmID);

        }
    }
}

using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using FilmRanking.Models;
using FilmRanking.Models.Enums;
using System;

namespace FilmRanking.Commands.Modifying
{
    public class AddFilmToDataBaseCommand: ICommand
    {
        private IFilmMakingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public AddFilmToDataBaseCommand(IFilmMakingContext context, GraphicInterfaces interfaceGenerator, IReader reader, IWriter writer)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Execute()
        {
            writer.Write(interfaceGenerator.CreateGeneralInstructions());

            writer.Write(interfaceGenerator.Title());
            string title = Console.ReadLine();

            writer.Write(interfaceGenerator.Genre());
            string genreInput = Console.ReadLine();
            Genre genre = (Genre)Enum.Parse(typeof(Genre), genreInput);

            var film = new Film();
            film.Title = title;
            film.Genre = genre;

            this.context.Films.Add(film);
            this.context.SaveChanges();

            var filmID = film.Id;

            writer.Write($"Film with ID {filmID} was added to Database");

        }
    }
}

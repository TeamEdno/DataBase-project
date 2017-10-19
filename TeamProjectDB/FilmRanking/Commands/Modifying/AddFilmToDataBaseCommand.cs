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
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public AddFilmToDataBaseCommand(FilmRankingContext context,
            GraphicInterfaces interfaceGenerator,
            IReader reader,
            ICommandFactory factory)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = factory.CreateWriter("ConsoleWriter");
        }

        public void Execute()
        {
            this.writer.Write(this.interfaceGenerator.CreateGeneralInstructions());

            this.writer.Write(this.interfaceGenerator.Title());
            string title = this.reader.Read();

            this.writer.Write(this.interfaceGenerator.Genre());
            string genreInput = this.reader.Read();
            Genre genre = (Genre)Enum.Parse(typeof(Genre), genreInput);

            this.writer.Write(this.interfaceGenerator.Rate());
            double rate = double.Parse(this.reader.Read());

            var film = new Film();
            film.Title = title;
            film.Genre = genre;
            film.Rate = rate;

            this.context.Films.Add(film);
            this.context.SaveChanges();

            var filmID = film.Id;

            this.writer.Write($"Film with ID {filmID} was added to Database");

        }
    }
}

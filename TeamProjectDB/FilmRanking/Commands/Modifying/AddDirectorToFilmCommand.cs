using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using FilmRanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Commands.Modifying
{
    public class AddDirectorToFilmCommand : ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public AddDirectorToFilmCommand(FilmRankingContext context,
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

            var director = new Director();

            this.writer.Write(this.interfaceGenerator.FName());
            director.FirstName = this.reader.Read();

            this.writer.Write(this.interfaceGenerator.LName());
            director.LastName = this.reader.Read();

            this.writer.Write(this.interfaceGenerator.YBorn());
            director.YearBorn = int.Parse(reader.Read());

            this.writer.Write(this.interfaceGenerator.SBio());
            director.ShortBio = this.reader.Read();

            this.writer.Write(this.interfaceGenerator.ToWhichFilm());
            var filmTitle = this.reader.Read();

            Film currentFilm;

            try
            {
                currentFilm = this.context.Films.Where(f => f.Title == filmTitle).First();
            }
            catch (Exception)
            {
                throw new Exception("Film with this title can't found in the database");
            }

            currentFilm.Director = director;
            this.context.SaveChanges();

            this.writer.Write($"Director {director.FirstName} {director.LastName} is added to movie {filmTitle}.");

        }
    }
}

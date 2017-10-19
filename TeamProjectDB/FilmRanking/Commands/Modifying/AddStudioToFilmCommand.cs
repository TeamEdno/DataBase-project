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
    public class AddStudioToFilmCommand : ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public AddStudioToFilmCommand(FilmRankingContext context,
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
            this.writer.Write(interfaceGenerator.CreateGeneralInstructions());

            var studio = new Studio();

            this.writer.Write(this.interfaceGenerator.Name());
            studio.Name = this.reader.Read();

            this.writer.Write(this.interfaceGenerator.YEstablished());
            studio.YearEstablished = int.Parse(this.reader.Read());

            this.writer.Write(this.interfaceGenerator.Trivia());
            studio.Trivia = this.reader.Read();

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

            currentFilm.Studio = studio;
            this.context.SaveChanges();

            this.writer.Write($"Studio {studio.Name} is added to movie: {filmTitle}.");

        }
    }
}

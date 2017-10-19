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

        public AddStudioToFilmCommand(IFilmRankingContext context,
            GraphicInterfaces interfaceGenerator, IReader reader, IWriter writer)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Execute()
        {
            writer.Write(interfaceGenerator.CreateGeneralInstructions());

            var studio = new Studio();

            writer.Write(interfaceGenerator.Name());
            studio.Name = reader.Read();

            writer.Write(interfaceGenerator.YEstablished());
            studio.YearEstablished = int.Parse(reader.Read());

            writer.Write(interfaceGenerator.Trivia());
            studio.Trivia = reader.Read();

            writer.Write(interfaceGenerator.ToWhichFilm());
            var filmTitle = reader.Read();

            Film currentFilm;

            try
            {
                currentFilm = context.Films.Where(f => f.Title == filmTitle).First();
            }
            catch (Exception)
            {
                throw new Exception("Film with this title can't found in the database");
            }

            currentFilm.Studio = studio;
            context.SaveChanges();

            writer.Write($"Studio {studio.Name} is added to movie: {filmTitle}.");

        }
    }
}

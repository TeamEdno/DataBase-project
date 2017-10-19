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

        public AddDirectorToFilmCommand(IFilmRankingContext context,
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

            var director = new Director();

            writer.Write(interfaceGenerator.FName());
            director.FirstName = reader.Read();

            writer.Write(interfaceGenerator.LName());
            director.LastName = reader.Read();

            writer.Write(interfaceGenerator.YBorn());
            director.YearBorn = int.Parse(reader.Read());

            writer.Write(interfaceGenerator.SBio());
            director.ShortBio = reader.Read();

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

            currentFilm.Director = director;
            context.SaveChanges();

            writer.Write($"Director {director.FirstName} {director.LastName} is added to movie {filmTitle}.");

        }
    }
}

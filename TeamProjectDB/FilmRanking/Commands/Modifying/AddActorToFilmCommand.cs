using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using FilmRanking.Models;
using System;
using System.Linq;

namespace FilmRanking.Commands.Modifying
{
    public class AddActorToFilmCommand :ICommand
    {
        private readonly FilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public AddActorToFilmCommand(FilmRankingContext context, 
            GraphicInterfaces interfaceGenerator, IReader reader, IWriter writer)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = writer;
        }
        public void Execute()
        {
            Console.WriteLine(interfaceGenerator.CreateGeneralInstructions());

            var actor = new Actor();
            writer.Write(interfaceGenerator.FName());
            actor.FirstName = reader.Read();

            writer.Write(interfaceGenerator.LName());
            actor.LastName = reader.Read();

            writer.Write(interfaceGenerator.YBorn());
            actor.YearBorn = int.Parse(reader.Read());

            writer.Write(interfaceGenerator.SBio());
            actor.ShortBio = reader.Read();

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

            currentFilm.Actors.Add(actor);

            writer.Write($"Actor {actor.FirstName} {actor.LastName} is added to film {filmTitle}.");

        }
    }
}

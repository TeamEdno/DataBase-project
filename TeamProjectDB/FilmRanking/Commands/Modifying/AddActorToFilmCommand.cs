using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using FilmRanking.Models;
using System;
using System.Linq;

namespace FilmRanking.Commands.Modifying
{
    public class AddActorToFilmCommand
    {
        private readonly FilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;

        public AddActorToFilmCommand(FilmRankingContext context, GraphicInterfaces interfaceGenerator, IReader reader)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
        }
        public void Execute(Actor actor)
        {
            Console.WriteLine(interfaceGenerator.ToWhichFilm());
            var filmTitle = reader.Read();

            Film currentFilm;
            try
            {
                currentFilm = context.Films.Where(f => f.Title == filmTitle).First();
                currentFilm.Actors.Add(actor);

                Console.WriteLine("Actor {0} {1} is added to film {2}.",
                    actor.FirstName,
                    actor.LastName,
                    filmTitle);
            }
            catch (Exception)
            {
                throw new Exception("Film with this title can't found in the database");
            }

            
        }
    }
}

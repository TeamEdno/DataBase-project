using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Commands.Modifying
{
    class DeleteFilmCommand
    {

        private readonly IFilmMakingContext context;
        private readonly GraphicInterfaces interfaceGenerator;

        public DeleteFilmCommand(IFilmMakingContext context, GraphicInterfaces interfaceGenerator)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
        }


        public void RateFilm()
        {
            Console.WriteLine(interfaceGenerator.Title());
            string filmTitle = Console.ReadLine();
            var movietoRemove = this.context.Films.Single(x => x.Title == filmTitle);
            this.context.Films.Remove(movietoRemove);
            this.context.SaveChanges();

        }
    }
}


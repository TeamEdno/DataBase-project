using FilmRanking.Data;
using FilmRanking.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Commands.Modifying
{
    class RateFilmCommand
    {
        private readonly IFilmMakingContext context;
        private readonly GraphicInterfaces interfaceGenerator;

        public RateFilmCommand(IFilmMakingContext context, GraphicInterfaces interfaceGenerator)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
        }


        public void RateFilm()
        {
            Console.WriteLine(interfaceGenerator.Title());
            string filmTitle = Console.ReadLine();
            Console.WriteLine(interfaceGenerator.Rate());
            double rate = double.Parse(Console.ReadLine());
            var rateMovie = this.context.Films.Single(x => x.Title == filmTitle);
            rateMovie.Rate = rate;
            this.context.SaveChanges();

        }
    }
}

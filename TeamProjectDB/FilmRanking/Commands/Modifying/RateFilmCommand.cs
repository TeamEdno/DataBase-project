using FilmRanking.BusinessLogic.Providers.Contracts;
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
    public class RateFilmCommand: ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public RateFilmCommand(IFilmRankingContext context,
            GraphicInterfaces interfaceGenerator, IReader reader, IWriter writer)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Execute()
        {
            writer.Write(interfaceGenerator.RatingGeneralInstructions());
            string filmTitle = Console.ReadLine();

            writer.Write(interfaceGenerator.Rate());
            double rate = double.Parse(reader.Read());

            var movieToRate = this.context.Films.Single(x => x.Title == filmTitle);
            movieToRate.Rate = rate;

            this.context.SaveChanges();

            writer.Write($"The rating of the moview {filmTitle} was changed to {rate}.");
        }

    }
}

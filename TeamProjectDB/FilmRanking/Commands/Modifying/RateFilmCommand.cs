using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using System.Linq;

namespace FilmRanking.Commands.Modifying
{
    public class RateFilmCommand: ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public RateFilmCommand(FilmRankingContext context,
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
            this.writer.Write(this.interfaceGenerator.RatingGeneralInstructions());
            string filmTitle = this.reader.Read();

            this.writer.Write(this.interfaceGenerator.Rate());
            double rate = double.Parse(this.reader.Read());

            var movieToRate = this.context.Films.Single(x => x.Title == filmTitle);
            movieToRate.Rate = rate;

            this.context.SaveChanges();

            this.writer.Write($"The rating of the moview {filmTitle} was changed to {rate}.");
        }

    }
}

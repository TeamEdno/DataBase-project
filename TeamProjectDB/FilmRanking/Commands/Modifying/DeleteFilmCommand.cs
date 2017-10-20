using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using System.Linq;

namespace FilmRanking.Commands.Modifying
{
    public class DeleteFilmCommand : ICommand
    {

        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public DeleteFilmCommand(FilmRankingContext context,
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
            this.writer.Write(this.interfaceGenerator.DeletingGeneralInstructions());
            string filmTitle = this.reader.Read();

            var movietoRemove = this.context.Films.Single(x => x.Title == filmTitle);
            this.context.Films.Remove(movietoRemove);
            this.context.SaveChanges();

            this.writer.Write($"Movie with title {filmTitle} was removed.");
        }

        
    }
}


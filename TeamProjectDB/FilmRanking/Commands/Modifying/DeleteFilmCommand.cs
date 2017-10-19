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
    public class DeleteFilmCommand : ICommand
    {

        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public DeleteFilmCommand(IFilmRankingContext context,
            GraphicInterfaces interfaceGenerator, IReader reader, IWriter writer)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Execute()
        {
            writer.Write(interfaceGenerator.DeletingGeneralInstructions());
            string filmTitle = reader.Read();

            var movietoRemove = this.context.Films.Single(x => x.Title == filmTitle);
            this.context.Films.Remove(movietoRemove);
            this.context.SaveChanges();

            writer.Write($"Movie with title {filmTitle} was removed.");
        }

        
    }
}


using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Commands.Listing
{
    public class ListFilmCommand : ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public ListFilmCommand(IFilmRankingContext context,
            GraphicInterfaces interfaceGenerator, IReader reader, IWriter writer)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Execute()
        {
            this.writer.Write(this.interfaceGenerator.ListGeneralInstructions());
            var topX = int.Parse(this.reader.Read());

            var selectedCollection = this.context.Films.OrderByDescending(f => f.Rate).Take(topX).ToList();

            foreach (var item in selectedCollection)
            {
                this.writer.Write($"{item.Title} with rating: {item.Rate}");
            }
        }
    }
}

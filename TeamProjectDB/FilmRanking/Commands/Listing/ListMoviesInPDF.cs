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
    public class ListMoviesInPDF : ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;
        private ICommandFactory factory;

        public ListMoviesInPDF(FilmRankingContext context,
            GraphicInterfaces interfaceGenerator,
            IReader reader,
            ICommandFactory factory)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = factory.CreateWriter("ConsoleWriter");
            this.factory = factory;
        }

        public void Execute()
        {
            this.writer.Write(this.interfaceGenerator.CreatePDFListOfTopMovies());
            var topX = int.Parse(this.reader.Read());

            this.writer = this.factory.CreateWriter("PDFWriter");

            var selectedCollection = this.context.Films.OrderByDescending(f => f.Rate).Take(topX).ToList();

            StringBuilder pdfInfo = new StringBuilder();

            foreach (var item in selectedCollection)
            {
                pdfInfo.AppendLine($"{item.Title} with rating: {item.Rate}" );
                pdfInfo.AppendLine("______________________________________________________________________________");
            }
            this.writer.Write(pdfInfo.ToString());

            this.writer = factory.CreateWriter("ConsoleWriter");
            this.writer.Write("Your PDF has beed generated");
        }
    }
}

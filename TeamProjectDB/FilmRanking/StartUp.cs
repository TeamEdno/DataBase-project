using FilmRanking.BusinessLogic.Contracts;
using FilmRanking.BusinessLogic.Providers.Parsers;
using FilmRanking.Data;
using FilmRanking.Ninject;
using Ninject;
using System.Linq;

namespace FilmRanking
{
    class StartUp
    {
        static void Main()
        {
            var kernel = new StandardKernel(new FilmRankingModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Run();

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilmRankingContext, Configuration>());


            //PDFWriter writer = new PDFWriter("../../../TextFiles/PDFReport.pdf");
            //StringBuilder text=new StringBuilder();
            //for(int i = 0; i <= 20; i++)
            //{
            //    text.AppendLine("text text text text text");
            //    text.AppendLine("________________________________________");
            //}

            //writer.Write(text.ToString());





            //using (var context = new FilmRankingContext())
            //{
            //    XMLParser xmlParse = new XMLParser("../../../TextFiles/XMLFile.xml", context);
            //    xmlParse.Parse();
            //    //JSONParser jsonParse = new JSONParser("../../../TextFiles/JSONFile.JSON", context);
            //    //jsonParse.Parse();

            //}

            //using (var context = new FilmRankingContext())
            //{
            //    var movie = context.Films.Single(x => x.Title == "Title1");
            //    context.Films.Remove(movie);
            //    context.SaveChanges();
            //}


            //GraphicInterfaces interfaces = new GraphicInterfaces();
            //ConsoleReader reader = new ConsoleReader();
            //Engine myOneEngine = new Engine(reader, interfaces);
            //myOneEngine.Run();
        }
    }
}

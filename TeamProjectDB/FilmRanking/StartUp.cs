using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FilmRanking.Data;
using FilmRanking.Migrations;
using FilmRanking.Models;
using FilmRanking.BusinessLogic.Contracts;
using FilmRanking.BusinessLogic.Providers.Readers;
using FilmRanking.GUI;
using Ninject;
using FilmRanking.Ninject;
using FilmRanking.BusinessLogic.Providers.Parsers;

namespace FilmRanking
{
    class StartUp
    {
        static void Main()
        {
            //PDFWriter writer = new PDFWriter("../../../TextFiles/PDFReport.pdf");
            //StringBuilder text=new StringBuilder();
            //for(int i = 0; i <= 20; i++)
            //{
            //    text.AppendLine("text text text text text");
            //    text.AppendLine("________________________________________");
            //}

            //writer.Write(text.ToString());




            var kernel = new StandardKernel(new FilmRankingModule());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilmRankingContext, Configuration>());

            using (var context = new FilmRankingContext())
            {
                JSONParser jsonParse = new JSONParser("../../../TextFiles/JSONFile.JSON", context);
                jsonParse.Parse();
                //var studio = new Studio();
                //studio.Name = "PeshoEnt";
                //studio.Trivia = "sometihng";
                //studio.YearEstablished = 1999;
                //context.Studios.Add(studio);

                //var director = new Director();
                //director.FirstName = "Pencho";
                //director.LastName = "Kobadynski";
                //director.YearBorn = 1980;
                //context.Directors.Add(director);


                //var film = new Film();
                //film.Genre = Models.Enums.Genre.Action;
                //film.Title = "Adventures of Little Mock";
                //film.Director = director;
                //film.Studio = studio;
                //context.Films.Add(film);
            }


            //GraphicInterfaces interfaces = new GraphicInterfaces();
            //ConsoleReader reader = new ConsoleReader();
            //Engine myOneEngine = new Engine(reader, interfaces);
            //myOneEngine.Run();
        }
    }
}

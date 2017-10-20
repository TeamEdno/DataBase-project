using FilmRanking.BusinessLogic.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRanking.GUI;
using FilmRanking.Commands.Modifying;
using FilmRanking.Data;
using FilmRanking.BusinessLogic.Providers.Parsers;

namespace FilmRanking.BusinessLogic.Contracts
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private GraphicInterfaces interfaceGenerator;
        private ICommandFactory factory;
        private IWriter writer;


        public Engine(IReader reader, GraphicInterfaces interfaceGenerator, ICommandFactory factory)
        {
            this.reader = reader;
            this.interfaceGenerator = interfaceGenerator;
            this.factory = factory;
            this.writer = this.factory.CreateWriter("ConsoleWriter");
        }

        public void Run()
        {
            this.writer.Write(interfaceGenerator.MainMenuInterface());
            string userChoice = this.reader.Read();
            switch (userChoice)
            {
                case "1":
                    this.CreateFilmAndAddToDB();
                    break;
                case "2":
                    this.AddActorToFilm();
                    break;
                case "3":
                    this.AddDirectorToFilm();
                    break;
                case "4":
                    this.AddStudioToFilm();
                    break;
                case "5":
                    this.RateMovie();
                    break;
                case "6":
                    this.DeleteMovie();
                    break;
                case "7":
                    this.ListTopFilms();
                    break;
                case "8":
                    this.ListInPDF();
                    break;
                case "9":
                    this.ReadFromFiles();
                    break;
                case "0":
                    this.writer.Write("Exitted");
                    break;
                default:
                    this.writer.Write("Wrong move 'bud'!");
                    this.Run();
                    break;
            }
        }

        private void CreateCommand()
        {

        }

        private void CreateFilmAndAddToDB()
        {

            var command = this.factory.CreateCommand("AddFilmToDataBase");
            command.Execute();
            this.Run();
        }

        private void AddActorToFilm()
        {
            var command = this.factory.CreateCommand("AddActorToFilm");
            command.Execute();
            this.Run();
        }

        private void AddDirectorToFilm()
        {
            var command = this.factory.CreateCommand("AddDirectorToFilm");
            command.Execute();
            this.Run();
        }

        private void AddStudioToFilm()
        {
            var command = this.factory.CreateCommand("AddStudioToFilm");
            command.Execute();
            this.Run();
        }

        private void DeleteMovie()
        {
            var command = this.factory.CreateCommand("DeleteFilm");
            command.Execute();
            this.Run();
        }
        private void RateMovie()
        {
            var command = this.factory.CreateCommand("RateFilm");
            command.Execute();
            this.Run();
        }
        private void ListTopFilms()
        {
            var command = this.factory.CreateCommand("ListFilm");
            command.Execute();
            this.Run();
        }
        private void ListInPDF()
        {
            var command = this.factory.CreateCommand("ListMoviesInPDF");
            command.Execute();
            this.Run();
        }

        //DONT LOOK AT MEE IM A DISGRACE OF A SOLID PRINCIPLES AND I DO NOT DESERVE TO COMPILE
        // BUT  http://prntscr.com/gzlqgh AND IT COULD HAVE BEEN WAYY BETTER :(
        private void ReadFromFiles()
        {
            using (var context = new FilmRankingContext())
            {
                //#KOGATO ZACHUKASH NESHTO TVURDE ZDRAVO I GO HARDCODENESH :(
                XMLParser xmlParse = new XMLParser("../../../TextFiles/XMLFile.xml", context);
                xmlParse.Parse();
                JSONParser jsonParse = new JSONParser("../../../TextFiles/JSONFile.JSON", context);
                jsonParse.Parse();

            }
            this.writer.Write("The info from the files has been added to the database");
            this.Run();
        }
    }
}


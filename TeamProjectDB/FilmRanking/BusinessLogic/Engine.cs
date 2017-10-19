using FilmRanking.BusinessLogic.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRanking.GUI;
using FilmRanking.Commands.Modifying;

namespace FilmRanking.BusinessLogic.Contracts
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private GraphicInterfaces interfaceGenerator;
        private ICommandFactory factory;


        public Engine(IReader reader, GraphicInterfaces interfaceGenerator, ICommandFactory factory)
        {
            this.reader = reader;
            this.interfaceGenerator = interfaceGenerator;
            this.factory = factory;
        }

        public void Run()
        {
            Console.WriteLine(interfaceGenerator.MainMenuInterface());
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
                case "0":
                    Console.WriteLine("Exitted");
                    break;
                default:
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
    }
}


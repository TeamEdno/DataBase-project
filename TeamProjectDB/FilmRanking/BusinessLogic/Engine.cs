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
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    this.CreateFilmAndAddToDB();
                    break;
                case "2":
                    this.ReadFile();
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
            Console.WriteLine(interfaceGenerator.CreateDatabaseManuallyInterface());
            string input = reader.Read();
            if (input == "1")
            {
                this.Run();
            }
            else
            {
                
            }
        }

        private void CreateFilmAndAddToDB()
        {
            var command = factory.CreateCommand("AddFilmToDataBase");
            command.Execute();
        }

        private void ReadFile()
        {
            Console.WriteLine(interfaceGenerator.CreateDatabaseManuallyInterface());
            string input = Console.ReadLine();
            if (input == "1")
            {
                this.Run();
            }
            else
            {
                Console.WriteLine("\n reads a file and fills ur database \n");
                this.ReadFile();
            }
        }
    }
}

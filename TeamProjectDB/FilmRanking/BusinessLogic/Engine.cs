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


        public Engine(IReader reader, GraphicInterfaces interfaceGenerator)
        {
            this.reader = reader;
            this.interfaceGenerator = interfaceGenerator;
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
            string input = Console.ReadLine();
            if (input == "1")
            {
                this.Run();
            }
            else
            {
                Console.WriteLine("\n creates a model based on the user input would be good to use a trycatch here \n");
                this.CreateCommand();
            }
        }

        private void CreateFilmAndAddToDB()
        {
            string input = reader.Read();
            if (input == "1")
            {
                this.Run();
            }
            else
            {
                
            }
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

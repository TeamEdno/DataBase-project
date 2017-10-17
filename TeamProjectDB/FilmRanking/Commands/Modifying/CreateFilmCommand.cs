using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.GUI;
using FilmRanking.Models;
using FilmRanking.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Commands.Listing
{
    public class CreateFilmCommand
    {
        private GraphicInterfaces interfaceGenerator;

        public CreateFilmCommand(GraphicInterfaces interfaceGenerator)
        {
            this.interfaceGenerator = interfaceGenerator;
        }

        public Film Create(IList<string> parameters)
        {
            Console.WriteLine(interfaceGenerator.CreateGeneralInstructions());

            Console.WriteLine(interfaceGenerator.Title());
            string title = Console.ReadLine();

            Console.WriteLine(interfaceGenerator.Genre());
            string genreInput = Console.ReadLine();
            Genre genre = (Genre)Enum.Parse(typeof(Genre), genreInput);

            var film = new Film();
            film.Title = title;
            film.Genre = genre;

            return film;
        }
    }
}

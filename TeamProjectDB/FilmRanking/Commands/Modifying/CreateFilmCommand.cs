using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.GUI;
using FilmRanking.Models;
using FilmRanking.Models.Enums;
using System;
using System.Collections.Generic;

namespace FilmRanking.Commands.Listing
{
    public class CreateFilmCommand
    {
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;


        public CreateFilmCommand(GraphicInterfaces interfaceGenerator, IReader reader)
        {
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
        }

        public Film Create()
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

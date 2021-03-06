﻿using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using System.Linq;

namespace FilmRanking.Commands.Listing
{
    public class ListFilmCommand : ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public ListFilmCommand(FilmRankingContext context,
            GraphicInterfaces interfaceGenerator,
            IReader reader,
            ICommandFactory factory)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = factory.CreateWriter("ConsoleWriter");
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

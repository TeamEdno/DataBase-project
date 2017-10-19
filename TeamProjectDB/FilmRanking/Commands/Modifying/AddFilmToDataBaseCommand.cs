﻿using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using FilmRanking.Models;
using FilmRanking.Models.Enums;
using System;

namespace FilmRanking.Commands.Modifying
{
    public class AddFilmToDataBaseCommand: ICommand
    {
        private IFilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public AddFilmToDataBaseCommand(IFilmRankingContext context, GraphicInterfaces interfaceGenerator, IReader reader, IWriter writer)
        {
            this.context = context;
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
            this.writer = writer;
        }

        public void Execute()
        {
            writer.Write(interfaceGenerator.CreateGeneralInstructions());

            writer.Write(interfaceGenerator.Title());
            string title = reader.Read();

            writer.Write(interfaceGenerator.Genre());
            string genreInput = reader.Read();
            Genre genre = (Genre)Enum.Parse(typeof(Genre), genreInput);

            writer.Write(interfaceGenerator.Rate());
            double rate = double.Parse(reader.Read());

            var film = new Film();
            film.Title = title;
            film.Genre = genre;
            film.Rate = rate;

            this.context.Films.Add(film);
            this.context.SaveChanges();

            var filmID = film.Id;

            writer.Write($"Film with ID {filmID} was added to Database");

        }
    }
}

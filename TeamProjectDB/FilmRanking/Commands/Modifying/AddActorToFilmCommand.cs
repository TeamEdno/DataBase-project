﻿using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using FilmRanking.GUI;
using FilmRanking.Models;
using System;
using System.Linq;

namespace FilmRanking.Commands.Modifying
{
    public class AddActorToFilmCommand :ICommand
    {
        private FilmRankingContext context;
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;
        private IWriter writer;

        public AddActorToFilmCommand(FilmRankingContext context, 
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
            this.writer.Write(this.interfaceGenerator.CreateGeneralInstructions());

            var actor = new Actor();
            this.writer.Write(interfaceGenerator.FName());
            actor.FirstName = this.reader.Read();

            this.writer.Write(interfaceGenerator.LName());
            actor.LastName = this.reader.Read();

            this.writer.Write(interfaceGenerator.YBorn());
            actor.YearBorn = int.Parse(reader.Read());

            this.writer.Write(interfaceGenerator.SBio());
            actor.ShortBio = this.reader.Read();

            this.writer.Write(interfaceGenerator.ToWhichFilm());
            var filmTitle = this.reader.Read();

            Film currentFilm;

            try
            {
                currentFilm = this.context.Films.Where(f => f.Title == filmTitle).First();
            }
            catch (Exception)
            {
                throw new Exception("Film with this title can't found in the database");
            }

            currentFilm.Actors.Add(actor);
            this.context.SaveChanges();

            this.writer.Write($"Actor {actor.FirstName} {actor.LastName} is added to movie {filmTitle}.");

        }
    }
}

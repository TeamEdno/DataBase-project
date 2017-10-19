using FilmRanking.Data;
using FilmRanking.Models;
using FilmRanking.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Testing;
using FilmRanking.Commands.Listing;
using FilmRanking.GUI;
using FilmRanking.BusinessLogic.Providers.Contracts;

namespace UnitTestProject1.Commands.Listing.ListFilmCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnAllMovies_WhenParametersAreCorrect()
        {
            //Arrange

            var interfaceGenerator = new Mock<GraphicInterfaces>();
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();


            var dbContext = new Mock<IFilmRankingContext>();
            var listOfMovies = new List<Film>();
            var firstFilm = new Film() { Title = "TestFilmOne", Genre = Genre.Action, Rate = 2.0 };
            var secondFilm = new Film() { Title = "TestFilmTwo", Genre = Genre.Comedy, Rate = 4.0 };
            listOfMovies.Add(firstFilm);
            listOfMovies.Add(secondFilm);
            var filmSet = new Mock<DbSet<Film>>().SetupData(listOfMovies);
            dbContext.Setup(x => x.Films).Returns(filmSet.Object);

            var listFilms = new ListFilmCommand(dbContext.Object, interfaceGenerator.Object, reader.Object, writer.Object);

            //Act
            listFilms.Execute();

            //Assert
            Assert.AreEqual(dbContext.Object.Films.Count(), 2);

        }

    }
}

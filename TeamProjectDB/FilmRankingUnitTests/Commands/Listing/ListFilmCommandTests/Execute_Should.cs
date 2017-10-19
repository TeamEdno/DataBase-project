using FilmRanking.Data;
using FilmRanking.Models;
using FilmRanking.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmRankingUnitTests.Commands.Listing.ListFilmCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnAllMovies_WhenParametersAreCorrect()
        {
            var dbSet = new Mock<IDbSet<Film>>();
            var dbContext = new Mock<IFilmMakingContext>();
            var listOfMovies = new List<Film>();
            var firstFilm = new Film() { Title = "TestFilmOne", Genre = Genre.Action, Rate = 2.0 };
            var secondFilm = new Film() { Title = "TestFilmTwo", Genre = Genre.Comedy, Rate = 4.0 };
            listOfMovies.Add(firstFilm);
            listOfMovies.Add(secondFilm);

            dbContext.Setup(x => x.Films).Returns(listOfMovies);
        }
    }
}

using FilmRanking.BusinessLogic.Providers.Parsers.Contracts;
using FilmRanking.Data;
using FilmRanking.Models;
using FilmRanking.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.BusinessLogic.Providers.Parsers
{
    public class JSONParser : IFormatParser
    {
        public JSONParser(string address, FilmRankingContext context)
        {
            this.Address = address;
            this.Context = context;
        }

        public string Address { get; set; }
        public FilmRankingContext Context { get; set; }

        public void Parse()
        {
            using (StreamReader reader = new StreamReader(this.Address))
            {
                using (JsonTextReader jsonReader = new JsonTextReader(reader))
                {
                    JObject jasonObject = (JObject)JToken.ReadFrom(jsonReader);

                    Actor actorModel = new Actor();
                    Film filmModel = new Film();
                    Director directorModel = new Director();
                    Studio studioModel = new Studio();

                    var info = jasonObject.SelectToken("Info");
                    foreach(var entry in info)
                    {
                        //selects all the fields
                        var film = entry.SelectToken("Film");
                        var actor = entry.SelectToken("Actor");
                        var director = entry.SelectToken("Director");
                        var studio = entry.SelectToken("Studio");

                        //film
                        Genre genre = (Genre)Enum.Parse(typeof(Genre), film.SelectToken("Genre").ToString());
                        string title = film.SelectToken("Title").ToString();
                        double rate = double.Parse(film.SelectToken("Rate").ToString());
                        filmModel.Genre = genre;
                        filmModel.Title = title;
                        filmModel.Rate = rate;

                        //actor
                        string actorFirstName = actor.SelectToken("FirstName").ToString();
                        string actorLastName = actor.SelectToken("LastName").ToString();
                        int actorYearBorn = int.Parse(actor.SelectToken("YearBorn").ToString());
                        string actorShortBio = actor.SelectToken("ShortBio").ToString();
                        actorModel.FirstName = actorFirstName;
                        actorModel.LastName = actorLastName;
                        actorModel.YearBorn = actorYearBorn;
                        actorModel.ShortBio = actorShortBio;

                        //studio
                        string studioName = studio.SelectToken("Name").ToString();
                        int studiYearEstablished = int.Parse(studio.SelectToken("YearEstablished").ToString());
                        string studioTrivia = studio.SelectToken("Trivia").ToString();
                        studioModel.Name = studioName;
                        studioModel.YearEstablished = studiYearEstablished;
                        studioModel.Trivia = studioTrivia;

                        //director
                        string directorFirstName = director.SelectToken("FirstName").ToString();
                        string directorLastName = director.SelectToken("LastName").ToString();
                        int directorYearBorn = int.Parse(director.SelectToken("YearBorn").ToString());
                        string directorShortBio = director.SelectToken("ShortBio").ToString();
                        directorModel.FirstName = directorFirstName;
                        directorModel.LastName = directorLastName;
                        directorModel.YearBorn = directorYearBorn;
                        directorModel.ShortBio = directorShortBio;


                        filmModel.Director = directorModel;
                        this.Context.Directors.Add(directorModel);
                        filmModel.Studio = studioModel;
                        this.Context.Studios.Add(studioModel);
                        this.Context.Actors.Add(actorModel);
                        filmModel.Actors.Add(actorModel);
                        this.Context.Films.Add(filmModel);
                        Context.SaveChanges();
                    }
                }
            }
        }
    }
}
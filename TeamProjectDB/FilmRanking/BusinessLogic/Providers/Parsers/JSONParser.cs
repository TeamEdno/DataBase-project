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
    public class JSONParser : FileParse, IFormatParser
    {
        public JSONParser(string address, FilmRankingContext context) : base(address, context)
        {
        }

        public override void Parse()
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
                    foreach (var entry in info)
                    {
                        //selects all the fields
                        var film = entry.SelectToken("Film");
                        var actor = entry.SelectToken("Actor");
                        var director = entry.SelectToken("Director");
                        var studio = entry.SelectToken("Studio");

                        //film
                        filmModel.Genre = (Genre)Enum.Parse(typeof(Genre), film.SelectToken("Genre").ToString());
                        filmModel.Title = film.SelectToken("Title").ToString();
                        filmModel.Rate = double.Parse(film.SelectToken("Rate").ToString());

                        //actor
                        actorModel.FirstName = actor.SelectToken("FirstName").ToString();
                        actorModel.LastName = actor.SelectToken("LastName").ToString();
                        actorModel.YearBorn = int.Parse(actor.SelectToken("YearBorn").ToString());
                        actorModel.ShortBio = actor.SelectToken("ShortBio").ToString();

                        //studio
                        studioModel.Name = studio.SelectToken("Name").ToString();
                        studioModel.YearEstablished = int.Parse(studio.SelectToken("YearEstablished").ToString());
                        studioModel.Trivia = studio.SelectToken("Trivia").ToString();

                        //director
                        directorModel.FirstName = director.SelectToken("FirstName").ToString();
                        directorModel.LastName = director.SelectToken("LastName").ToString();
                        directorModel.YearBorn = int.Parse(director.SelectToken("YearBorn").ToString());
                        directorModel.ShortBio = director.SelectToken("ShortBio").ToString();

                        //add all to the database
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
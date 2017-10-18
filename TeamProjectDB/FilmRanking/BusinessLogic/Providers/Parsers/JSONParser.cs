using FilmRanking.BusinessLogic.Providers.Parsers.Contracts;
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
        public JSONParser(string address)
        {
            this.Address = address;
        }

        public string Address { get; set; }

        public void Parse()
        {
            using (StreamReader reader = new StreamReader(this.Address))
            {
                using (JsonTextReader jsonReader = new JsonTextReader(reader))
                {
                    JObject jasonObject = (JObject)JToken.ReadFrom(jsonReader);

                    //Actors
                    var actors = jasonObject.SelectToken("Actors");
                    foreach (var actor in actors)
                    {
                        var firstName = actor.SelectToken("FirstName");
                        var lastName = actor.SelectToken("LastName");
                        var yearBorn = actor.SelectToken("YearBorn");
                        var shortBio = actor.SelectToken("ShortBio");
                        Console.WriteLine(firstName + " "
                            + lastName + " "
                            + yearBorn + " "
                            + shortBio + " ");
                    }

                    //Films
                    var films = jasonObject.SelectToken("Films");
                    foreach (var film in films)
                    {
                        var genre = film.SelectToken("Genre");
                        var title = film.SelectToken("Title");
                        var directorId = film.SelectToken("DirectorId");
                        var studioId = film.SelectToken("StudioId");
                        Console.WriteLine(genre + " "
                            + title + " "
                            + directorId + " "
                            + studioId + " ");
                    }

                    //Directors
                    var directors = jasonObject.SelectToken("Directors");
                    foreach (var director in directors)
                    {
                        var firstName = director.SelectToken("FirstName");
                        var lastName = director.SelectToken("LastName");
                        var yearBorn = director.SelectToken("YearBorn");
                        var shortBio = director.SelectToken("ShortBio");
                        Console.WriteLine(firstName + " "
                            + lastName + " "
                            + yearBorn + " "
                            + shortBio + " ");
                    }

                    //Studios
                    var studios = jasonObject.SelectToken("Studios");
                    foreach (var studio in studios)
                    {
                        var name = studio.SelectToken("Name");
                        var yearEstablished = studio.SelectToken("YearEstablished");
                        var trivia = studio.SelectToken("Trivia");
                        Console.WriteLine(name + " "
                            + yearEstablished + " "
                            + trivia + " ");
                    }
                }
            }
        }
    }
}
using FilmRanking.BusinessLogic.Providers.Parsers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRanking.Data;
using System.Xml;
using FilmRanking.Models;
using FilmRanking.Models.Enums;

namespace FilmRanking.BusinessLogic.Providers.Parsers
{
    class XMLParser : FileParse, IFormatParser
    {
        public XMLParser(string address, FilmRankingContext context) : base(address, context)
        {
        }

        public override void Parse()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(this.Address);

            XmlNode rootNode = doc.DocumentElement;

            var children = rootNode.ChildNodes;
            foreach (XmlNode child in children)
            {
                //models
                Actor actorModel = new Actor();
                Film filmModel = new Film();
                Director directorModel = new Director();
                Studio studioModel = new Studio();

                //select
                XmlNode film = child.SelectSingleNode("film");
                XmlNode director = child.SelectSingleNode("director");
                XmlNode actor = child.SelectSingleNode("actor");
                XmlNode studio = child.SelectSingleNode("studio");

                //film
                filmModel.Title = film.SelectSingleNode("title").InnerText;
                filmModel.Genre = (Genre)Enum.Parse(typeof(Genre), film.SelectSingleNode("genre").InnerText);
                filmModel.Rate = double.Parse(film.SelectSingleNode("rate").InnerText.ToString());

                //actor
                actorModel.FirstName = actor.SelectSingleNode("firstName").InnerText;
                actorModel.LastName = actor.SelectSingleNode("lastName").InnerText;
                actorModel.ShortBio = actor.SelectSingleNode("shortBio").InnerText;
                actorModel.YearBorn = int.Parse(actor.SelectSingleNode("yearBorn").InnerText);

                //director
                directorModel.FirstName = director.SelectSingleNode("firstName").InnerText;
                directorModel.LastName = director.SelectSingleNode("lastName").InnerText;
                directorModel.ShortBio = director.SelectSingleNode("shortBio").InnerText;
                directorModel.YearBorn = int.Parse(director.SelectSingleNode("yearBorn").InnerText);

                //studio
                studioModel.Name = studio.SelectSingleNode("name").InnerText;
                studioModel.YearEstablished = int.Parse(studio.SelectSingleNode("yearEstablished").InnerText);
                studioModel.Trivia = studio.SelectSingleNode("trivia").InnerText;

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

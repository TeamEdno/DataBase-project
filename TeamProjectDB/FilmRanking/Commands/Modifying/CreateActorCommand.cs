using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.GUI;
using FilmRanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Commands.Modifying
{
    public class CreateActorCommand
    {
        private GraphicInterfaces interfaceGenerator;
        private IReader reader;

        public CreateActorCommand(GraphicInterfaces interfaceGenerator, IReader reader)
        {
            this.interfaceGenerator = interfaceGenerator;
            this.reader = reader;
        }

        public Actor Create()
        {
            Console.WriteLine(interfaceGenerator.CreateGeneralInstructions());

            var actor = new Actor();

            Console.WriteLine(interfaceGenerator.FName());
            actor.FirstName = reader.Read();

            Console.WriteLine(interfaceGenerator.LName());
            actor.LastName = reader.Read();

            Console.WriteLine(interfaceGenerator.YBorn());
            actor.YearBorn = int.Parse(reader.Read());

            Console.WriteLine(interfaceGenerator.SBio());
            actor.ShortBio = reader.Read();

            return actor;
        }
    }
}



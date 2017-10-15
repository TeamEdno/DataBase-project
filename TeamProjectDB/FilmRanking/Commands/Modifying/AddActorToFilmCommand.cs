using FilmRanking.Commands.Contracts;
using FilmRanking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Commands.Modifying
{
    class AddActorToFilmCommand : ICommand
    {
        private readonly FilmRankingContext context;

        public AddActorToFilmCommand(FilmRankingContext context)
        {
            this.context = context;
        }
        public void Execute(IList<string> parameters)
        {
            using (this.context)
            {
                // To be implemented...
            }
        }
    }
}

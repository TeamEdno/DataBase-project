using FilmRanking.BusinessLogic.Providers.Parsers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRanking.Commands.Contracts;

namespace FilmRanking.BusinessLogic.Parsers
{
    public class CommandParser : ICommandParser
    {
        public ICommand ParseCommand(string commandParameters)
        {
            throw new NotImplementedException();
        }

        public IList<string> ParseParameters(string commandParameters)
        {
            throw new NotImplementedException();
        }
    }
}

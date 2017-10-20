using FilmRanking.BusinessLogic.Providers.Parsers.Contracts;
using FilmRanking.Commands.Contracts;
using System;
using System.Collections.Generic;

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

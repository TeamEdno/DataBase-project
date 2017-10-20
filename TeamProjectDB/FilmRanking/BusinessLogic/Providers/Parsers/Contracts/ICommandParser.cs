using FilmRanking.Commands.Contracts;
using System.Collections.Generic;

namespace FilmRanking.BusinessLogic.Providers.Parsers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandParameters);

        IList<string> ParseParameters(string commandParameters);
    }
}

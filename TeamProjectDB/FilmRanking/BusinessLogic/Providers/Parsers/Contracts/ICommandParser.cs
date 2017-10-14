using FilmRanking.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.BusinessLogic.Providers.Parsers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandParameters);

        IList<string> ParseParameters(string commandParameters);
    }
}

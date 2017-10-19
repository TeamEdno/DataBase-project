using FilmRanking.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.BusinessLogic.Providers.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}

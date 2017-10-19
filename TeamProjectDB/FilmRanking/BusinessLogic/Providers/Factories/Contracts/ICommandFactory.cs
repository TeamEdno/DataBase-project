using FilmRanking.Commands.Contracts;

namespace FilmRanking.BusinessLogic.Providers.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
        IWriter CreateWriter(string commandName);
    }
}

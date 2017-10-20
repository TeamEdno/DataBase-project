using FilmRanking.BusinessLogic.Providers.Contracts;
using System;

namespace FilmRanking.BusinessLogic.Providers.Readers
{
    public class ConsoleReader : IReader
    {
        public string  Read()
        {
            return Console.ReadLine();
        }
    }
}

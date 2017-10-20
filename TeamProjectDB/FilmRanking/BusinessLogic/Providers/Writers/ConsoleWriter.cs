using FilmRanking.BusinessLogic.Providers.Contracts;
using System;

namespace FilmRanking.BusinessLogic.Providers.Writers
{
    class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}

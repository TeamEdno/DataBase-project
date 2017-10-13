using FilmRanking.BusinessLogic.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.BusinessLogic.Providers.Readers
{
    public class ConsoleReader : IReader
    {
        public void Read()
        {
            Console.ReadLine();
        }
    }
}

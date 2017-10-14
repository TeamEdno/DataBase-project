using FilmRanking.BusinessLogic.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.BusinessLogic.Contracts
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private string endCommand = "end";


        public Engine(IReader reader)
        {
            this.reader = reader;
        }
        public void Run()
        {
            while (this.reader.Read() != this.endCommand)
            {
                //Logic with GUI in Console
            }
        }
    }
}

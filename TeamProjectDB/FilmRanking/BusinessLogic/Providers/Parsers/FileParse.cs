using FilmRanking.BusinessLogic.Providers.Parsers.Contracts;
using FilmRanking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.BusinessLogic.Providers.Parsers
{
    public abstract class FileParse : IFormatParser
    {
        public FileParse(string address, FilmRankingContext context)
        {
            this.Address = address;
            this.Context = context;
        }

        public string Address { get; set; }
        public FilmRankingContext Context { get; set; }

        public abstract void Parse();
    }
}

using FilmRanking.BusinessLogic.Providers.Parsers.Contracts;
using FilmRanking.Data;

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

using FilmRanking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Data
{
    public class FilmRankingContext:DbContext
    {
        public FilmRankingContext()
            :base("FilmRankingConnection")
        {
        }

        public IDbSet<Film> Films { get; set; }
        public IDbSet<Director> Directors { get; set; }
        public IDbSet<Studio> Studios { get; set; }


    }
}

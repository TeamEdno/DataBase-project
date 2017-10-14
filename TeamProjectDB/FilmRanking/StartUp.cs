using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FilmRanking.Data;
using FilmRanking.Migrations;

namespace FilmRanking
{
    class StartUp
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilmRankingContext, Configuration>());

            using (var context = new FilmRankingContext())
            {
                var films = context.Films.ToList();
            }
        }
    }
}

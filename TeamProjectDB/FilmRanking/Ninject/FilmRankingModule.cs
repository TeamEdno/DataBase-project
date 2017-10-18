using FilmRanking.Data;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.Ninject
{
    public class FilmRankingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFilmMakingContext>().To<FilmRankingContext>();
        }
    }
}

using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.BusinessLogic.Providers.Readers;
using FilmRanking.BusinessLogic.Providers.Writers;
using FilmRanking.Commands.Contracts;
using FilmRanking.Commands.Modifying;
using FilmRanking.Data;
using Ninject.Modules;

namespace FilmRanking.Ninject
{
    public class FilmRankingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFilmMakingContext>().To<FilmRankingContext>();

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();

            this.Bind<ICommand>().To<AddFilmToDataBaseCommand>().Named("AddFilmToDataBase");
            this.Bind<ICommand>().To<AddActorToFilmCommand>().Named("AddActorToFilm");
        }
    }
}

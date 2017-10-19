using FilmRanking.BusinessLogic.Contracts;
using FilmRanking.BusinessLogic.Providers.Contracts;
using FilmRanking.BusinessLogic.Providers.Readers;
using FilmRanking.BusinessLogic.Providers.Writers;
using FilmRanking.Commands.Contracts;
using FilmRanking.Commands.Modifying;
using FilmRanking.Commands.Listing;
using FilmRanking.Data;
using Ninject.Modules;

namespace FilmRanking.Ninject
{
    public class FilmRankingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFilmMakingContext>().To<FilmRankingContext>();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();

            this.Bind<ICommand>().To<AddFilmToDataBaseCommand>().Named("AddFilmToDataBase");
            this.Bind<ICommand>().To<AddActorToFilmCommand>().Named("AddActorToFilm");
            this.Bind<ICommand>().To<AddDirectorToFilmCommand>().Named("AddDirectorToFilm");
            this.Bind<ICommand>().To<AddStudioToFilmCommand>().Named("AddStudioToFilm");
            this.Bind<ICommand>().To<ListFilmCommand>().Named("ListFilm");
            this.Bind<ICommand>().To<DeleteFilmCommand>().Named("DeleteFilm");
            this.Bind<ICommand>().To<RateFilmCommand>().Named("RateFilm");

        }
    }
}

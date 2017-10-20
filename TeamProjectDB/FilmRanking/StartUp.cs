using FilmRanking.BusinessLogic.Contracts;
using FilmRanking.Ninject;
using Ninject;

namespace FilmRanking
{
    class StartUp
    {
        static void Main()
        {
            var kernel = new StandardKernel(new FilmRankingModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Run();
        }
    }
}

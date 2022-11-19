using PowerScribble.Api.Application.Interfaces;
using PowerScribble.Api.Persistance.Data;

namespace PowerScribble.Api
{
    public class AppContext : IAppContext
    {

        public PowerScribbleDbContext Db { get; set; }

        public AppContext(PowerScribbleDbContext dbContext)
        {
            Db = dbContext;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Application.Interfaces
{
    public interface IAppContext
    {
        public Persistance.Data.PowerScribbleDbContext Db { get; set; }
    }
}

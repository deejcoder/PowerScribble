using PowerScribble.Api.Domain.Entities;
using PowerScribble.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Domain.Interfaces
{
    public interface IModelParser<TKey>
    {
        IModel AsModel(IEntity<TKey> entity);
        List<IModel> AsModels(IEnumerable<IEntity<TKey>> entities);

        IEntity<TKey> AsEntity(IModel model);
        List<IEntity<TKey>> AsEntities(IEnumerable<IModel> models);
    }
}

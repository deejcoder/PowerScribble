using PowerScribble.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScribble.Api.Infrastructure.ModelParsers
{
    public abstract class BaseParser<TKey> : IModelParser<TKey>
    {

        public abstract IEntity<TKey> AsEntity(IModel model);

        /// <summary>
        /// Converts a list of models into a list of entities
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public List<IEntity<TKey>> AsEntities(IEnumerable<IModel> models)
        {
            List<IEntity<TKey>> result = new();
            foreach (var model in models)
            {
                result.Add(AsEntity(model));
            }

            return result;
        }

        public abstract IModel AsModel(IEntity<TKey> entity);

        /// <summary>
        /// Converts a list of entities into a list of models
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<IModel> AsModels(IEnumerable<IEntity<TKey>> entities)
        {
            List<IModel> result = new();
            foreach (var entity in entities)
            {
                result.Add(AsModel(entity));
            }

            return result;
        }

    }
}

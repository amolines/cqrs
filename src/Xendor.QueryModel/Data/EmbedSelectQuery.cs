using System.Collections.Generic;


namespace Xendor.QueryModel.Data
{
    public abstract class EmbedSelectQuery : Query, IEmbedSelectQuery
    {
        protected EmbedSelectQuery():
        base (new Dictionary<string, object>()){ }

        protected EmbedSelectQuery(IDictionary<string, object> parameters)
            : base(parameters)
        {

        }

        public void SetId(long id)
        {
            Parameters.Add("@id", id);
        }
    }
}
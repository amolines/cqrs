using Xendor.QueryModel.Data;

namespace Xendor.QueryModel.MySql
{
    public abstract class MySqlEmbedSelect : EmbedSelectQuery
    {
        protected abstract string Select { get; }
        protected abstract string Joins { get; }

    }
}
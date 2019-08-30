namespace Xendor.Data
{
    /// <summary>
    /// The Data Mapper is a layer of software that separates the in-memory objects from the database.
    /// Its responsibility is to transfer data between the two and also to isolate them from each other.
    /// With Data Mapper the in-memory objects needn't know even that there's a database present;
    /// they need no SQL interface code, and certainly no knowledge of the database schema.
    /// </summary>
    public interface IDataMapper<in TSource, out TDestination>
    {
        TDestination Mapper(TSource source);
    }
}
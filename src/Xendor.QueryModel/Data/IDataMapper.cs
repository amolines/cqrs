namespace Xendor.QueryModel.Data
{
    public interface IDataMapper<in TSource, out TDestination>
    {
        TDestination Mapper(TSource source);
    }
}
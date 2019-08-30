namespace Xendor.Data
{
    public enum UnitOfWorkState
    {
        InAction = 0,
        Commit = 1,
        RollBack = 2,
        Disposed = 3
    }
}
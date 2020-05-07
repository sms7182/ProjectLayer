namespace Data.Configuration
{
    public interface IUnitOfWork
    {
         void BeginTransaction();
         void Commit();
         void Rollback();
    }
}
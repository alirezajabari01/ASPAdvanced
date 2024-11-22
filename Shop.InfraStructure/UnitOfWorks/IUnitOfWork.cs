namespace Shop.InfraStructure.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}

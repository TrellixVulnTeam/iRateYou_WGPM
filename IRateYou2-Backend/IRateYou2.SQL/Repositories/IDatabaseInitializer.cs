namespace IRateYou2.SQL.Repositories
{
    public interface IDatabaseInitializer
    {
        void SeedDatabase(DBContext ctx);
    }
}
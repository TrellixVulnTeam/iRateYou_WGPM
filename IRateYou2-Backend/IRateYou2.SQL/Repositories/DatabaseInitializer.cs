using IRateYou2.Core.IServices;
using IRateYou2.Core.Models;
using IRateYou2.Domain.IRepositories;

namespace IRateYou2.SQL.Repositories
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        public void SeedDatabase(DBContext ctx)
        {
            IUserRepository userRepo = new UserRepository(ctx);

            userRepo.CreateUser(new User()
            {
                FirstName = "Simon",
                LastName = "BROW",
            });

            userRepo.CreateUser(new User()
            {
                FirstName = "Svend",
                LastName = "NOT-BROW",
            });
            
            ctx.SaveChanges();
        }
    }
}
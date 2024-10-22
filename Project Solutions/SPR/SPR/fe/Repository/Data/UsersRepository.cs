using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class UsersRepository : GeneralRepository<Db_context, User, Guid>
    {
        private readonly Db_context myContext;

        public UsersRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}

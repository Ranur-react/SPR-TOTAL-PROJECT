using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class RoleRepository : GeneralRepository<Db_context, Role, int>
    {
        private readonly Db_context myContext;

        public RoleRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}

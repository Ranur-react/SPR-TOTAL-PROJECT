using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class SPRRepository : GeneralRepository<Db_context, SPR, String>
    {
        private readonly Db_context myContext;

        public SPRRepository(Db_context myContext): base(myContext)
        {
            this.myContext = myContext;
        }
    }
}

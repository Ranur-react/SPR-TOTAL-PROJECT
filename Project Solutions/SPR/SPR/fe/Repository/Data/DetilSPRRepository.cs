using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class DetilSPRRepository : GeneralRepository<Db_context, DetilSPR, Guid>
    {
        private readonly Db_context myContext;

        public DetilSPRRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}

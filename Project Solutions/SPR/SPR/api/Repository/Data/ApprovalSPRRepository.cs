using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class ApprovalSPRRepository : GeneralRepository<Db_context, ApprovalSPR, Guid>
    {
        private readonly Db_context myContext;

        public ApprovalSPRRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}

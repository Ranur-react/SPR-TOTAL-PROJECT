using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class LogSPRRepository : GeneralRepository<Db_context, LogSPR, Guid>
    {
        private readonly Db_context myContext;

        public LogSPRRepository(Db_context myContext) : base(myContext) 
        {
            this.myContext = myContext;
        }
    }
}

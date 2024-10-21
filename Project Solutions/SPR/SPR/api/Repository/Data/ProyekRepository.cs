using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class ProyekRepository : GeneralRepository<Db_context, Proyek, int>
    {
        private readonly Db_context myContext;

        public ProyekRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}

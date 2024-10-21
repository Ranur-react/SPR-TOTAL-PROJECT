using api.Context;
using api.Models;

namespace api.Repository.Data
{
    public class MaterialRepository : GeneralRepository<Db_context, Material, Guid>
    {
        private readonly Db_context myContext;

        public MaterialRepository(Db_context myContext) : base(myContext) 
        {
            this.myContext = myContext;
        }
    }
}

using api.Context;
using api.Models;
using api.Models.ViewModel;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Data
{
    public class DetilSPRRepository : GeneralRepository<Db_context, DetilSPR, Guid>
    {
        private readonly Db_context myContext;

        public DetilSPRRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public IEnumerable<DetilSPRView> GetBySPR(String SPRKode) {
            var results = myContext.Detils_SPR
                .Where(e => e.SPRId == SPRKode)  // Filter berdasarkan SPRId
                .Include(e => e.Material)        // Include relasi dengan Material
                .Select(e => new DetilSPRView
                {
                    Id = e.Id,
                    SPRId = e.SPRId,
                    MaterialId = e.MaterialId,
                    Volume = e.Volume,
                    Unit = e.Unit,
                    TanggalRencanaTerima = e.TanggalRencanaTerima,
                    StatusDisetujui = e.StatusDisetujui,
                    // Properti dari Material
                    NamaMaterial = e.Material.NamaMaterial,
                    TipeMaterial = e.Material.TipeMaterial,
                    StokMaterial = e.Material.StokMaterial
                })
                .ToList();

            return results;
        }
    }
}

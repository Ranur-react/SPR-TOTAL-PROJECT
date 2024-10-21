using api.Base;
using api.Models;
using api.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPRController : BaseController<SPR, SPRRepository, String>
    {
        private readonly SPRRepository sPRRepository;
        public IConfiguration _Configuration;

        public SPRController(SPRRepository sPRRepository, IConfiguration configuration) : base(sPRRepository)
        {
            this.sPRRepository = sPRRepository;
            _Configuration = configuration;
        }
        //public string GenerateSPRid() {
        //    //var bulan = tanggalMinta.Month;
        //    //var tahun = tanggalMinta.Year;
        //    //var parameterProyekId = new SqlParameter("@ProyekId", proyekId);
        //    //var parameterBulan = new SqlParameter("@Bulan", bulan);
        //    //var parameterTahun = new SqlParameter("@Tahun", tahun);
        //    //var outputSPRNo = new SqlParameter
        //    //{
        //    //    ParameterName = "@NewSPRNo",
        //    //    SqlDbType = System.Data.SqlDbType.Int,
        //    //    Direction = System.Data.ParameterDirection.Output
        //    //};

        //    //await _context.Database.ExecuteSqlRawAsync("EXEC GenerateSPRNo @ProyekId, @Bulan, @Tahun, @NewSPRNo OUTPUT",
        //    //    parameterProyekId, parameterBulan, parameterTahun, outputSPRNo);

        //    //return (int)outputSPRNo.Value;
        //    //return "";

        //    //Saay ingin SPRId di generate dari Store Prosedure semua, nanti tinggal tinggal generate saja
        //}
    }
}

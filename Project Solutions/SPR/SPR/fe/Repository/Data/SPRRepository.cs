using api.Context;
using api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Data
{
    public class SPRRepository : GeneralRepository<Db_context, SPR, String>
    {
        private readonly Db_context myContext;

        public SPRRepository(Db_context myContext): base(myContext)
        {
            this.myContext = myContext;
        }

        //public SPR CreateSPR(SPR content)
        //{
        //    try
        //    {
        //        content.TanggalMinta= content.TanggalMinta=="jika tidak di isi user"?IsiOtomatisDariTanggalHariIni: content.TanggalMinta
        //        var nilaistoreProcedureDidapatkan= GenerateSPRNoAsync(content.ProyekId,content.TanggalMinta)
        //        int SPRonThisMonth = '0001' + content.ProyekId + '';
        //        var SPR
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public async Task<int> GenerateSPRNoAsync(int proyekId, DateTime tanggalMinta)
        //{
        //    var bulan = tanggalMinta.Month;
        //    var tahun = tanggalMinta.Year;


        //    { 
        //    saya mau mengambilk nilai store procedure dari sini
        //    }
        //    //var parameterProyekId = new SqlParameter("@ProyekId", proyekId);
        //    //var parameterBulan = new SqlParameter("@Bulan", bulan);
        //    //var parameterTahun = new SqlParameter("@Tahun", tahun);
        //    //var outputSPRNo = new SqlParameter
        //    //{
        //    //    ParameterName = "@NewSPRNo",
        //    //    SqlDbType = System.Data.SqlDbType.Int,
        //    //    Direction = System.Data.ParameterDirection.Output
        //    //};

        //    //await myContext.Database.ExecuteSqlRawAsync("EXEC GenerateSPRNo @ProyekId, @Bulan, @Tahun, @NewSPRNo OUTPUT",
        //    //    parameterProyekId, parameterBulan, parameterTahun, outputSPRNo);

        //    //return (int)outputSPRNo.Value;
        //}
        public int CreateSPR(SPR content) {
            try
            {
                //jika tanggal kosong
                if (content.TanggalMinta == default(DateTime))
                {
                    content.TanggalMinta = DateTime.UtcNow;
                }
                //Ambil Nomor Urut Project dalam bulan ini yang sudah masuk SPR
                var newSPRNo = GenerateSPRNoAsync(content.ProyekId, content.TanggalMinta).Result;
                //Build SPR Formating
                content.Id = $"{newSPRNo}-{content.ProyekId}-{content.TanggalMinta.Month}-{content.TanggalMinta.Year}";
                myContext.Headers_SP.Add(content);
                myContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }
        public async Task<string> GenerateSPRNoAsync(int proyekId,DateTime tanggalMinta)
        {
            var bulan = tanggalMinta.Month;
            var tahun = tanggalMinta.Year;


            //Membuat Parameter input & Output
            var parameterProyekId = new SqlParameter("@ProyekId", proyekId);
            var parameterBulan = new SqlParameter("@Bulan", bulan);
            var parameterTahun = new SqlParameter("@Tahun", tahun);

            //Init Output SPRNo variabel
            var output = new SqlParameter
            {
                ParameterName = "@NewSPRNo",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            await myContext.Database.ExecuteSqlRawAsync("EXEC [dbo].[GenerateSPRNo] @ProyekId, @Bulan, @Tahun, @NewSPRNo OUTPUT",
                parameterProyekId, parameterBulan, parameterTahun, output
                );
            // Ambil nilai urutan
            int newSprNo = (int)output.Value;

            // Format nomor dengan padding nol
            string formattedSprNo = newSprNo.ToString().PadLeft(4, '0'); // Ubah '4' sesuai dengan kebutuhan padding

            return formattedSprNo;
        }
    }
}

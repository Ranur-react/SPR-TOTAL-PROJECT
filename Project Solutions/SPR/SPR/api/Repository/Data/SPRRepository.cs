using api.Context;
using api.Models;
using api.Models.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Data
{
    public class SPRRepository : GeneralRepository<Db_context, SPR, String>
    {
        private readonly Db_context myContext;

        public SPRRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int CreateSPR(SPR content)
        {
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




        public int CreateSPRWithDetails(SPRContentDetilView content)
        {
            try
            {
                if (content.TanggalMinta == default(DateTime))
                {
                    content.TanggalMinta = DateTime.UtcNow;
                }
                if (content.TanggalRencanaTerima == default(DateTime))
                {
                    //sya ingin Tanggal Rencana terima = 14 hari setelah tanggal Minta
                    content.TanggalRencanaTerima = content.TanggalMinta.AddDays(14);
                }

                //Ambil Nomor Urut Project dalam bulan ini yang sudah masuk SPR
                var newSPRNo = GenerateSPRNoAsync(content.ProyekId, content.TanggalMinta).Result;
                //Build SPR Formating
                content.Id = $"{newSPRNo}-{content.ProyekId}-{content.TanggalMinta.Month}-{content.TanggalMinta.Year}";

                SPR newData = new SPR
                {
                    Id = content.Id,
                    ZonaSPR = content.ZonaSPR,
                    UserPemintaId = content.UserPemintaId,
                    TujuanSPR = content.TujuanSPR,
                    TanggalMinta = content.TanggalMinta,
                    StatusSPR = content?.StatusSPR ?? "Created",
                    ProyekId = content.ProyekId,

                };
                myContext.Headers_SP.Add(newData);
                myContext.SaveChanges();

                //--- insert data ke Detils dibawah berikut
                DetilSPR newDataDetil = new DetilSPR
                {
                    MaterialId = content.MaterialId,
                    SPRId = content.Id,
                    StatusDisetujui = content?.StatusDisetujui ?? false,
                    Unit=content?.Unit,
                    Volume=content.Volume,
                    TanggalRencanaTerima=content.TanggalRencanaTerima,
      
                };
                myContext.Detils_SPR.Add(newDataDetil);
                myContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }

        }







        public async Task<string> GenerateSPRNoAsync(int proyekId, DateTime tanggalMinta)
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

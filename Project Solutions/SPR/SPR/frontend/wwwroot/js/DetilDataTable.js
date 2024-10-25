$(document).ready(function () {
    //console.log("Data Table Detil  begin");
    //console.log("Data from API SPR/GetALL :");
    window.dataTableDetil = $('#tableDetil').DataTable({
        ajax: {
            url: 'DetilSPR/GetAll', // Replace 2 with the dynamic project ID if needed
            method: 'GET',
            dataSrc: function (json) {
                //console.log(" Mendapatkan data Detil . . .")


                // Log the data to the console instead of displaying in the table
                //console.log(json);

                if (json.code == 200) return json.data;
                //return no data if not data

                else if (!json || json.code == 204) return [];

                //return for DetilSPR/GetAll

                else return json.filter(item => item !== null)
            }
        },
        columns: [
            { data: 'sprId' },
            {
                //data: 'tanggalMinta',
                data: null,
                render: (data) => {

                    return DateToISoString(data.tanggalRencanaTerima);
                }
            },
           
            {
                data: null,
                render: (data) => {
                    //if (!data.materialId) {
                    if (!data.namaMaterial) {
                        return "No Material";
                    } else {
                        return data.namaMaterial
                    }
                }
            },
            {
                data: null,
                render: function (data) {
                    //if (!data.materialId) {
                    if (!data.namaMaterial) {
                        return "No Material";
                    } else {
                        return data.tipeMaterial == 0 ? "Pokok" : "Non Pokok";
                    }
                }
                
            },
            {
                data: null,
                render: function (data) {
                    return data.volume;
                }
            },
            {
                data: 'unit',
                render: function (data) {
                    return data;
                }
            },
            {
                data: 'statusDisetujui',
                render: (value) => {
                    return value?'Disetujui':'Belum Disetujui'
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    //return `<button class="btn btn-primary" onclick="viewSPRDetails('${row.id}')">View</button>`;
                    return `<button type="button" class="btn btn-outline-danger" onclick="HapusMaterilDetil('${row.id}')">Delete</button>`;
                }
            }
        ]
    });

});

//$('#modalDetil').on('shown.bs.modal', function () {
//    console.log("Modal Detil muncul, panggil material");
//    window.getMaterial;
//});
function viewSPRDetails(SPRid) {
    varShareSPRid = SPRid;
    //console.log("Tombol Action diklik untuk SPRid:", SPRid);
    // Ganti URL sumber data untuk dataTableDetil berdasarkan SPRid yang dipilih
    window.dataTableDetil.ajax.url(`DetilSPR/GetBySPR?SPRKode=${SPRid}`).load();

}
const HapusMaterilDetil=(detilId) => {
    $.ajax({
        url: 'DetilSPR/Delete/'+detilId, // Replace with your API endpoint
        method: 'DELETE',
        success: function (data) {
            alert(`Hapus detil material untuk SPRid:${varShareSPRid} berhasil`);
            window.dataTableDetil.ajax.url(`DetilSPR/GetBySPR?SPRKode=${varShareSPRid}`).load();
        }
    });
}
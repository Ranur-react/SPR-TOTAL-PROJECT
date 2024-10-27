$(document).ready(function () {
    console.log("Data Table Proyek  begin");
    window.dataTableProyek = $('#tabelProyek').DataTable({
        ajax: {
            url: 'Proyek/GetAll', // Replace 2 with the dynamic project ID if needed
            method: 'GET',
            dataSrc: function (json) {
                console.log(json)
                if (!json) return [];
                let FilteredJson = json.filter(item => item !== null)
                return json; // Empty array so no data is displayed in the table
            }
        },
        columns: [
            {
                data: null,
                render: (data, type, row, meta) => {
                    return meta.row + 1; // Menampilkan nomor urut
                }
            },
            {
                data: 'namaProyek',

            },
            {
                data: 'lokasiProyek',

            },

            {
                data: null,
                render: (data) => {
                    return DateToISoString(data.tanggalMulai);
                    //return '-';
                }
            },
            {
                data: null,
                render: (data) => {
                    //return DateToISoString(data.tanggalSelesai);
                    return '-';

                }
            },
            
            {
                data: null,
                render: function (data, type, row) {
                    return `<button class="btn btn-outline-danger" onclick="deleteProyek('${row.id}')">Hapus</button>`;
                }
            }
        ]
    });

})
$(document).ready(function () {
    console.log("Data Table Proyek  begin");
    window.dataTableMaterial= $('#tabelMaterial').DataTable({
        ajax: {
            url: 'Material/GetAll', // Replace 2 with the dynamic project ID if needed
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
                data: 'namaMaterial',

            },
            {
                data: null,
                render: (data) => {
                    return data.tipeMaterial == 0 ? 'Pokok' : 'Non Pokok';
                }

            },
            {
                data: 'stokMaterial',

            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<button class="btn btn-outline-danger" onclick="deleteMaterial('${row.id}')">Hapus</button>`;
                }
            }
        ]
    });

})
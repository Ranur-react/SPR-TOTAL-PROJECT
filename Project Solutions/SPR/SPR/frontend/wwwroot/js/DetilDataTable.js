$(document).ready(function () {
    console.log("Data Table Detil  begin");
    console.log("Data from API SPR/GetALL :");
    window.dataTableDetil = $('#tableDetil').DataTable({
        ajax: {
            url: 'DetilSPR/GetAll', // Replace 2 with the dynamic project ID if needed
            method: 'GET',
            dataSrc: function (json) {
                console.log(" Mendapatkan data Detil . . .")


                // Log the data to the console instead of displaying in the table
                console.log(json);

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
                        if (true) {
                        return "No Material";
                    } else {
                        // Make an AJAX call to get the material name
                        let materialName = "Loading...";  // Default placeholder

                        $.ajax({
                            url: `Material/Get/${data.materialId}`, // Replace with your API
                            method: 'GET',
                            async: false, // Make it synchronous to wait for the result
                            success: function (materialData) {
                                materialName = materialData.namaMaterial; // Replace with actual attribute
                            },
                            error: function () {
                                materialName = "Unknown Material"; // Fallback if API fails
                            }
                        });

                        return materialName;  // Return the name to be displayed in the table
                    }
                }
            },
            {
                data: null,
                render: function (data) {
                    //if (!data.materialId) {
                        if (true) {
                        return "No Material";
                    } else {
                        // Make an AJAX call to get the material name
                        let materialName = "Loading...";  // Default placeholder

                        $.ajax({
                            url: `Material/Get/${data.materialId}`, // Replace with your API
                            method: 'GET',
                            async: false, // Make it synchronous to wait for the result
                            success: function (materialData) {
                                materialName = materialData.tipeMaterial==0?'Pokok':'Non Pokok'; // Replace with actual attribute
                            },
                            error: function () {
                                materialName = "Unknown Material Type"; // Fallback if API fails
                            }
                        });

                        return materialName;  // Return the name to be displayed in the table
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
            { data: 'statusDisetujui' },
            {
                data: null,
                render: function (data, type, row) {
                    //return `<button class="btn btn-primary" onclick="viewSPRDetails('${row.id}')">View</button>`;
                    return `<button type="button" class="btn btn-outline-danger" onclick="console.log('${row.id}')">Delete</button>`;
                }
            }
        ]
    });

});

$('#modalDetil').on('shown.bs.modal', function () {
    console.log("Modal Detil muncul");
});
function viewSPRDetails(SPRid) {
    console.log("Tombol Action diklik untuk SPRid:", SPRid);

    // Ganti URL sumber data untuk dataTableDetil berdasarkan SPRid yang dipilih
    window.dataTableDetil.ajax.url(`DetilSPR/GetBySPR?SPRKode=${SPRid}`).load(function () {
    //window.dataTableDetil.ajax.url(`DetilSPR/GetAll`).load(function () {
        // Setelah data terload, tampilkan modal
        //$('#detilModal').modal('show');
    });
}
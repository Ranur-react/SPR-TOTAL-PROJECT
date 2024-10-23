
$(document).ready(function () {
    console.log("Data Table begin");


    $('#myTable').DataTable({
        ajax: {
            url: 'Proyek/Get/2', // Replace 2 with the dynamic project ID if needed
            method: 'GET',
            dataSrc: function (json) {
                // Log the data to the console instead of displaying in the table
                console.log("Data from API:");
                console.log(json.spRs);
                let FilteredJson = json.spRs.filter(item => item !== null)
                return FilteredJson; // Empty array so no data is displayed in the table
            }
        },
        columns: [
            { data: 'id' },
            {
                data: null,
                render: (data) => {
                    //return data.zonaSPR == 000 ? "ALL" ? data.zonaSPR;
                    if (data.zonaSPR == 000) {
                        return "ALL";
                    }
                    return data.zonaSPR;
                }

            },
            {
                //data: 'tanggalMinta',
                data: null,
                render: (data) => {
                    return DateToISoString(data.tanggalMinta);
                }
            },
            { data: 'tujuanSPR' },
            { data: 'userPeminta.name' },
            {
                data: null,
                render: function (data) {
                    // Handle approvalSPRs array, assuming first approval
                    return data.approvalSPRs.length > 0 ? data.approvalSPRs[0].name : '-';
                }
            },
            {
                data: null,
                render: function (data) {
                    // Handle approvalSPRs array, assuming second approval
                    return data.approvalSPRs.length > 1 ? data.approvalSPRs[1].name : '-';
                }
            },
            {
                data: 'detilSPRs',
                render: function (data) {
                    // Cek apakah detilSPRs berisi null atau memiliki konten
                    return data && data.length > 0 ? 'Yes' : 'No';
                }
            },
            { data: 'statusSPR' },
            {
                data: null,
                render: function (data, type, row) {
                    return `<button class="btn btn-primary" onclick="viewSPRDetails('${row.id}')">View</button>`;
                }
            }
        ]
    })
});
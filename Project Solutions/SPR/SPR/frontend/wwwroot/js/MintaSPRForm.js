$(document).ready(function () {
    // Initialize datepicker for Bootstrap 5 (using a datepicker plugin)
   
    // Fetch material options from API and populate dropdown
    //$.ajax({
    //    url: 'Material/GetAll', // Replace with your API endpoint
    //    method: 'GET',
    //    success: function (data) {
    //        let materialSelect = $('#materialId');
    //        data.forEach(material => {
    //            materialSelect.append(`<option value="${material.id}">${material.namaMaterial} (${material.tipeMaterial==0? "pokok" : "Non Pokok" })</option>`);
    //        });
    //    }
    //});
    $('#staticBackdrop').on('shown.bs.modal', function () {
        console.log("Modal muncul");
        // AJAX call to reload data when modal is shown
        $.ajax({
            url: 'Material/GetAll', // Replace with your API endpoint
            method: 'GET',
            success: function (data) {
                let materialSelect = $('#materialId');
                materialSelect.empty(); // Clear previous options
                data.forEach(material => {
                    materialSelect.append(`<option value="${material.id}">${material.namaMaterial} (${material.tipeMaterial == 0 ? "Pokok" : "Non Pokok"})</option>`);
                });
            }
        });
    });


    // Handle form submission
    $('#sprForm').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        console.log("SPR Form Submitted");
        // Get form values
        let formData = {
            tanggalMinta: $('#tanggalMinta').val() ? new Date($('#tanggalMinta').val()).toISOString() : new Date("0001-01-01").toISOString(),
            zonaSPR: $('#zonaSPR').val(),
            tujuanSPR: $('#tujuanSPR').val(),
            proyekId: 2, // Replace this with the selected project ID from your page
            userPemintaId: "6f09d97c-4d35-472f-bf72-68a29f62ecfa", // Replace with actual user ID (temporary)
            materialId: $('#materialId').val(),
            volume: $('#volume').val(),
            unit: $('#unit').val(),
            // Sertakan default value jika tanggalRencanaTerima tidak diisi
            tanggalRencanaTerima: $('#tanggalRencanaTerima').val() ? new Date($('#tanggalRencanaTerima').val()).toISOString() : new Date("0001-01-01").toISOString()
        };

        console.log("formData result before send to API . . .");
        console.log(formData);
        // Send POST request to API
        $.ajax({
            url: 'SPR/CreateSPR', // Replace with your POST API endpoint
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                alert('Form submitted successfully!');
                console.log(response);
            },
            error: function (xhr, status, error,etc) {
                // Cek jika responseText tidak kosong dan coba parsing manual
                if (xhr.responseText) {
                    try {
                        let responseJSON = JSON.parse(xhr.responseText);  // Parse response
                        console.error("Parsed Response JSON  . . :");  // Log hasil parse JSON
                        console.error(responseJSON.message);
                        alert(responseJSON.message || "Unknown error occurred");

                    } catch (e) {
                        alert("Failed to submit form. Error parsing responseText");
                        console.error("Error parsing responseText:", e);
                        console.error("Response Text (unparsed):", xhr.responseText);  // Jika tidak bisa di-parse
                    }
                } else {
                    alert('Failed to submit form. No responseText available. Please try again. . .');
                    console.error("No responseText available.");
                }
            }
        });
    });
});

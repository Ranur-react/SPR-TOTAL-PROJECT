
$(document).ready(function () {

    $('#modalDetil').on('shown.bs.modal', function () {
        console.log("Modal Detil muncul, panggil material");
        window.getMaterial;
    });


    // Handle form submission
    $('#detilForm').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        console.log("Detil Form Submitted");
        // Get form values
        let formData = {
            SPRId: varShareSPRid, // SPR id yang dikoleksi oleh Globa variabel pada tabel DetilDataTable
            userPemintaId: "6f09d97c-4d35-472f-bf72-68a29f62ecfa", // Replace with actual user ID (temporary)
            materialId: $('#materialDetilId').val(),
            volume: $('#volumeDetil').val(),
            unit: $('#unitDetil').val(),
            // Sertakan default value jika tanggalRencanaTerima tidak diisi
            tanggalRencanaTerima: $('#tanggalRencanaTerimaDetil').val() ? new Date($('#tanggalRencanaTerimaDetil').val()).toISOString() : new Date("0001-01-01").toISOString()
        };

        console.log("formData result before send to API DetilSPR/Post. . .");
        console.log(formData);
        // Send POST request to API
        $.ajax({
            url: 'DetilSPR/Post', // Replace with DetilSPR POST API endpoint
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                alert('Form DetilSPR submitted successfully!');
                //console.log(response);
                window.dataTableDetil.ajax.url(`DetilSPR/GetBySPR?SPRKode=${varShareSPRid}`).load();


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

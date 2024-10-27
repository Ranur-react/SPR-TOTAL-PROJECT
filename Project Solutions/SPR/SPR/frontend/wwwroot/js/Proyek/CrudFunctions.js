const addProyek = (id) => {
    console.log("add dipanggil untuk id" + id);
}

const updateProyek = (id) => {
    console.log("update dipanggil untuk id" + id);
}
const deleteProyek = (id) => {
    $.ajax({
        url: 'Proyek/Delete/' + id, // Replace with your API endpoint
        method: 'DELETE',
        success: function (data) {
            alert(`Hapus dat Proyek untuk id:${id} berhasil`);
            window.dataTableProyek.ajax.url(`Proyek/GetAll`).load();
        }
    });
}

$(document).ready(function () {
    $('#formAddProyek').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        console.log("Proyek Form Submitted");
        // Get form values
        let formData = {
            tanggalMinta: $('#tanggalMulai').val() ? new Date($('#tanggalMulai').val()).toISOString() : new Date("0001-01-01").toISOString(),
            namaProyek: $('#namaProyek').val(),
            lokasiProyek: $('#lokasiProyek').val(),
            tanggalSelesai: $('#tanggalSelesai').val() ? new Date($('#tanggalSelesai').val()).toISOString() : new Date("0001-01-01").toISOString(),

        };

        //console.log("formData result before send to API . . .");
        //console.log(formData);
        // Send POST request to API
        $.ajax({
            url: 'Proyek/Post', // Replace with your POST API endpoint
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                alert('Form submitted successfully!');
                //console.log(response);
                window.dataTableProyek.ajax.url(`Proyek/GetAll`).load();


            },
            error: function (xhr, status, error, etc) {
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
})
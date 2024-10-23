$(document).ready(function () {
    // Initialize datepicker for Bootstrap 5 (using a datepicker plugin)
    $('.datepicker').datepicker({
        format: 'yyyy-mm-dd',
        autoclose: true,
        todayHighlight: true
    });
    $("#datepicker-group").datepicker({
        format: "dd-M-yyyy",
        todayHighlight: true,
        autoclose: true,
        clearBtn: true
    });
    // Fetch material options from API and populate dropdown
    $.ajax({
        url: 'Material/GetAll', // Replace with your API endpoint
        method: 'GET',
        success: function (data) {
            let materialSelect = $('#materialId');
            data.forEach(material => {
                materialSelect.append(`<option value="${material.id}">${material.namaMaterial}(${material.tipeMaterial==0? "pokok" : "Non Pokok" })</option>`);
            });
        }
    });

    // Handle form submission
    $('#sprForm').submit(function (event) {
        event.preventDefault(); // Prevent default form submission

        // Get form values
        let formData = {
            tanggalMinta: $('#tanggalMinta').val() ? new Date($('#tanggalMinta').val()).toISOString() : null,
            zonaSPR: $('#zonaSPR').val(),
            tujuanSPR: $('#tujuanSPR').val(),
            proyekId: 2, // Replace this with the selected project ID from your page
            userPemintaId: "6f09d97c-4d35-472f-bf72-68a29f62ecfa", // Replace with actual user ID (temporary)
            materialId: $('#materialId').val(),
            volume: $('#volume').val(),
            unit: $('#unit').val(),
            tanggalRencanaTerima: $('#tanggalRencanaTerima').val() ? new Date($('#tanggalRencanaTerima').val()).toISOString() : null
        };

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
            error: function (xhr, status, error) {
                alert('Failed to submit form. Please try again.');
                console.error(error);
            }
        });
    });
});

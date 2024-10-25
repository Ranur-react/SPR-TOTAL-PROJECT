const DateToISoString = (data) => {
    const months = ["Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agu", "Sep", "Okt", "Nov", "Des"];
    const date = new Date(data);
    const day = date.getDate();
    const month = months[date.getMonth()];
    const year = date.getFullYear();

    // Mengembalikan tanggal dalam format "DD-MMM-YYYY"
    return `${day}-${month}-${year}`;
}
$(document).ready(function () {

   window.getMaterial= $.ajax({
        url: 'Material/GetAll', // Replace with your API endpoint
        method: 'GET',
        success: function (data) {
            let materialSelect = $('.materialId');
            materialSelect.empty(); // Clear previous options
            data.forEach(material => {
                materialSelect.append(`<option value="${material.id}">${material.namaMaterial} (${material.tipeMaterial == 0 ? "Pokok" : "Non Pokok"})</option>`);
            });
        }
    });
});

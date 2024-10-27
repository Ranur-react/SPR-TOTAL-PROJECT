const addMaterial = (id) => {
    console.log("add dipanggil untuk id" + id);
}

const updateMaterial = (id) => {
    console.log("update dipanggil untuk id" + id);
}
const deleteMaterial = (id) => {
    $.ajax({
        url: 'Material/Delete/' + id, // Replace with your API endpoint
        method: 'DELETE',
        success: function (data) {
            alert(`Hapus dat Material untuk id:${id} berhasil`);
            window.dataTableMaterial.ajax.url(`Material/GetAll`).load();
        }
    });
}
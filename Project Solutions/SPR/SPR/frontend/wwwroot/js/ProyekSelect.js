$(document).ready(function () {
    // Fungsi untuk mengambil parameter dari URL
    function getParameterByName(name) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(name);
    }

    // Fungsi untuk mengambil data proyek dari API
    function getProyekData() {
        $.ajax({
            url: "Proyek/GetAll",
            method: "GET",
            success: function (data) {
                updateProyekSelect(data);
                // Cek apakah ada ProyekId di URL
                const proyekId = getParameterByName('key');
                if (proyekId) {
                    $("#proyekSelect").val(proyekId).change(); // Pilih proyek yang sesuai dan trigger perubahan
                }
            },
            error: function (error) {
                console.error("Error fetching proyek data:", error);
            }
        });
    }

    // Fungsi untuk memperbarui pilihan proyek pada dropdown
    function updateProyekSelect(data) {
        var $select = $("#proyekSelect");
        $select.empty(); // Kosongkan dropdown

        // Tambahkan opsi proyek baru
        $.each(data, function (index, proyek) {
            $select.append(new Option(proyek.nama, proyek.id));
        });
    }

    // Fungsi untuk mendapatkan detail proyek berdasarkan ID yang dipilih
    function getProyekDetail(id) {
        $.ajax({
            url: "Proyek/Get/" + id, // Endpoint untuk mendapatkan detail proyek
            method: "GET",
            success: function (proyek) {
                // Update detail proyek
                $("#proyekTanggalStart").text(proyek.tanggalMulai);
                $("#proyekTanggalEnd").text(proyek.tanggalSelesai);
                //$("#usernameProyek").text(proyek.user.nama); // Ambil nama user dari detail proyek
                //$("#jabatanProyek").text(proyek.user.jabatan); // Ambil jabatan user dari detail proyek
            },
            error: function (error) {
                console.error("Error fetching proyek detail:", error);
            }
        });
    }

    // Event listener untuk perubahan dropdown proyek
    $("#proyekSelect").change(function () {
        var selectedId = $(this).val();
        getProyekDetail(selectedId); // Panggil fungsi untuk mendapatkan detail proyek
    });

    // Ambil data proyek saat halaman dimuat
    getProyekData();
});

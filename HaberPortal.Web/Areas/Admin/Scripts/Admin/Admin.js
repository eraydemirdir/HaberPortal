$(document).ready(function () {

    // etiketler multi select
    //--------------------------------------------------------------------------
    $("#SecilenEtiketler").chosen({
        no_results_text: "Girdi için sonuç bulunamadı: ",
        placeholder_text: "Etiket seçiniz..."
    });

    // haber grid toolbar
    //--------------------------------------------------------------------------
    var haber_grid_toolbar = [{
        text: 'Yeni Kayıt',
        iconCls: 'icon-add',
        handler: function () {
            window.location = app_root + 'Admin/Haber/HaberEkle';
        }
    }];

    // kategori grid toolbar
    //--------------------------------------------------------------------------
    var kategori_grid_toolbar = [{
        text: 'Yeni Kayıt',
        iconCls: 'icon-add',
        handler: function () {
            window.location = app_root + 'Admin/Kategori/KategoriEkle';
        }
    }];

    // galeri grid toolbar
    //--------------------------------------------------------------------------
    var galeri_grid_toolbar = [{
        text: 'Yeni Kayıt',
        iconCls: 'icon-add',
        handler: function () {
            window.location = app_root + 'Admin/Galeri/GaleriEkle';
        }
    }];

    // etiket grid toolbar
    //--------------------------------------------------------------------------
    var etiket_grid_toolbar = [{
        text: 'Yeni Kayıt',
        iconCls: 'icon-add',
        handler: function () {
            window.location = app_root + 'Admin/Etiket/EtiketEkle';
        }
    }];

    // rol grid toolbar
    //--------------------------------------------------------------------------
    var rol_grid_toolbar = [{
        text: 'Yeni Kayıt',
        iconCls: 'icon-add',
        handler: function () {
            window.location = app_root + 'Admin/Rol/RolEkle';
        }
    }];

    // kullanici grid toolbar
    //--------------------------------------------------------------------------
    var kullanici_grid_toolbar = [{
        text: 'Yeni Kayıt',
        iconCls: 'icon-add',
        handler: function () {
            window.location = app_root + 'Admin/Kullanici/KullaniciEkle';
        }
    }];


    // haberler grid
    //--------------------------------------------------------------------------
    $('#haber_grid').datagrid({
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        sortName: 'Id',
        sortOrder: 'asc',
        toolbar: haber_grid_toolbar,
        nowrap: false,
        autoRowHeight: false,
        fitColumns: true,
        url: app_root + 'Admin/Haber/HaberlerJson',
        columns: [[
            { field: 'Id', title: 'Id', width: 30, sortable: true },
            {
                field: 'Resim', title: 'Resim', formatter: function (value, row, index) {
                    return '<img src="' + app_root + row.KucukResim + '" class="haber_grid_resim">';
                }
            },
            { field: 'Baslik', title: 'Başlık', width: 150 },
            { field: 'Aciklama', title: 'Açıklama', width: 200 },
            { field: 'Kategori', title: 'Kategori', width: 100, sortable: true },
            { field: 'HaberTipi', title: 'Haber Tipi', sortable: true },
            { field: 'Yazar', title: 'Yazar' },
            {
                field: 'Yayinda', title: 'Yayında', formatter: function (value, row, index) {
                    return value ? '<a href="' + app_root + 'Admin/Haber/HaberDurumGuncelle?id=' + row.Id + '&durum=' + value + '" class="grid_buton aktif">Aktif</a>' :
                        '<a href="' + app_root + 'Admin/Haber/HaberDurumGuncelle?id=' + row.Id + '&durum=' + value + '" class="grid_buton pasif">Pasif</a>'
                }
            },
                {
                    field: 'Detay', title: 'Detay', formatter: function (value, row, index) {
                        return '<a href="' + app_root + 'Admin/Haber/HaberDetay?id=' + row.Id + '" class="grid_buton">Detay</a>';
                    }
                },
            {
                field: 'Duzenle', title: 'Düzenle', formatter: function (value, row, index) {
                    return '<a href="' + app_root + 'Admin/Haber/HaberDuzenle?id=' + row.Id + '" class="grid_buton">Düzenle</a>';
                }
            },
                {
                    field: 'Sil', title: 'Sil', formatter: function (value, row, index) {
                        return '<a href="' + app_root + 'Admin/Haber/HaberSil?id=' + row.Id + '" class="grid_buton" onclick="return confirm(\'Silmek istediğinize emin misiniz?\')">Sil</a>';
                    }
                }
        ]]
    });

    // kategoriler grid
    //--------------------------------------------------------------------------
    $('#kategori_grid').datagrid({
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        sortName: 'Id',
        sortOrder: 'asc',
        toolbar: kategori_grid_toolbar,
        nowrap: false,
        autoRowHeight: false,
        fitColumns: true,
        pageSize: 50,
        url: app_root + 'Admin/Kategori/KategorilerJson',
        columns: [[
            { field: 'Id', title: 'Id', width: 30, sortable: true },
            { field: 'Ad', title: 'Ad', width: 150, sortable: true },
            { field: 'Aciklama', title: 'Açıklama', width: 200 },
            {
                field: 'Duzenle', title: 'Düzenle', formatter: function (value, row, index) {
                    return '<a href="' + app_root + 'Admin/Kategori/KategoriDuzenle?id=' + row.Id + '" class="grid_buton">Düzenle</a>';
                }
            },
                {
                    field: 'Sil', title: 'Sil', formatter: function (value, row, index) {
                        return '<a href="' + app_root + 'Admin/Kategori/KategoriSil?id=' + row.Id + '" class="grid_buton" onclick="return confirm(\'Silmek istediğinize emin misiniz?\')">Sil</a>';
                    }
                }
        ]]
    });

    // galeriler grid
    //--------------------------------------------------------------------------
    $('#galeri_grid').datagrid({
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        sortName: 'Id',
        sortOrder: 'asc',
        toolbar: galeri_grid_toolbar,
        nowrap: false,
        autoRowHeight: false,
        fitColumns: true,
        pageSize: 50,
        url: app_root + 'Admin/Galeri/GalerilerJson',
        columns: [[
            { field: 'Id', title: 'Id', width: 30, sortable: true },
            { field: 'Ad', title: 'Ad', width: 150, sortable: true },
            { field: 'HaberBaslik', title: 'Haber', width: 250 },
            {
                field: 'Resimler', title: 'Resimler', formatter: function (value, row, index) {
                    return '<a href="' + app_root + 'Admin/Galeri/GaleriResimler?id=' + row.Id + '" class="grid_buton">Resimler</a>';
                }
            },
            {
                field: 'Duzenle', title: 'Düzenle', formatter: function (value, row, index) {
                    return '<a href="' + app_root + 'Admin/Galeri/GaleriDuzenle?id=' + row.Id + '" class="grid_buton">Düzenle</a>';
                }
            },
                {
                    field: 'Sil', title: 'Sil', formatter: function (value, row, index) {
                        return '<a href="' + app_root + 'Admin/Galeri/GaleriSil?id=' + row.Id + '" class="grid_buton" onclick="return confirm(\'Silmek istediğinize emin misiniz?\')">Sil</a>';
                    }
                }
        ]]
    });

    // etiketler grid
    //--------------------------------------------------------------------------
    $('#etiket_grid').datagrid({
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        sortName: 'Id',
        sortOrder: 'asc',
        toolbar: etiket_grid_toolbar,
        nowrap: false,
        autoRowHeight: false,
        fitColumns: true,
        pageSize: 50,
        url: app_root + 'Admin/Etiket/EtiketlerJson',
        columns: [[
            { field: 'Id', title: 'Id', width: 30, sortable: true },
            { field: 'Ad', title: 'Ad', width: 150, sortable: true },
            {
                field: 'Duzenle', title: 'Düzenle', formatter: function (value, row, index) {
                    return '<a href="' + app_root + 'Admin/Etiket/EtiketDuzenle?id=' + row.Id + '" class="grid_buton">Düzenle</a>';
                }
            },
                {
                    field: 'Sil', title: 'Sil', formatter: function (value, row, index) {
                        return '<a href="' + app_root + 'Admin/Etiket/EtiketSil?id=' + row.Id + '" class="grid_buton" onclick="return confirm(\'Silmek istediğinize emin misiniz?\')">Sil</a>';
                    }
                }
        ]]
    });

    // kullanıcılar grid
    //--------------------------------------------------------------------------
    $('#kullanici_grid').datagrid({
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        sortName: 'Id',
        sortOrder: 'asc',
        nowrap: false,
        autoRowHeight: false,
        fitColumns: true,
        pageSize: 50,
        toolbar: kullanici_grid_toolbar,
        url: app_root + 'Admin/Kullanici/KullanicilarJson',
        columns: [[
            { field: 'Id', title: 'Id', width: 30, sortable: true },
            { field: 'Ad', title: 'Ad', width: 150, sortable: true },
            { field: 'Eposta', title: 'Eposta', sortable: true },
            {
                field: 'Duzenle', title: 'Düzenle', formatter: function (value, row, index) {
                    return '<a href="' + app_root + 'Admin/Kullanici/KullaniciDuzenle?id=' + row.Id + '" class="grid_buton">Düzenle</a>';
                }
            },
                {
                    field: 'Sil', title: 'Sil', formatter: function (value, row, index) {
                        return '<a href="' + app_root + 'Admin/Kullanici/KullaniciSil?id=' + row.Id + '" class="grid_buton" onclick="return confirm(\'Silmek istediğinize emin misiniz?\')">Sil</a>';
                    }
                }
        ]]
    });

    // roller grid
    //--------------------------------------------------------------------------
    $('#rol_grid').datagrid({
        rownumbers: true,
        singleSelect: true,
        pagination: true,
        sortName: 'Id',
        sortOrder: 'asc',
        nowrap: false,
        autoRowHeight: false,
        fitColumns: true,
        pageSize: 50,
        toolbar: rol_grid_toolbar,
        url: app_root + 'Admin/Rol/RollerJson',
        columns: [[
            { field: 'Id', title: 'Id', width: 30, sortable: true },
            { field: 'Ad', title: 'Ad', width: 150, sortable: true },
            {
                field: 'Duzenle', title: 'Düzenle', formatter: function (value, row, index) {
                    return '<a href="' + app_root + 'Admin/Rol/RolDuzenle?id=' + row.Id + '" class="grid_buton">Düzenle</a>';
                }
            },
                {
                    field: 'Sil', title: 'Sil', formatter: function (value, row, index) {
                        return '<a href="' + app_root + 'Admin/Rol/RolSil?id=' + row.Id + '" class="grid_buton" onclick="return confirm(\'Silmek istediğinize emin misiniz?\')">Sil</a>';
                    }
                }
        ]]
    });

    // tinymce ayarları
    //--------------------------------------------------------------------------
    tinymce.init({
        selector: "textarea.featured_textarea",
        height: 500,
        width: 600,
        plugins: [
        "advlist autolink lists link image charmap print preview hr anchor pagebreak",
        "searchreplace wordcount visualblocks visualchars code fullscreen",
        "insertdatetime media nonbreaking save table contextmenu directionality",
        "emoticons template paste"
        ],
        toolbar1: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent",
        toolbar2: "print preview media | forecolor backcolor emoticons | link image",
        templates: [
            { title: 'Test template 1', content: 'Test 1' },
            { title: 'Test template 2', content: 'Test 2' }
        ]
    });

    // galeri resimlerini değiştirme
    //--------------------------------------------------------------------------
    $("#Galeriler").change(function () {
        window.location = app_root + "Admin/Galeri/GaleriResimler?id=" + $(this).val();
    });
});
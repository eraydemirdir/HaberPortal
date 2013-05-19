$(document).ready(function () {
    $(".kategori_detay .slider_resim_tutucu:first").removeClass("gizli");
    $('.slider_nav_bar .nav_bar_button:first a').addClass("aktif");

    // sliderdaki her resmin url özelliğini, 
    // slider butonlarına tanımlama
    $(".kategori_detay .slider_resim_tutucu").each(function (index) {
        var href = $(this).children("a").attr("href");
        $(".slider_navbar .slider_navbar_button:eq(" + index + ") a").attr("href", href);
    });

    // üzerine geldiğimiz butonun haberini aktif yapmak
    $(".slider_navbar .slider_navbar_button a").hover(function () {
        var index = $('.slider_navbar .slider_navbar_button a').index(this);
        $('.kategori_detay .slider_resim_tutucu').eq(index).removeClass('gizli').siblings().addClass('gizli');
        $('.slider_navbar .slider_navbar_button a').removeClass("aktif");
        $(this).addClass('aktif');
    });
});
$(document).ready(function () {
    $(".slider .orta_resim_tutucu:first").removeClass("gizli");
    $('.slider_nav_bar .nav_bar_button:first a').addClass("aktif");

    // sliderdaki her resmin url özelliğini, 
    // slider butonlarına tanımlama
    $(".slider .orta_resim_tutucu").each(function (index) {
        var href = $(this).children("a").attr("href");
        $(".slider_nav_bar .nav_bar_button:eq(" + index + ") a").attr("href", href);
    });

    // üzerine geldiğimiz butonun haberini aktif yapmak
    $(".slider_nav_bar .nav_bar_button a").hover(function () {
        var index = $('.slider_nav_bar .nav_bar_button a').index(this);
        $('.slider .orta_resim_tutucu').eq(index).removeClass('gizli').siblings().addClass('gizli');
        $('.slider_nav_bar .nav_bar_button a').removeClass("aktif");
        $(this).addClass('aktif');
    });
});
$(window).on('load', function () {
    $('#mobile-menu-icon').on('click', mobileMenuIcon_Click);
});

function mobileMenuIcon_Click() {
    var menuIcon = $(this);
    var mobileMenu = $('#mobile-menu');

    if (menuIcon.hasClass('mobile-menu-closed')) {
        menuIcon.removeClass('mobile-menu-closed');
        menuIcon.addClass('mobile-menu-opened');
        mobileMenu.show();
        return false;
    }

    menuIcon.addClass('mobile-menu-closed');
    menuIcon.removeClass('mobile-menu-opened');
    mobileMenu.hide();
}
$('#navigation .navbar-nav .nav-link a').on('click', function () {
    $('#navigation .navbar-nav .nav-link').find('li.active').removeClass('active');
    $(this).parent('li').addClass('active');
});
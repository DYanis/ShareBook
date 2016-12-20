//trigger affix
$(function () {
    $('#mainNav').addClass('affix');
    $(window).on('scroll', function () {
        $('#mainNav').removeClass('affix-top');
        $('#mainNav').addClass('affix');
    });
});
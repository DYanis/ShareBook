// Agency Theme JavaScript

(function($) {
    "use strict"; // Start of use strict

    // jQuery for page scrolling feature - requires jQuery Easing plugin
    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top - 50)
        }, 1250, 'easeInOutExpo');
        event.preventDefault();
    });

    // Closes the Responsive Menu on Menu Item Click
    $('.navbar-collapse ul li a').click(function(){ 
            $('.navbar-toggle:visible').click();
    });

    // Offset for Main Navigation
    $('#mainNav').affix({
        offset: {
            top: 100
        }
    })

    //Auto change background of header
    var currentBackground = 0;
    var backgrounds = [];
    backgrounds[0] = '../images/headerBackgrounds/background1.jpg';
    backgrounds[1] = '../images/headerBackgrounds/background2.jpg';
    backgrounds[2] = '../images/headerBackgrounds/background3.jpg';
    backgrounds[3] = '../images/headerBackgrounds/background4.jpg';

    function changeBackground() {
        currentBackground++;
        if (currentBackground > 3) currentBackground = 0;

        $('header').css({
            'background-image': "url('" + backgrounds[currentBackground] + "')"
        });

        setTimeout(changeBackground, 3 * 1000);
    }

    $(document).ready(function () {
        changeBackground();
    })

    //Change search visibility on selection
    $(function () {
        var inputs = $('.searchInput');

        $('#inlineRadio1').on('click', function () {
            inputs[0].attr('placeholder', 'ISBN, Title or Author');
        });

        $('#inlineRadio2').on('click', function () {
            inputs[0].attr('placeholder', 'Username');
        });
    });

    //Submit search
    $(function () {
        $('#indexSearch').on('click', function () {
            
        });
    });
    
    //logout
    $(function () {
        $('#logout').on('click', function () {
            $.post("/Account/LogOff", null);
        });
    });

})(jQuery); // End of use strict

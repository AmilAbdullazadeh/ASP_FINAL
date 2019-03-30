/*!
 * Version: 1.2 Development
 */



(function () {

    "use strict";




    var Core = {
        initialized: false,
        initialize: function () {
            if (this.initialized)
                return;
            this.initialized = true;
            this.build();
        },
        build: function () {

            this.fixedHeader();
           // Init toggle menu
            this.initToggleMenu();
      // Search
      this.initSearchModal();
      // Dropdown menu
      this.dropdownhover();

        },




   initSearchModal: function(options) {


      $(document).on("click", ".btn_header_search", function (event) {
        event.preventDefault();

        $(".header-search").addClass("open");
      });
      $(document).on("click", ".search-form_close , .search-close", function (event) {
        event.preventDefault();
        $(".header-search").removeClass("open");
      });

    },




        initToggleMenu: function () {


      $('.toggle-menu-button').each(function (i) {


            var trigger = $(this);
            var isClosed = true;

            function showMenu() {



                $('#nav').addClass('navbar-scrolling-fixing');



        if ( trigger.hasClass( "js-toggle-screen" )) {

             $('#fixedMenu').delay(0).fadeIn(300);

            }

                trigger.addClass('is-open');
                isClosed = false;
            }

            function hideMenu() {
                $('#fixedMenu').fadeOut(100);
                $('#nav').removeClass('navbar-scrolling-fixing');
                trigger.removeClass('is-open');
                isClosed = true;
            }

            trigger.on('click', function (e) {
                e.preventDefault();
                if (isClosed === true) {
                    showMenu();
                } else {
                    hideMenu();
                }
            });


     });   },



    dropdownhover: function(options) {
      /** Extra script for smoother navigation effect **/
      if ($(window).width() > 798) {
        $('.yamm').on('mouseenter', '.navbar-nav > .dropdown', function() {
          "use strict";
          $(this).addClass('open');
        }).on('mouseleave', '.navbar-nav > .dropdown', function() {
          "use strict";
          $(this).removeClass('open');
        });
      }
    },

        fixedHeader: function (options) {
            if ($(window).width() > 767) {
                // Fixed Header
                var topOffset = $(window).scrollTop();
                if (topOffset > 0) {
                    $('.header').addClass('navbar-scrolling');
                }
                $(window).on('scroll', function () {
                    var fromTop = $(this).scrollTop();
                    if (fromTop > 0) {
                        $('body').addClass('fixed-header');
                        $('.header').addClass('navbar-scrolling');
                    } else {
                        $('body').removeClass('fixed-header');
                       $('.header').removeClass('navbar-scrolling');
                    }

                });
            }
        },





    };
    Core.initialize();




      /////////////////////////////////////////////////////////////////
    //   Dropdown Menu Fade
    /////////////////////////////////////////////////////////////////




    $(".yamm >li").hover(
        function() {
            $('.dropdown-menu', this).fadeIn("fast");
        },
        function() {
            $('.dropdown-menu', this).fadeOut("fast");
        });




    window.prettyPrint && prettyPrint();
    $(document).on('click', '.yamm .dropdown-menu', function(e) {
        e.stopPropagation();
    });




  // Create a new instance of Slidebars
    var controller = new slidebars();

    // Events
    $( controller.events ).on( 'init', function () {
        // console.log( 'Init event' );
    } );

    $( controller.events ).on( 'exit', function () {
        // console.log( 'Exit event' );
    } );

    $( controller.events ).on( 'css', function () {
        // console.log( 'CSS event' );
    } );

    $( controller.events ).on( 'opening', function ( event, id ) {
        // console.log( 'Opening event of slidebar with id ' + id );
    } );

    $( controller.events ).on( 'opened', function ( event, id ) {
        // console.log( 'Opened event of slidebar with id ' + id );
    } );

    $( controller.events ).on( 'closing', function ( event, id ) {
        // console.log( 'Closing event of slidebar with id ' + id );
    } );

    $( controller.events ).on( 'closed', function ( event, id ) {
        // console.log( 'Closed event of slidebar with id ' + id );
    } );

    // Initialize Slidebars
    controller.init();



      // Mobile Slidebar controls



      $( '.js-toggle-mobile-slidebar' ).on( 'click', function ( event ) {
            event.stopPropagation();
            controller.toggle( 'mobile-slidebar' );
        } );





        // Panel nav  Slidebar controls



         $( '.js-open-slidebar-panel-left' ).on( 'click', function ( event ) {
      event.preventDefault();
      event.stopPropagation();
      controller.toggle( 'slidebar-panel-left' );
    } );





    // Left Slidebar controls
    $( '.js-open-left-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.open( 'slidebar-1' );
    } );

    $( '.js-close-left-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.close( 'slidebar-1' );
    } );

    $( '.js-toggle-left-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.toggle( 'slidebar-1' );
    } );

    // Right Slidebar controls
    $( '.js-open-right-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.open( 'slidebar-2' );
    } );

    $( '.js-close-right-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.close( 'slidebar-2' );
    } );

    $( '.js-toggle-right-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.toggle( 'slidebar-2' );
    } );

    // Top Slidebar controls
    $( '.js-open-top-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.open( 'slidebar-3' );
    } );

    $( '.js-close-top-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.close( 'slidebar-3' );
    } );

    $( '.js-toggle-top-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.toggle( 'slidebar-3' );
    } );

    // Bottom Slidebar controls
    $( '.js-open-bottom-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.open( 'slidebar-4' );
    } );

    $( '.js-close-bottom-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.close( 'slidebar-4' );
    } );

    $( '.js-toggle-bottom-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.toggle( 'slidebar-4' );
    } );

    // Close any
    $( controller.events ).on( 'opened', function () {
        $( '[data-canvas="container"]' ).addClass( 'js-close-any-slidebar' );
    $( '.toggle-menu-button' ).addClass( 'is-open' );
    } );

    $( controller.events ).on( 'closed', function () {
        $( '[data-canvas="container"]' ).removeClass( 'js-close-any-slidebar' );
    $( '.toggle-menu-button' ).removeClass( 'is-open' );
    } );

    $( 'body' ).on( 'click', '.js-close-any-slidebar', function ( event ) {
        event.stopPropagation();
        controller.close();
    } );

    // Initilize, exit and css reset
    $( '.js-initialize-slidebars' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.init();
    } );

    $( '.js-exit-slidebars' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.exit();
    } );

    $( '.js-reset-slidebars-css' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.css();
    } );

    // Is and get
    $( '.js-is-active' ).on( 'click', function ( event ) {
        event.stopPropagation();
        // console.log( controller.isActive() );
    } );

    $( '.js-is-active-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        var id = prompt( 'Enter a Slidebar id' );
        // console.log( controller.isActiveSlidebar( id ) );
    } );

    $( '.js-get-active-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        // console.log( controller.getActiveSlidebar() );
    } );

    $( '.js-get-all-slidebars' ).on( 'click', function ( event ) {
        event.stopPropagation();
        // console.log( controller.getSlidebars() );

    } );

    $( '.js-get-slidebar' ).on( 'click', function ( event ) {
        event.stopPropagation();
        var id = prompt( 'Enter a Slidebar id' );
        // console.log( controller.getSlidebar( id ) );
    } );

    // Callbacks
    $( '.js-init-callback' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.init( function () {
            // console.log( 'Init callback' );
        } );
    } );

    $( '.js-exit-callback' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.exit( function () {
            // console.log( 'Exit callback' );
        } );
    } );

    $( '.js-css-callback' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.css( function () {
            // console.log( 'CSS callback' );
        } );
    } );

    $( '.js-open-callback' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.open( 'slidebar-1', function () {
            // console.log( 'Open callback' );
        } );
    } );

    $( '.js-close-callback' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.close( function () {
            // console.log( 'Close callback' );
        } );
    } );

    $( '.js-toggle-callback' ).on( 'click', function ( event ) {
        event.stopPropagation();
        controller.toggle( 'slidebar-1', function () {
            // console.log( 'Toggle callback' );
        } );
    } );



})();






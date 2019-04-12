/* ----------------------------------------------------------------------------------------
* Author        : Barberda
* Template Name : Barberda | One Page Medical Html Template
* File          : Barberda main JS file
* Version       : 1.0
* ---------------------------------------------------------------------------------------- */




    
/* INDEX
----------------------------------------------------------------------------------------

01. Preloader js

02. change Menu background on scroll js 

03. Navigation js

04. Smooth scroll to anchor

05. Portfolio js

06. Magnific Popup js

07. Testimonial js

08. Google Map js

9. Ajax Contact Form js

10. Mailchimp js

-------------------------------------------------------------------------------------- */





(function($) {
'use strict';

		var buzplan = $(window);
	
    /*-------------------------------------------------------------------------*
     *                  01. Preloader js                                       *
     *-------------------------------------------------------------------------*/
      buzplan.on( 'load', function(){
        
          $('#preloader').delay(300).fadeOut('slow',function(){
            $(this).remove();
          });    

      }); // $(window).on end







    /*-------------------------------------------------------------------------*
     *             02. change Menu background on scroll js                     *
     *-------------------------------------------------------------------------*/
		buzplan.on('scroll', function () {
		  var menu_area = $('.menu-area');
		  if (buzplan.scrollTop() > 0) {
			  menu_area.addClass('stricky-fixed');
		  } else {
			  menu_area.removeClass('stricky-fixed');
		  }
		}); // $(window).on('scroll' end

		
		
    /*-------------------------------------------------------------------------*
     *             03. show log on scroll js                     *
     *-------------------------------------------------------------------------*/
		buzplan.on('scroll', function () {
		  var header_area = $('.navbar-brand');
		  if (buzplan.scrollTop() > 0) {
			  header_area.css({"display":"block"});
		  } else {
			 header_area.css({"display":"none"});
		  }
		}); // $(window).on('scroll' end


		

	

    /*-------------------------------------------------------------------------*
     *                   04. Navigation js                                     *
     *-------------------------------------------------------------------------*/
      $(document).on('click', '.navbar-collapse.in', function (e) {
          if ($(e.target).is('a') && $(e.target).attr('class') != 'dropdown-toggle') {
              $(this).collapse('hide');
          }
      });

      $('body').scrollspy({
          target: '.navbar-collapse',
          offset: 195
      });



    /*-------------------------------------------------------------------------*
     *                   05. Smooth scroll to anchor                           *
     *-------------------------------------------------------------------------*/
      $('a.smooth_scroll').on("click", function (e) {
          e.preventDefault();
          var anchor = $(this);
          $('html, body').stop().animate({
              scrollTop: $(anchor.attr('href')).offset().top - 50
          }, 1000);
      });

	  
	  
	/*-------------------------------------------------------------------------*
     *                   06. Slider Settings                           *
     *-------------------------------------------------------------------------*/
		 $('#carousel-example-generic').carousel({
			interval: 5000
		  }); 

		  
    /*-------------------------------------------------------------------------*
     *                  07. Portfolio js                                       *
     *-------------------------------------------------------------------------*/
      $('.portfolio').mixItUp();



    /*-------------------------------------------------------------------------*
     *                  08. Magnific Popup js                                  *
     *-------------------------------------------------------------------------*/
      $('.work-popup').magnificPopup({
          type: 'image',
          gallery: {
              enabled: true
          },
          zoom: {
              enabled: true,
              duration: 300, // don't foget to change the duration also in CSS
              opener: function(element) {
                  return element.find('img');
              }
          }
          
      });
      

      $('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
          disableOn: 700,
          type: 'iframe',
          mainClass: 'mfp-fade',
          removalDelay: 160,
          preloader: false,
          fixedContentPos: false
      });


    /*-------------------------------------------------------------------------*
     *                  09. Testimonial js                                     *
     *-------------------------------------------------------------------------*/
      $('.testimonial-list').owlCarousel({
          slideSpeed      : 1000,
          paginationSpeed : 500,
          singleItem      : true,
          lazyLoad        : false,
          pagination      : true,
          navigation      : false,
          autoPlay        : false,	  
      });
		
		
	/*-------------------------------------------------------------------------*
     *                       10. Datepicker js                                 *
     *-------------------------------------------------------------------------*/	
	 
		{
			$( "#datepicker" ).datepicker();
		  } ;
	
	
	/*-------------------------------------------------------------------------*
     *                       11. Google Map js                                 *
     *-------------------------------------------------------------------------*/

            var myCenter=new google.maps.LatLng(23.810332,90.412518);
            function initialize()
            {
                var mapProp = {
                	center:myCenter,
               		scrollwheel: false,
                	zoom:6,
                	mapTypeId:google.maps.MapTypeId.ROADMAP
                };
				
                var map=new google.maps.Map(document.getElementById("contactgoogleMap"),mapProp);
                var marker=new google.maps.Marker({
	                position:myCenter,
	                animation:google.maps.Animation.BOUNCE,
	                icon:'assets/img/map-marker.png',
	                map: map,
                });
                var styles = [
					{
						stylers: [
							{ hue: "#c5c5c5" },
							{ saturation: -100 }
						]
					},
                ];
                map.setOptions({styles: styles});
                marker.setMap(map);
            }
            google.maps.event.addDomListener(window, 'load', initialize);

  
  /*-------------------------------------------------------------------------*
     *                  12. Ajax Contact Form js                               *
     *-------------------------------------------------------------------------*/
      // Get the form.
      var form = $('#ajax-contact');

      // Get the messages div.
      var formMessages = $('#form-messages');

      // Set up an event listener for the contact form.
      $(form).on('submit', function(e) {
          // Stop the browser from submitting the form.
          e.preventDefault();

          // Serialize the form data.
          var formData = $(form).serialize(); 

          // Submit the form using AJAX.
          $.ajax({
              type: 'POST',
              url: $(form).attr('action'),
              data: formData
          })
          .done(function(response) {
              // Make sure that the formMessages div has the 'success' class.
              $(formMessages).removeClass('error');
              $(formMessages).addClass('success');

              // Set the message text.
              $(formMessages).text(response);

              // Clear the form.
              $('#name').val('');
              $('#email').val('');
              $('#phone').val('');
              $('#message').val('');

          })
          .fail(function(data) {
              // Make sure that the formMessages div has the 'error' class.
              $(formMessages).removeClass('success');
              $(formMessages).addClass('error');

              // Set the message text.
              if (data.responseText !== '') {
                  $(formMessages).text(data.responseText);
              } else {
                  $(formMessages).text('Oops! An error occured and your message could not be sent.');
              }
          });

      });


	  
	  
	    /*-------------------------------------------------------------------------*
     *                  13. booking Ajax Form js                               *
     *-------------------------------------------------------------------------*/
      // Get the form.
      var form = $('#ajax-appoint');

      // Get the messages div.
      var formMessages = $('#form-appoint');

      // Set up an event listener for the contact form.
      $(form).on('submit', function(e) {
          // Stop the browser from submitting the form.
          e.preventDefault();

          // Serialize the form data.
          var formData = $(form).serialize(); 

          // Submit the form using AJAX.
          $.ajax({
              type: 'POST',
              url: $(form).attr('action'),
              data: formData
          })
          .done(function(response) {
              // Make sure that the formMessages div has the 'success' class.
              $(formMessages).removeClass('error');
              $(formMessages).addClass('success');

              // Set the message text.
              $(formMessages).text(response);

              // Clear booking the form.
              $('#b_name').val('');
              $('#b_email').val('');
              $('#b_phone').val('');
              $('#datepicker').val('');
              $('#catagory').val('');
              $('#bar').val('');
              $('#b_message').val('');

          })
          .fail(function(data) {
              // Make sure that the formMessages div has the 'error' class.
              $(formMessages).removeClass('success');
              $(formMessages).addClass('error');

              // Set the message text.
              if (data.responseText !== '') {
                  $(formMessages).text(data.responseText);
              } else {
                  $(formMessages).text('Oops! An error occured and your message could not be sent.');
              }
          });

      });
	  
	  

        /*-------------------------------------------------------------------------*
         *                   14. MailChimp js                                    *
         *-------------------------------------------------------------------------*/
          $('#mc-form').ajaxChimp({
            language: 'en',
            callback: mailChimpResponse,

            // ADD YOUR MAILCHIMP URL BELOW HERE!
            url: 'http://coderspoint.us14.list-manage.com/subscribe/post?u=e5d45c203261b0686dad32537&amp;id=d061f39c51'
            
          });

          function mailChimpResponse(resp) {
            if (resp.result === 'success') {
              $('.mailchimp-success').html('' + resp.msg).fadeIn(900);
              $('.mailchimp-error').fadeOut(400);

            } else if(resp.result === 'error') {
              $('.mailchimp-error').html('' + resp.msg).fadeIn(900);
            }  
          }



  
})(jQuery);


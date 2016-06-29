$(document).ready(function(){

	/* this is for item carousel */
	$('.carousel[data-type="multi"] .item').each(function(){
	  var next = $(this).next();
	  if (!next.length) {
	    next = $(this).siblings(':first');
	  }
	  next.children(':first-child').clone().appendTo($(this));
	  
	  for (var i=0;i<2;i++) {
	    next=next.next();
	    if (!next.length) {
	    	next = $(this).siblings(':first');
	  	}
	    
	    next.children(':first-child').clone().appendTo($(this));
	  }
	});


	/* this is for alter text show in browse category */
	$('.brws-pic-mnu img').hover(function(){
		var showalt = $(this).attr('alt');
		console.log(showalt);
		$(".browse-category .alt-text-show").text(showalt);
	});

	// this is for selling manu active 
	$(".account-selling-lstItem li a").on("click", function(){
		
		$('ul li.sdmnu-active').removeClass('sdmnu-active');
    	$(this).closest('li').addClass('sdmnu-active');
	});
	


});
//	//Controls in the heading
//	/////////////////////////////////////
//	hs.graphicsDir = '/scripts/editor/plugins/highslide/js/graphics/';
//	hs.align = 'center';
//	hs.transitions = ['expand', 'crossfade'];
//	hs.outlineType = 'rounded-white';
//	hs.wrapperClassName = 'controls-in-heading';
//	hs.fadeInOut = true;
//	//hs.dimmingOpacity = 0.75;
//
//	// Add the controlbar
//	if (hs.addSlideshow) hs.addSlideshow({
//		//slideshowGroup: 'group1',
//		interval: 5000,
//		repeat: false,
//		useControls: true,
//		fixedControls: false,
//		overlayOptions: {
//			opacity: 1,
//			position: 'top right',
//			hideOnMouseOut: false
//		}
//	});


//	//Gallery example with white design
//	/////////////////////////////////////
//	hs.graphicsDir = '/scripts/editor/plugins/highslide/js/graphics/';
//	hs.align = 'center';
//	hs.transitions = ['expand', 'crossfade'];
//	hs.outlineType = 'rounded-white';
//	hs.fadeInOut = true;
//	//hs.dimmingOpacity = 0.75;
//	
//	// Add the controlbar
//	hs.addSlideshow({
//		//slideshowGroup: 'group1',
//		interval: 5000,
//		repeat: false,
//		useControls: true,
//		fixedControls: 'fit',
//		overlayOptions: {
//			opacity: .75,
//			position: 'bottom center',
//			hideOnMouseOut: true
//		}
//	});


//	//Gallery example with dark design
//	/////////////////////////////////////
//	hs.graphicsDir = '/scripts/editor/plugins/highslide/js/graphics/';
//	hs.align = 'center';
//	hs.transitions = ['expand', 'crossfade'];
//	hs.outlineType = 'glossy-dark';
//	hs.wrapperClassName = 'dark';
//	hs.fadeInOut = true;
//	//hs.dimmingOpacity = 0.75;
//	
//	// Add the controlbar
//	if (hs.addSlideshow) hs.addSlideshow({
//		//slideshowGroup: 'group1',
//		interval: 5000,
//		repeat: false,
//		useControls: true,
//		fixedControls: 'fit',
//		overlayOptions: {
//			opacity: .6,
//			position: 'bottom center',
//			hideOnMouseOut: true
//		}
//	});


	//No border and a floating caption
	/////////////////////////////////////
	hs.graphicsDir = '/scripts/editor/plugins/highslide/js/graphics/';
	hs.align = 'center';
	hs.transitions = ['expand', 'crossfade'];
	hs.wrapperClassName = 'dark borderless floating-caption';
	hs.fadeInOut = true;
	hs.dimmingOpacity = .75;

	// Add the controlbar
	if (hs.addSlideshow) hs.addSlideshow({
		//slideshowGroup: 'group1',
		interval: 5000,
		repeat: false,
		useControls: true,
		fixedControls: 'fit',
		overlayOptions: {
			opacity: .6,
			position: 'bottom center',
			hideOnMouseOut: true
		}
	});
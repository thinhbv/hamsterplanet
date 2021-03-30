/*********************************************************************************************************/
/**
 * FCKeditor Highslide JS Plugin For Fckeditor (Author: Lajox ; Email: lajox@19www.com)
 * version:	 1.2
 * Released: On 2009-12-15
 * Download: http://code.google.com/p/lajox
 */
/*********************************************************************************************************/


FCKCommands.RegisterCommand('HighSlide', new FCKDialogCommand('HighSlide', FCKLang.HighSlideJS, FCKPlugins.Items['highslide'].Path +'highslide.html', 380,180)) ;
var HSJS = new FCKToolbarButton('HighSlide', FCKLang.HighSlideJS) ;
HSJS.IconPath = FCKPlugins.Items['highslide'].Path +'hs.gif';
FCKToolbarItems.RegisterItem('HighSlide', HSJS);

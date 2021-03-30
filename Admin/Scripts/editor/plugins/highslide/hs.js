/*********************************************************************************************************/
/**
 * FCKeditor Highslide JS Plugin For Fckeditor (Author: Lajox ; Email: lajox@19www.com)
 * version:	 1.2
 * Released: On 2009-12-15
 * Download: http://code.google.com/p/lajox
 */
/*********************************************************************************************************/

var dialog	= window.parent ;
var oEditor    = window.parent.InnerDialogLoaded(); 
var FCK        = oEditor.FCK; 
var FCKLang    = oEditor.FCKLang ;
var FCKConfig  = oEditor.FCKConfig ;

var highslideJS      = FCKConfig.PluginsPath +"highslide/js/highslide-full.min.js";
var highslideCSS     = FCKConfig.PluginsPath +"highslide/js/highslide.css";
var highslideMainJS  = FCKConfig.PluginsPath +"highslide/js/main.js";

var JSVar ="";
//JSVar  = '<scr' + 'ipt type="text/javascript" src="'+ highslideJS +'"></scr' + 'ipt>\r\n';
//JSVar += '<link rel="stylesheet" type="text/css" href="'+highslideCSS+'" />\r\n';
//JSVar += '<scr' + 'ipt type="text/javascript" src="'+ highslideMainJS +'"></scr' + 'ipt>\r\n';
JSVar += '<div class="highslide-gallery">\r\n';


window.onload = function()
{
	oEditor.FCKLanguageManager.TranslatePage(document) ;
	//window.parent.SetOkButton( true ) ;
}

function Ok() {	return true;}

function MakeHighSlideJS() {

 //var str = window.opener.FCK.EditorDocument.body.innerHTML;
 var str = FCK.GetXHTML();

// Method 1：
/*
 str = str.replace(/^|(<a\b[^>]*>)?\s*(<img\b[^/>]*(?:src=("[^"]*"|'[^']*'|\S+))[^>]*>)\s*(?:<\/a>)?/ig, function() {
    var $ = arguments;
    if ($[0].length) {
        return [
            '<a href=' + $[3] + ' class="highslide" onclick="return hs.expand(this)">'
            , '<img src=' + $[3] + ' alt="Highslide_JS" title="Click_to_enlarge_image"></a>'
            , '<div class="highslide-heading">&nbsp;</div>'
        ].join("\r\n");
    } else {
        return JSVar;

	}
});
*/

// Method 2：
str = str.replace(/<img((?![^<>]*?title[^<>]*?>).*?)>/ig, '<img title=\"Click to zoom image\"$1>' );
str = str.replace(/<img(.+)title\s*=\s*[\'\"]?([^\s<\'\"]*)[\'\"]?(.*)>/ig, "<img$1title=\"$2\"$3>");

str = str.replace(/<img((?![^<>]*?alt[^<>]*?>).*?)>/ig, '<img alt=\"Highslide_JS\"$1>' );
str = str.replace(/<img(.+)alt\s*=\s*[\'\"]?([^\s<\'\"]*)[\'\"]?(.*)>/ig, "<img$1alt=\"$2\"$3>");

// do not make any changes <img ...> property values
str = str.replace(/^|(<a\b[^>]*>)?\s*(<img(\b[^/>]*)(?:src=("[^"]*"|'[^']*'|\S+))([^>]*)>)\s*(?:<\/a>)?/ig, function() {
    var $ = arguments;
    if ($[0].length) {
        return [
            '<a href=' + $[4] + ' class="highslide" onclick="return hs.expand(this)">'
            , '<img ' + $[3] + 'src=' + $[4] + $[5]+ '></a>'
            , '<div class="highslide-heading">&nbsp;</div>'
        ].join("\r\n");
    } else {
        return JSVar;
	}
});

FCK.SetHTML(str);

document.getElementById("msgok").innerHTML = "<span fckLang=\"DlgHighSlide_ApplySuccess\">Highslide JS effect applied successfully</span>";
document.getElementById("setHsBtn").style.display = "none";
oEditor.FCKLanguageManager.TranslatePage(document) ;
}



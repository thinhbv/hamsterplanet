@echo off

set brushes= shBrushCpp.js + shBrushCSharp.js + shBrushCss.js + shBrushDelphi.js + shBrushJava.js + shBrushJavaFX.js + shBrushJScript.js + shBrushPhp.js + shBrushPlain.js + shBrushPowerShell.js + shBrushPython.js + shBrushRuby.js + shBrushSql.js + shBrushVb.js + shBrushXml.js

echo YOU ARE ABOUT TO MERGE ALL THE JAVASCRIPT FILES
echo THAT ARE LISTED IN THIS BATCH FILE
echo.
pause
echo.
echo.
set backup_name="compressed%date:~10,4%%date:~4,2%%date:~7,2%%time:~0,2%%time:~3,2%%time:~6,2%.bak" 
echo CURRENT FILE BACKED UP TO %backup_name%
copy compressed.js %backup_name% /b /y
echo.
echo THE FOLLOWING FILES HAVE BEEN MERGED INTO THE "compressed.js" FILE
copy shCore.js + %brushes% + shConfig.js compressed.js /b /y 
echo.
echo.
echo WE RECOMMEND THAT YOU COMPRESS THE "compresses.js"FILE
echo.
echo WE USE "http://refresh-sf.com/yui/"
echo MAKE SURE YOU SELECT "JS" AS YOU FILE TYPE
echo ALL OTHER OPTION BOXES CAN BE LEFT UNTICKED
echo.
pause

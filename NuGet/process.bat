rmdir nuget\lib /s /q
mkdir nuget\lib
mkdir nuget\lib\35
mkdir nuget\lib\SL4
mkdir nuget\lib\SL3-wp

rmdir nuget\src /s /q
mkdir nuget\src

tools\CopyCode ..\BFsharp nuget\src
tools\CopyCode ..\BFsharp.Formula nuget\src

tools\CopyCode ..\BFsharp.SL nuget\src
tools\CopyCode ..\BFsharp.Formula.SL nuget\src
tools\CopyCode ..\Antlr3.Runtime.SL nuget\src

tools\CopyCode ..\BFsharp.WP7 nuget\src
tools\CopyCode ..\BFsharp.Formula.WP7 nuget\src
tools\CopyCode ..\Antlr3.Runtime.WP7 nuget\src

tools\CopyCode ..\BFsharp.AOP nuget\src
xcopy ..\BFsharp.AOP\obj\Debug\PostSharp\BFsharp.AOP.il nuget\src\BFsharp.AOP

tools\CopyCode ..\BFsharp.AOP.SL nuget\src
xcopy ..\BFsharp.AOP.SL\obj\Debug\PostSharp\BFsharp.AOP.SL.il nuget\src\BFsharp.AOP.SL

tools\CopyCode ..\BFsharp.AOP.WP7 nuget\src
xcopy ..\BFsharp.AOP.WP7\obj\Debug\PostSharp\BFsharp.AOP.WP7.il nuget\src\BFsharp.AOP.WP7


xcopy /Y /E "..\BFsharp.AOP\bin\Debug" nuget\lib\35
xcopy /Y /E "..\BFsharp.AOP.SL\bin\Debug" nuget\lib\SL4
xcopy /Y /E "..\BFsharp.AOP.WP7\bin\Debug" nuget\lib\SL3-wp

xcopy /Y /E "..\BFsharp\bin\Debug" nuget\lib\35
xcopy /Y /E "..\BFsharp.SL\bin\Debug" nuget\lib\SL4
xcopy /Y /E "..\BFsharp.WP7\bin\Debug" nuget\lib\SL3-wp

rmdir bin /s /q
mkdir bin

xcopy /Y /E nuget\lib bin

move bin/35 bin/net35
move bin/sl3-wp bin/wp7

del bin.zip
tools\7z.exe a out\bin.zip bin

del out\*.nupkg
xcopy /Y BFsharp.nuspec nuget
tools\NuGet.exe pack nuget\BFsharp.nuspec -symbols 
move BFsharp*.nupkg out

del out\BFsharp.Samples.SL.zip
tools\7z.exe a out\BFsharp.Samples.SL.zip "..\BFsharp.Samples.SL\bin\Debug\BusinessFramework.Samples.SLTestPage.html" "..\BFsharp.Samples.SL\bin\Debug\BFsharp.Samples.SL.xap"

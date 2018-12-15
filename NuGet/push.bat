set /p key= <key.txt

tools\nuget push -source http://packages.nuget.org/v1/ out\BFsharp.0.5.6.nupkg %key%
tools\nuget push -source http://nuget.gw.symbolsource.org/Public/NuGet out\BFsharp.0.5.6.symbols.nupkg %key%

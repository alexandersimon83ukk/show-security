# HelloWorld (einfaches C# "Hallo Welt" Beispiel)

Dieses kleine Beispiel zeigt ein minimales C# Konsolenprogramm.

Wie verwenden:
1. Stelle sicher, dass das .NET SDK installiert ist (z. B. .NET 7/8).
2. Im Verzeichnis mit `HelloWorld.csproj`:
   - `dotnet build`
   - `dotnet run`

Alternativ erzeugen mit CLI:
- `dotnet new console -n HelloWorld`
- `cd HelloWorld`
- `dotnet run`

Wenn dein SDK kein `net8.0` hat, passe `TargetFramework` in `HelloWorld.csproj` z.B. auf `net7.0` oder `net6.0` an.
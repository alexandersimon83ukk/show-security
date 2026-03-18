# Lessons Learned

- In einem C#-Repository sollte die primäre Validierung im Bericht klar als `dotnet test` benannt werden und nicht durch sprachfremde Hilfschecks ersetzt wirken.
- Wenn die Umgebung das SDK nicht enthält, sollte trotzdem der echte Zielbefehl genannt und die Umgebungsgrenze transparent gemacht werden.

# Lessons Learned

- In einem C#-Repository sollte die primäre Validierung im Bericht klar als `dotnet test` benannt werden und nicht durch sprachfremde Hilfschecks ersetzt wirken.
- Wenn die Umgebung das SDK nicht enthält, sollte trotzdem der echte Zielbefehl genannt und die Umgebungsgrenze transparent gemacht werden.

- Bei neuen oder geänderten GitHub-Actions-Workflows sollten Drittanbieter-Actions direkt auf Commit-SHAs gepinnt werden, damit CodeQL keine Unpinned-Tag-Warnungen meldet.

- Wenn der Nutzer eine Architekturpräferenz wie Service-/Controller-Struktur nachreicht, sollte die Web-Demo nicht bei Inline-Minimal-API-Handlern bleiben.

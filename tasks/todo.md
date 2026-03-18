# Task Plan

- [x] Prüfe Repository-Anweisungen, Nutzerfeedback und aktuellen Stand.
- [x] Ergänze ein separates Testprojekt.
- [x] Füge darin einen absichtlich fehlschlagenden Unit Test hinzu.
- [x] Führe verfügbare Checks aus und dokumentiere Einschränkungen.
- [x] Dokumentiere das Ergebnis im Review.

## Review

- `HelloWorld.Tests/HelloWorld.Tests.csproj` ist ein separates Testprojekt mit MSTest-Paketen und Referenz auf das Hauptprojekt.
- `HelloWorld.Tests/SecurityTopicPayloadTests.cs` enthält einen bewusst fehlschlagenden Test über `StringAssert.DoesNotContain(json, "CodeQL")`.
- `README.md` dokumentiert das zusätzliche Testprojekt und den absichtlich roten Testlauf.
- Beide Projektdateien wurden per XML-Parser erfolgreich geprüft.
- Die Testdatei wurde auf die erwarteten Testattribute und die absichtlich fehlerhafte Assertion geprüft.
- `git diff --check` lief erfolgreich.

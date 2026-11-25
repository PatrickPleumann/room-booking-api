# Room Booking API

Eine Web-API zum Buchen von Besprechungsräumen, gebaut mit ASP.NET Core, Entity Framework Core,
SQL Server und Docker.

Sie prüft Buchungen gegen Regeln: Überschneidungen werden erkannt, Kapazitäten eingehalten,
Stornierungen nur vor Beginn erlaubt. Für jeden Raum berechnet sie die freien Zeitfenster eines
Tages.

> **Status:** In Entwicklung. Aktuell: Domänenlogik (Buchungsregeln, Zeitfenster) per
> testgetriebener Entwicklung. Datenbank und API folgen.

## Technologien

- C# / .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (im Docker-Container)
- Docker
- xUnit

## Arbeitsweise & KI-Einsatz

Code und Tests schreibe ich selbst, testgetrieben (erst der fehlschlagende Test, dann die
Umsetzung). Begleitet werde ich von einem KI-Tutor (Claude): Er gibt als Architekt die
Anforderungen vor, erklärt Konzepte und reviewt meinen Code.

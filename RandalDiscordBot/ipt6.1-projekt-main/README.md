# Projektarbeit IPT6.1

### Randall, ein Discord Bot von Nicola Truscello und Russell Stansfield

![Alt text](./DiscordLogo.png "Discord")

## Inhaltsverzeichnis


1. [Projektidee](#projektidee)
2. [Projektbeschrieb](#projektbeschrieb)
3. [Architektur und Design](#architektur-und-design)
4. [Prototyping](#prototyping)
5. [Implementation](#implementation)
6. [Testing](#testing)
7. [Projektpräsentation](#projektpräsentation)
8. [Fazit](#fazit)

---


## Projektidee

Wir hatten bereits einen Discord Bot in einem vorherigen Modul programmiert. Discord ist ähnlich zu einem Chatroom, wobei User in einem Server sind miteinander im Server kommunizieren. Diese Chatrooms muss man entsprechend moderieren. Wir wollten ihn neu erstellen, komplett von grund auf, aber diesmal besser und mit erweiterten Funktionen. Diesmal merkt sich der Bot alle tätigkeiten und hält sie fest, steigert somit die Bestrafung richtig.

## Projektbeschrieb

Unser Projekt ist es, einen Discord Bot zu programmieren, der Discord-Benutzer warnt, wenn sie gebannte Wörter verwenden. Diese Wörter werden in einer JSON-Datei gespeichert. Zusätzlich kann man durch die Webapp Benutzer manuell bannen, kicken, stummschalten und warnen, indem man den gewählten Benutzer eingibt. Es ist auch möglich, nach Benutzern und ihren Logs zu suchen. Alle Daten und verstösse der User werden in einer DB festgehalten, somit kann sich der Bot an diese Tätigkeiten richten und enstsprechende Bestrafungen zufügen.

## Architektur und Design

Wir wollten das Programm in zwei Teile teilen, da wir aus Gründen der Blazor-Architektur den Frontend und Backend auf zwei Servern verteilen mussten. Diese Teile mussten durch API-Requests miteinander verlinkt werden. Dieses Problem war auch in unserem vorherigen Discordbot-Projekt vorhanden.

## Prototyping

### Randallbot Backend Prototyp

Russell hat einen einfachen Prototyp erstellt, bei dem der Bot nur automatisch reagieren konnte. Er konnte Benutzer mit einer Rolle stummschalten, die den Benutzern keine Rechte zum Sprechen gab. Wenn ein Benutzer ein gebanntes Wort sagte, wurde er stummgeschaltet. Dies wurde mit einem Discord-Konto namens "ScaryGonzalesGamer234" getestet, indem wir gebannte Wörter sagten. Dieses Konto wurde erfolgreich stummgeschaltet. Wenn ein Bot etwas sagte, wurde er einfach von Randall ignoriert. Wir haben dies mit einem bestehenden Bot namens Carl-Bot getestet, der nach unserem Befehl etwas sagte. Randall hat ihn einfach ignoriert.

### RandallbotDB Prototyp

Nicola hat eine einfache Version der heutigen Datenbank programmiert. Dies beinhaltete eine Datenbankverbindung und einfache CRUD-Operationen wie Lesen aller Tabelle und Inserts aller Tabelle, zusätzlich aller entsprechenden Klassen, ermöglicht mit Entity Framework.

## Implementation

Die Implementierung des Projekts war schwierig, obwohl wir bereits Prototypen hatten. Viele Probleme traten beim Discord Bot auf, da wir mit einer schwer zu erlernenden API arbeiteten. Im Frontend gab es nur lösbare Probleme mit Blazor. Bei der Verlinkung gab es die meisten Probleme, da wir dies mittels API-Requests lösen mussten. Da wir es schon letztes Mal gelöst hatten, hatten wir es unterschätzt und konnten das Projekt leider nicht fertigstellen. Zumindest gab es keine Probleme bei der Datenbank.

### Probleme bei der Backend:

- Probleme mit dem API-Token, da es manchmal änderte oder verschwand
- Probleme mit dem gleichzeitigen Stummschalten von mehreren Benutzern
- Probleme mit der Setzung von Rechten des Bots
- Probleme mit Bannen und Kicken wegen Rechte und API

## Testing

Leider konnten wir das gesamte Projekt nicht zum Laufen bringen, da Frontend, Backend und Datenbank nicht miteinander verlinkt werden konnten. Wir konnten aber die Programme einzeln testen. Bei der Datenbank waren es Unit-Tests und beim Backend waren es manuelle Tests mit bestehenden Discordbots und Discord-Konten, bei denen wir die automatischen Funktionen getestet haben.

## Projektpräsentation

Der Link zur Projektpräsentation befindet sich im Ordner "Dokumentation".

## Fazit

### Erfolge

- Verbesserte Funktionalität: Im Vergleich zu unserem vorherigen Discord-Bot haben wir deutlich erweiterte Funktionen implementiert, einschließlich automatischer und manueller Benutzerverwaltung durch Warnungen, Bans, Kicks und Stummschaltungen.
- Stabilen Datenbank: Dank Nicola hatten wir eine Datenbank, verschiedene CRUD operationen und eine Datenbankverbindung.

### Herausforderungen

- API-Komplexität: Die Arbeit mit der Discord-API stellte eine große Herausforderung dar, insbesondere beim Umgang mit API-Tokens und der Rechteverwaltung. Wir haben jedoch wertvolle Erfahrungen im Umgang mit API-basierten Anwendungen gesammelt.
- Gleichzeitige Benutzeraktionen: Das gleichzeitige Verwalten von Aktionen für mehrere Benutzer, wie das Stummschalten oder Bannen, war komplexer als erwartet. Dies erforderte zusätzliche Massnahmen zur Synchronisation und Fehlerbehandlung.
- Frontend-Probleme: Obwohl die meisten Probleme im Frontend lösbar waren, stellten sie dennoch einen erheblichen Arbeitsaufwand dar.
- API-Verlinkung zwischen den Projekten: Wir hatten schon bei dem letzten Discordbot Probleme mit der API-Verlinkung und dieses Mal tauchte es wieder auf. Wir hatten es unterschätzt und es hat viel mehr Aufwand gebraucht. Deswegen konnten wir das Projekt nicht fertigstellen.

### Ausblick

Für zukünftige Projekte haben wir folgende Ziele und Verbesserungsmöglichkeiten vorgeschlagen:

- Weniger Abhängigkeit von Blazor
- Besser planen und Ziele für jede Woche setzen
- Refreshers und andere Faktoren bei der Planung beachten

Abschliessend war Randall eine Herausforderung zu programmieren, vor allem im Backend, wo man mit der Discord.net API arbeiten musste und bei der Verlinkung der DB, Frontend und Backend mittels API-Requests. Aber bei der Datenbank lief es gut und im Frontend gab es wenige Probleme, die lösbar waren.

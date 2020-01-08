# Installation
Diese Anleitung dient als Unterstützung zur Inbetriebnahme des System und beschreibt in Schritten jede einzelene Aktion.  
## Daten
Die Basisdaten liegen im csv-Format vor und sind im Projekt 'TravelCount.Logic' im Verzeichnis 
'CsvData' verfügbar.
## Vorbereitungen
Für die Verwendung der Datenbank (als Persistierungsschicht) müssen einige Voraussetzungen gegeben 
sein und einige Vorbereitungsschritte durchgeführt werden. Beachten Sie dazu den entsprechenden 
Abschnitt in diesem Dokument.  
Für alle anderen Persistierungsarten, wie die Speicherung der Daten im csv-Format und die Speicherung 
der Daten mittels Serialisierung, müssen keine Vorbereitungsaktionen durchgeführt werden.
## Vorbereitung der Datenbank
Damit der Betrieb der Anwendung mit einer Datenbank funktioniert ist eine entsprechende Ausführungsumgebung 
erforderlich. Zur Herstellung diese Umgebung beachten Sie bitte die beiden nachfolgenden Abschnitte.
### System-Voraussetzungen
+ Es muss eine Datenbank-Instanz installiert und ausgeführt werden. Im Standardfall wird bei der 
Installation von Visual Studio eine 'LocalDb' mitinstalliert. Es wird davon ausgegangen, dass 
diese bereits installiert und asgeführt wird. 
+ Für den lokalen Rechner müssen die entsprechenden Rechte definiert sein. Diese werden ebenfalls 
mit der Standard-Installation von Visual Studio definiert.
+ Falls eine oder mehrere Voraussetzungen fehlen, müssen diese nachgeholt werden.

### Projekt-Voraussetzungen
Damit ein Betrieb mit einer Datenbank möglich ist, müssen einige NuGet-Packages den Projekten hinzugefügt werden. Im nachfolgenden sind die Packages für die einzelnen Projekte aufgeführt:

+ **TravelCount.Logic**
  + Microsoft.EntityFrameworkCore
  + Microsoft.EntityFrameworkCore.SqlServer
  + Microsoft.EntityFrameworkCore.Tools

+ **TravelCount.ConApp**
  + Microsoft.EnttyFrameworkCore.Design

### Erzeugen der Datenbank
+ **Schritt 1**  
Stellen Sie sicher, dass es kein Migrationsverzeichnis, im Projekt 'TravelCount.Logic', gibt. Wenn ja, bitte löschen Sie dieses vollständig.
+ **Schritt 2**  
Überprüfen Sie, ob die gesamte Projektmappe vollständig und ohne Fehler übersetzt werden kann. 
Wenn dies nicht der Fall ist, dann treffen Sie alle notwendigen Maßnahmen damit die Projektmappe 
ohne Fehler übersetzt werden kann.
+ **Schritt 3**  
Wenn Sie den Namen der Datenbank ändern wollen, dann können Sie den Namen in der Klasse 
'DbTravelCountContext' einstellen. Überprüfen Sie, dass nicht bereits eine Datenbank mit dem gleichem Namen existiert.
+ **Schritt 4**  
 Legen Sie im Visual Studio das Startprojekt 'TravelCount.ConApp' fest.
+ **Schritt 5**  
Öffnen Sie im Visual Studio die 'Package Management Console' und stellen Sie das 'Default project' auf 
'TravelCount.Logic' ein.
+ **Schritt 6**  
Geben Sie in der 'Package Management Console' den folgenden Befehl ein:  
Add-Migration InitDb  
Anschließend wird ein Ordner mit der Bezeichnung 'Migrations' und den ntsprechenden Dateien erstellt.  
+ **Schritt 7**  
Geben Sie in der 'Package Management Console' den folgenden Befehl ein:  
Update-Database  
Anschließend wird die Datenbank erstellt und Sie können diese mit der Ansicht 
'SQL Server Object Explorer' überprüfen.

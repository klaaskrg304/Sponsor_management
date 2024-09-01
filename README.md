# Sponsor_management


Kurzbeschreibung der Anwendung „sponsor-management“.

Die von mir erstellte Anwendung dient der Verwaltung von Sponsoren, Teilnehmern sowie anderer Vorgänge wie Mail- und Briefversandt für die Organisation des Landes Rapsblütenfest Mecklenburg-Vorpommern.

Die Anwendung ist im Grafik-Framework WPF erstellt und in C# geschrieben.


Fenster: 

Main_Window	dient der allgemeinen Navigation in spezifische Fenster.

Login_Window	Login Funktion.  Verschlüsselung des Passworts mit Hilfe eines Hash-Algorithmus.
Window_sponsors	Verwaltung von Sponsoren und näheren Informationen in einem DataGrid. 

Window_Umzug	Verwaltung von Teilnehmern des Festumzugs in einem DataGrid.
Window_Mail	Empfangen und senden von E-Mails




Klassen:

DBConnection	Verbindung zur lokalen PostgreSQL-DB (Cloud ist möglich und wird demnächst umgesetzt).
Hash	Hash-Algorithmus + Salt zur Verschlüsselung des Loginpassworts.
Sponsors	bietet Funktionen zur Verwaltung von Sponsoren
Participants	bietet Funktionen zur Verwaltung von Teilnehmern
PrintHelper (externe Klasse von Microsoft)	Druckfunktionen.




Diese Kurzbeschreibung soll die grobe Aufteilung des Programms zeigen. Eine detaillierte Beschreibung gebe ich Ihnen gern persönlich.

Mit freundlichen Grüßen
Klaas Krüger

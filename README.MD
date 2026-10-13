Inventory System med generisk implementasjon

Om prosjektet

Dette prosjektet er et generisk inventarsystem utviklet i C#. Programmet lar brukeren administrere forskjellige typer objekter gjennom et terminalbasert brukergrensesnitt laget med Terminal.Gui.

Prosjektet fokuserer på objektorientert programmering, generics, interfaces, samlinger og gjenbruk av kode.

Funksjoner

Vise alle objekter eller objekter fra et bestemt inventar.

Legge til nye objekter.

Fjerne eksisterende objekter.

Søke etter objekter ved hjelp av navn.

Sortere objekter alfabetisk.

Generere en unik ID for hvert nyopprettet objekt.

Prosjektstruktur

InventoryItems.cs

Definerer grensesnittet IInventoryItem, ID-generatoren GetNewId og objekttypene Guitar, Camera og Skateboard.

Alle objekttypene implementerer IInventoryItem, som sørger for at de har et navn og en ID.

Inventory.cs

Inneholder den generiske klassen Inventory<T>, som håndterer en samling inventarobjekter.

Klassen støtter blant annet å legge til, fjerne, søke etter og sortere objekter. Ved hjelp av generics kan den samme klassen brukes for forskjellige objekttyper.

Program.cs

Inneholder programmets inngangspunkt, Main(). Her opprettes inventarene, startdataene initialiseres, og brukergrensesnittet startes.

BrukerGrensesnitt.cs

Inneholder det terminalbaserte brukergrensesnittet. Klassen bruker Terminal.Gui til å vise knapper, søkefelt og skjemaer som lar brukeren benytte funksjonene i inventarsystemet.

Teknologier

C#

.NET

Terminal.Gui

Oppbygning

Programmet er delt inn i et datalag og et brukergrensesnitt.

InventoryItems.cs definerer objektene som kan lagres, mens Inventory.cs håndterer samlingene av disse objektene. Program.cs initialiserer programmet, og BrukerGrensesnitt.cs gjør funksjonaliteten tilgjengelig for brukeren.

Denne strukturen gjør det mulig å gjenbruke inventarklassen for flere objekttyper uten å måtte implementere de samme funksjonene på nytt for hver type.


Oppstart

Åpne prosjektet i et miljø som støtter .NET, gjenopprett NuGet-pakkene og start programmet med:

dotnet restore
dotnet run


Bruk av KI.

Det har vært noe bruk av KI under prosjektet.
For det meste vært brukt til feilsøking, finne skrivefeil og hjelpe med dokumentasjon
Har også vært brukt i starten for og hjelpe meg og bli kjent med generiske typer og hvordan de brukes for å lage enklere og mer allsidig kode
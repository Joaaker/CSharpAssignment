Detta repository innehåller första verisonen av inlämningsuppgiften för kursen C#. Ursprungligen utvecklades applikationen med .NET MAUI men jag bytte till WPF. Här är den färdiga inlämningsuppgiften med WPF: https://github.com/Joaaker/CSharpAssignmentWithWPF




Introduktion
I denna inlämningsuppgift ska du bygga en applikation med hjälp av C#. Applikationen ska uppfylla de kriterier som specificeras här nedan. För godkänt räcker det med att applikationen är en konsolapplikation, medan för väl godkänt krävs även att du skapar en till applikation som använder sig av ett GUI (Graphical User Interface) såsom MAUI, MAUI Blazor eller WPF.



Om du använder dig av kodstycken som är genererade av AI, såsom Chat GPT, måste detta framgå för att det inte ska räknas som plagiat. Du ska då även kommentera koden och förklara vad den gör. Detta görs genom att använda vanliga kommentarer eller, för längre stycken, med en sammanfattande summary-kommentar.



Exempel på en kommentar

/* Detta är genererat av Chat GPT 4o - Denna kod gör.... */



Instruktioner på vad som ska göras
Applikationen du ska skapa ska vara en kontaktlista där det ska vara möjligt att lägga till och se kontakter. En kontakt ska ha följande information: förnamn, efternamn, e-postadress, telefonnummer, gatuadress, postnummer och ort. Varje kontakt ska även få ett autogenererat id i form av en GUID.



För godkänt krävs följande:

En applikation som är byggd som en konsolapplikation med följande:

Ett menyalternativ som listar alla kontakter.
Ett menyalternativ som skapar en kontakt.
Möjlighet att spara kontakter till en .json-fil.
Möjlighet att läsa in kontakter från en .json-fil när applikationen startar och när listan uppdateras.
Tillämpning av S i SOLID.
Enhetstester (utan mock) på de metoder som kan testas utan att använda mock.


För väl godkänt krävs följande:

Att du gör en konsolapplikation (se G-kraven).

Att du gör en till applikation, som använder sig av ett GUI, med följande:

En sida som listar alla kontakter.
En sida där man kan skapa en kontakt.
En sida där man kan redigera en kontakt med möjlighet att uppdatera och ta bort kontakten.
Möjlighet att spara kontakter till en .json-fil.
Möjlighet att läsa in kontakter från en .json-fil när applikationen startar och när listan uppdateras.
Användning av Dependency Injection.
Användning av Klassbibliotek (Class Library).
Tillämpning av flera olika Design Patterns: SOLID, Service Pattern och Factory Pattern.
Enhetstester (med mock där det behövs) för alla metoder som används.

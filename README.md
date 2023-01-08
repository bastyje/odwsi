# Projekt z Ochrony danych w systemach informatycznych

## Uruchomienie aplikacji

1. Przed uruchomieniem należy dodać dwie domeny do pliku `/etc/hosts'
```
10.0.0.2 odwsi.notepad.pl
10.0.0.3 api.odwsi.notepad.pl
```
2. W celu uruchomienia należy w korzeniu projektu uruchomić komendę:
```
docker compose up
```
3. Już prawie można korzystać z aplikacji! Dostępna jest ona pod adresem `odwsi.notepad.pl`. Jednak zanim uda się z niej skorzystać należy ręcznie zaufać certyfikatowi SSL, ponieważ jest on samopodpisany i nie ma autoryzowanego issuera. Aby to zrobić należy w przeglądarce wejść pod dwa adresy: `odwsi.notepad.pl` oraz `api.odwsi.notepad.pl` i każdemu z tych adresów zaufać.
![Screenshot from 2023-01-08 19-17-04](https://user-images.githubusercontent.com/72526338/211212465-869ba40f-a0fb-4888-adc6-bcb621973a53.png)

## Do poczytania

**XSS**: [https://angular.io/guide/security](https://angular.io/guide/security)

**SQL Injection**: [https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/security-considerations#security-considerations-for-queries](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/security-considerations#security-considerations-for-queries)



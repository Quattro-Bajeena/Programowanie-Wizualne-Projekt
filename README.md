# Programowanie Wizualne - Projekt

Autorzy: **Mateusz Oleszek**

### DAO

- OleszekMowinski.ProjectApp.DAOMock.dll
- OleszekMowinski.ProjectApp.DAOFile.dll
- OleszekMowinski.ProjectApp.DAOSQL.dll

## Przed uruchomieniem

### MAUI

Z uwagi na to, jak aplikacja MAUI wczytywała domyślnie pliki DLL trzeba jej podać bezwzględną ścieżkę do pliku zawierającego implementację DAO w pliku konfiguracyjnym `appsettings.json`. 

Dodatkowo musi być to folder z którego startuje aplikacja, żeby dynamiczne zależności pliku DLL poprawnie zostały załadowane.

np. w moim środowisku lokalnym ta ścieżka wyglądała tak

`"DAOLibraryName": "E:\\Programowanie\\Studia\\Wizualne\\ProjectApp\\OleszekMowinski.ProjectApp.MAUI\\bin\\Debug\\net8.0-windows10.0.19041.0\\win10-x64\\AppX\\OleszekMowinski.ProjectApp.DAOSQL.dll"`

### MVC

Tutaj nie powinno być potrzeby zmieniania czegokolwiek w ustawieniach, oprócz nazwy DLL w celu zmienienia wykorzystywanego DAO.


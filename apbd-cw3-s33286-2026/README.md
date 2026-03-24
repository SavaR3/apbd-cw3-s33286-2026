# Wypożyczalnia Sprzętu — APBD CW3

Konsolowa aplikacja w C# do zarządzania wypożyczalnią sprzętu na uczelni.

## Uruchomienie
`dotnet run`

## Struktura
Model (klasy domenowe) → Service (logika biznesowa) → Program (demo)

## Dlaczego taki podział

Podzieliłem kod na Model i Service — klasy domenowe
nie wiedzą nic o logice biznesowej.

`RentalService` zajmuje się tylko wypożyczeniami,
`DailyFineRate` w jednym miejscu — łatwo zmienić stawkę,
`Data` to jeden wspólny magazyn dla wszystkich serwisów.

`User` i `Equipment` są abstrakcyjne bo typy naprawdę się różnią.

## Reguły
- Student: max 2 wypożyczenia, Pracownik: max 5
- Kara: 5 zł/dzień
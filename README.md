# CrossApp
Наскрізний проєкт з крос-платформного програмування.

Предметна область: Склад. 
Сутності: Product (товар), StockBatch (партія), Warehouse (склад), Movement (переміщення).
Призначення: облік залишків товарів по партіях.

## Запуск
dotnet build
dotnet run --project src/Cli

### Запуск у форматі JSON (додаткове завдання)
dotnet run --project src/Cli -- --json

## Середовище
.NET SDK 10.0
Windows 11 x64

## Додаткове завдання (Порівняння розмірів self-contained publish)
* **win-x64**: 153 МБ
* **linux-x64**: 157 МБ
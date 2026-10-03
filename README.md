# CrossApp
Наскрізний проєкт з крос-платформного програмування.

Предметна область: Склад. 
Сутності: Product (товар), StockBatch (партія), Warehouse (склад), Movement (переміщення).
Призначення: облік залишків товарів по партіях.

## Структура рішення (Solution)
CrossApp/
├── CrossApp.sln
├── README.md
├── .gitignore
└── src/
    ├── Core/                 (Бібліотека класів із спільною логікою)
    │   ├── Core.csproj
    │   ├── EnvironmentInfo.cs
    │   ├── Dto/              (record-типи формату даних - тиждень 3)
    │   ├── Domain/           (сутності з поведінкою та інваріантами - тиждень 4)
    │   └── Storage/          (реалізації сховищ - тиждень 5)
    └── Cli/                  (Консольний клієнт)
        ├── Cli.csproj
        └── Program.cs

*Примітка: каталоги Dto, Domain та Storage містять файли `.gitkeep`, оскільки порожні каталоги Git не зберігає.*

## Запуск та збірка
* **Збірка:** `dotnet build`
* **Запуск (таблицею):** `dotnet run --project src/Cli`
* **Запуск у форматі JSON (додаткове завдання):** `dotnet run --project src/Cli -- --json`

## Публікація та порівняння режимів
| RID | Режим | Розмір publish | Потрібен встановлений runtime |
| :--- | :--- | :--- | :--- |
| win-x64 | framework-dependent | ~0.2 МБ | так (.NET 10) |
| win-x64 | self-contained | ~76.9 МБ | ні |

*Команди для публікації:*
* `dotnet publish src/Cli -c Release -r win-x64 --self-contained false`
* `dotnet publish src/Cli -c Release -r win-x64 --self-contained true`

*Порівняння розмірів self-contained publish:*
* **win-x64**: 153 МБ
* **linux-x64**: 157 МБ

## Середовище
* .NET SDK 10.0
* Windows 11 x64
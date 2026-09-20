using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Encodings.Web;

// Створюємо анонімний об'єкт із потрібними даними
var envInfo = new
{
    Student = "Івасів Святозар, ФЕІ-37",
    OsDescription = RuntimeInformation.OSDescription,
    ProcessArchitecture = RuntimeInformation.ProcessArchitecture.ToString(),
    DotNetVersion = Environment.Version.ToString(),
    Runtime = RuntimeInformation.FrameworkDescription,
    AppDirectory = AppContext.BaseDirectory,
    CurrentDirectory = Environment.CurrentDirectory,
    Domain = "Склад (товари, партії, залишки, переміщення)"
};

// Налаштування енкодера для коректного відображення кирилиці без екранування
var options = new JsonSerializerOptions 
{ 
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
};

// Перевіряємо, чи передано аргумент --json
if (args.Contains("--json"))
{
    // Встановлюємо кодування консолі UTF-8 для правильного виводу кирилиці
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    // Серіалізація в один JSON-рядок (System.Text.Json) з новими опціями[cite: 1]
    string jsonString = JsonSerializer.Serialize(envInfo, options);
    Console.WriteLine(jsonString);
}
else
{
    // Вивід у вигляді таблиці
    Console.WriteLine("CrossApp – практикум з крос-платформного програмування");
    Console.WriteLine("Студент: Івасів Святозар, ФЕІ-37");
    Console.WriteLine(new string('-', 52));
    Console.WriteLine($"ОС (OSDescription)   : {envInfo.OsDescription}");
    Console.WriteLine($"Архітектура процесу  : {envInfo.ProcessArchitecture}");
    Console.WriteLine($"Версія .NET (CLR)    : {envInfo.DotNetVersion}");
    Console.WriteLine($"Runtime              : {envInfo.Runtime}");
    Console.WriteLine($"Каталог застосунку   : {envInfo.AppDirectory}");
    Console.WriteLine($"Поточний каталог     : {envInfo.CurrentDirectory}");
    Console.WriteLine(new string('-', 52));
    Console.WriteLine($"Предметна область: {envInfo.Domain}");
}
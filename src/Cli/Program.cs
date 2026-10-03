using System;
using System.Linq;
using System.Text.Json;
using System.Text.Encodings.Web;
using Core; // Підключаємо створену бібліотеку класів

// 1. Отримуємо дані з бібліотеки Core (жодної логіки збору даних у Cli бути не повинно)
EnvironmentReport report = EnvironmentInfo.Collect();

// 2. Перевіряємо, чи передано аргумент --json
if (args.Contains("--json"))
{
    // Створюємо анонімний об'єкт для JSON, комбінуючи дані з Core та інформацію про студента/домен
    var jsonInfo = new
    {
        Student = "Івасів Святозар, ФЕІ-37",
        OsDescription = report.OsDescription,
        ProcessArchitecture = report.ProcessArchitecture,
        DetectedRid = report.DetectedRid,
        ReportedRid = report.ReportedRid,
        Runtime = report.FrameworkDescription,
        AppDirectory = report.BaseDirectory,
        Domain = "Склад (товари, партії, залишки, переміщення)"
    };

    var options = new JsonSerializerOptions 
    { 
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
    };

    // Встановлюємо кодування консолі UTF-8 для правильного виводу кирилиці
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    
    // Серіалізація в один JSON-рядок
    string jsonString = JsonSerializer.Serialize(jsonInfo, options);
    Console.WriteLine(jsonString);
}
else
{
    // 3. Вивід у вигляді таблиці
    Console.WriteLine("CrossApp – інформація про середовище");
    Console.WriteLine("Студент: Івасів Святозар, ФЕІ-37");
    Console.WriteLine(new string('-', 52));
    Console.WriteLine($"ОС            : {report.OsDescription}");
    Console.WriteLine($"Runtime       : {report.FrameworkDescription}");
    Console.WriteLine($"Архітектура   : {report.ProcessArchitecture}");
    Console.WriteLine($"RID (визначено): {report.DetectedRid}");
    Console.WriteLine($"RID (від .NET) : {report.ReportedRid}");
    Console.WriteLine($"Каталог        : {report.BaseDirectory}");
    Console.WriteLine(new string('-', 52));
    Console.WriteLine("Предметна область: Склад (товари, партії, залишки, переміщення)");
}
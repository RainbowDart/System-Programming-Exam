using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;
using SystemUtilitySuite;

namespace Variant24;

internal static class Program
{
    private static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Зачётный проект 24: Набор системных утилит");
        Console.WriteLine(new string('=', 64));

        // Стартовый сценарий нужен для проверки структуры проекта.
        // Реализацию индивидуальных требований выполняйте в ProjectService.
        var service = new ProjectService();
        await service.RunAsync();

        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для завершения.");
        Console.ReadLine();
    }
}

public sealed class ProjectService
{
    private readonly MathService _mathService = new();
    private readonly ParallelService _parallelService = new();
    private readonly ProcessService _processService = new();
    private readonly CounterService _counterService = new();
    private readonly FileService _fileService = new();
    private readonly ChannelService _channelService = new();
    public async Task RunAsync()
    {
        Console.WriteLine("TODO 1 Исправление legacy-кода");
        // var legacy = new LegacyCalculator();
        // Console.WriteLine(legacy.Divide(10, 0)); // эжто вызвало бы краш

        Console.WriteLine($"Исправленный сервис: 10 / 0 = {_mathService.SafeDivide(10, 0)}");
        Console.WriteLine($"Исправленный сервис: 10 / 2 = {_mathService.SafeDivide(10, 2)}");

        Console.WriteLine("\nTODO 2: Запуск внешней утилиты");
        _processService.RunCommand("ipconfig", "");

        Console.WriteLine("\nTODO 3: Асинхронная файловая операция" +
            "");
        await _fileService.WriteAndReadAsync("test_async.txt", "Привет");


        Console.WriteLine("\nTODO 4: Безопасный счётчик");
        Parallel.For(0, 10000, i =>
        {
            _counterService.IncrementSafe();
        });
        Console.WriteLine($"Результат безопасного счётчика: {_counterService.GetCount()}");

        Console.WriteLine("\nTODO 5: Сравнение LINQ и PLINQ ---");
        _parallelService.CompareProcessing();

        Console.WriteLine("\nTODO 6: IDisposable обёртка");
        using (var wrapper = new FileStreamWrapper("dispose_test.bin"))
        {
            wrapper.WriteByte(42);
            Console.WriteLine("Записали байт в файл через обёртку.");
        }
        Console.WriteLine("Обёртка удалена.");

        Console.WriteLine("\nTODO 10: Channel Pipeline");
        await _channelService.RunPipelineAsync();

        await Task.CompletedTask;
    }
}

//public sealed class ProjectService
//{
//    public async Task RunAsync()
//    {
//        // TODO: перенесите предметную логику в отдельные методы и классы.
//        // TODO: не размещайте весь проект в Main.
//        // TODO 1: Разделить приложение на сервисы и найти/исправить дефект стартового legacy-кода.
//        // TODO 2: Запустить внешнюю утилиту через Process и прочитать результат.
//        // TODO 3: Выполнить асинхронную файловую операцию.
//        // TODO 4: Реализовать безопасный общий счётчик при параллельных задачах.
//        // TODO 5: Обработать коллекцию параллельно и сравнить результат с LINQ.
//        // TODO 6: Создать IDisposable-обёртку над FileStream.
//        // TODO 7: Сохранить пользовательскую настройку в HKCU.
//        // TODO 8: Вынести сервис в Class Library и подключить через ProjectReference.
//        // TODO 9: Получить PID через P/Invoke.
//        // TODO 10: Добавить ограниченный Channel pipeline.
//        // TODO 11: Добавить WinForms KeyDown или демонстрацию безопасного hook.
//        // TODO 12: Добавить тесты и документировать платформенные ограничения.

//        Console.WriteLine("Стартовый проект собран. Реализуйте задания варианта.");
//        await Task.CompletedTask;
//    }
//}

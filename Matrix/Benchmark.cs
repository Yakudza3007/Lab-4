using System.Globalization;

namespace MatrixLab;

internal static class Benchmark
{
    private static readonly int[] Sizes = { 500, 1000, 2000 };

    private const int MaxThreads = 40;
    private const int Measurements = 5;

    public static void Run()
    {
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        string rawFile = Path.Combine(
            Environment.CurrentDirectory,
            $"benchmark_raw_{timestamp}.csv");

        string summaryFile = Path.Combine(
            Environment.CurrentDirectory,
            $"benchmark_summary_{timestamp}.csv");

        Console.WriteLine("\n=== Автоматические замеры ===");
        Console.WriteLine("Прогрев JIT...");

        Matrix warmupA = MatrixGenerator.Generate(100, 100);
        Matrix warmupB = MatrixGenerator.Generate(100, 100);

        MatrixMultiplier.Multiply(
            warmupA,
            warmupB,
            1,
            printTime: false);

        using StreamWriter rawWriter = new StreamWriter(rawFile);
        using StreamWriter summaryWriter = new StreamWriter(summaryFile);

        rawWriter.WriteLine("Size,Threads,Run,TimeMs,Checksum");

        summaryWriter.WriteLine(
            "Size,Threads,MinMs,MaxMs,AverageTrimmedMs");

        foreach (int size in Sizes)
        {
            Console.WriteLine($"\nГенерация матриц {size} x {size}...");

            Matrix a = MatrixGenerator.Generate(size, size);
            Matrix b = MatrixGenerator.Generate(size, size);

            long? expectedChecksum = null;

            for (int threads = 1; threads <= MaxThreads; threads++)
            {
                double[] times = new double[Measurements];

                Console.WriteLine(
                    $"\nРазмер: {size} x {size}, потоков: {threads}");

                for (int run = 0; run < Measurements; run++)
                {
                    double elapsed = 0;

                    Matrix result = MatrixMultiplier.Multiply(
                        a,
                        b,
                        threads,
                        timingCallback: time => elapsed = time,
                        printTime: false);

                    long checksum = result.Checksum();

                    if (expectedChecksum == null)
                    {
                        expectedChecksum = checksum;
                    }
                    else if (checksum != expectedChecksum.Value)
                    {
                        throw new InvalidOperationException(
                            "Контрольные суммы результатов не совпадают.");
                    }

                    times[run] = elapsed;

                    rawWriter.WriteLine(
                        $"{size},{threads},{run + 1}," +
                        $"{elapsed.ToString("F2", CultureInfo.InvariantCulture)}," +
                        $"{checksum}");

                    rawWriter.Flush();

                    Console.WriteLine(
                        $"Замер {run + 1}/{Measurements}: {elapsed:F2} мс");
                }

                double[] sortedTimes = (double[])times.Clone();
                Array.Sort(sortedTimes);

                double average =
                    (sortedTimes[1] + sortedTimes[2] + sortedTimes[3]) / 3.0;

                summaryWriter.WriteLine(
                    $"{size},{threads}," +
                    $"{sortedTimes[0].ToString("F2", CultureInfo.InvariantCulture)}," +
                    $"{sortedTimes[4].ToString("F2", CultureInfo.InvariantCulture)}," +
                    $"{average.ToString("F2", CultureInfo.InvariantCulture)}");

                summaryWriter.Flush();

                Console.WriteLine(
                    $"Среднее после исключения min/max: {average:F2} мс");
            }
        }

        Console.WriteLine("\n=== Замеры завершены ===");
        Console.WriteLine($"Все результаты: {rawFile}");
        Console.WriteLine($"Средние результаты: {summaryFile}");
    }
}
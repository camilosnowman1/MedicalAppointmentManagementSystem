using System;
using System.Globalization;

namespace MedicalAppointmentApp.Utils
{
    // Safe console readers to avoid crashes by invalid input
    public static class ConsoleInput
    {
        public static void Pause(string msg = "Press any key to continue...")
        {
            Console.WriteLine();
            Console.WriteLine(msg);
            Console.ReadKey();
        }

        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine("Input cannot be empty. Try again.");
            }
        }

        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, out var n) && n >= min && n <= max) return n;
                Console.WriteLine($"Invalid integer. Range: [{min}, {max}]. Try again.");
            }
        }

        public static DateTime ReadDateTime(string prompt, string format = "yyyy-MM-dd HH:mm")
        {
            while (true)
            {
                Console.Write($"{prompt} (format {format}): ");
                var s = Console.ReadLine();
                if (DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var dt)) return dt;
                Console.WriteLine("Invalid date/time format. Try again.");
            }
        }

        public static Guid ReadGuid(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (Guid.TryParse(s, out var id)) return id;
                Console.WriteLine("Invalid GUID format. Example: 3f2504e0-4f89-11d3-9a0c-0305e82c3301");
            }
        }
    }
}

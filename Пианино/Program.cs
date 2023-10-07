using System;
using System.Collections.Generic;
using System.Threading;

class Piano
{
    static Dictionary<ConsoleKey, int[]> octaves = new Dictionary<ConsoleKey, int[]>
    {
        { ConsoleKey.F1, new int[] {261, 293, 329, 349, 392, 440, 493, 277, 311, 349, 415, 466} },
        { ConsoleKey.F2, new int[] {523, 587, 659, 698, 784, 880, 987, 554, 622, 698, 830, 932} },
        { ConsoleKey.F3, new int[] {1046, 1175, 1318, 1397, 1568, 1760, 1975, 1109, 1245, 1397, 1661, 1865} },
    };

    static int[] currentOctaveNotes = octaves[ConsoleKey.F1];

    static void Main(string[] args)
    {
        Console.WriteLine("Пианино");
        Console.WriteLine("Используйте клавиши F1, F2, F3 для переключения октав.");
        Console.WriteLine("Используйте клавиши A, S, D, F, G, H, J для воспроизведения белых клавиш пианино.");
        Console.WriteLine("Используйте клавиши W, E, R, T, Y для воспроизведения чёрных клавиш пианино.");
        Console.WriteLine("Нажмите Esc для выхода.");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }

                if (octaves.ContainsKey(key))
                {
                    currentOctaveNotes = ChangeOctave(key);
                }
                else
                {
                    PlayNote(key);
                }
            }
        }
    }

    static int[] ChangeOctave(ConsoleKey key)
    {
        Console.WriteLine($"Переключено на октаву {key}");
        return octaves[key];
    }

    static void PlayNote(ConsoleKey key)
    {
        int noteIndex = -1;

        switch (key)
        {
            case ConsoleKey.A: noteIndex = 0; break;
            case ConsoleKey.S: noteIndex = 1; break;
            case ConsoleKey.D: noteIndex = 2; break;
            case ConsoleKey.F: noteIndex = 3; break;
            case ConsoleKey.G: noteIndex = 4; break;
            case ConsoleKey.H: noteIndex = 5; break;
            case ConsoleKey.J: noteIndex = 6; break;
            case ConsoleKey.W: noteIndex = 7; break;
            case ConsoleKey.E: noteIndex = 8; break;
            case ConsoleKey.R: noteIndex = 9; break;
            case ConsoleKey.T: noteIndex = 10; break;
            case ConsoleKey.Y: noteIndex = 11; break;
        }

        if (noteIndex != -1)
        {
            int frequency = currentOctaveNotes[noteIndex];
            Console.Beep(frequency, 500);
        }
    }
}

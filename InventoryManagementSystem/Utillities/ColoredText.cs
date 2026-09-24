using System;
using System.Collections.Generic;
using System.Text;

namespace  InventoryManagementSystem.Utilities
{
    public static class ColoredText
    {
        // / <summary>
        // / Writes a message to the console in the specified color.
        // / </summary>
        // / <param name="message">The message to write.</param>
        // / <param name="color">The color to use.</param>
        public static void WriteLine(string message, ConsoleColor color)
        {
            var prev = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
            }
            finally
            {
                Console.ForegroundColor = prev;
            }
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        // Writes without appending a newline, preserving and restoring the console color.
        public static void Write(string message, ConsoleColor color)
        {
            var prev = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.Write(message);
            }
            finally
            {
                Console.ForegroundColor = prev;
            }
        }

        // Writes without color (no newline)
        public static void Write(string message)
        {
            Console.Write(message);
        }
    }
}

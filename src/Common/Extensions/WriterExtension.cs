﻿namespace Common.Extensions
{
    public static class WriterExtension
    {
        [System.Diagnostics.DebuggerStepThrough] public static void WriteHost() => string.Empty.WriteHost();
        [System.Diagnostics.DebuggerStepThrough]
        public static void WriteHost(this object obj, object header = null, bool newLine = true, bool newLineAfterHeader = false)
        {
            if (!string.IsNullOrWhiteSpace(header?.ToString())) { WriteOutput(header.ToString() + ": ", newLineAfterHeader); }
            WriteOutput(obj, newLine);
        }
        [System.Diagnostics.DebuggerStepThrough]
        private static void WriteOutput(this object obj, bool newline = true)
        {
            System.Console.Write(obj.ToString());
            System.Diagnostics.Debug.Write(obj.ToString());
            if (newline)
            {
                System.Console.WriteLine(string.Empty);
                System.Diagnostics.Debug.WriteLine(string.Empty);
            }
        }
    }
}
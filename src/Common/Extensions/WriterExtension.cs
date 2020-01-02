namespace Common.Extensions
{
    public static class WriterExtension
    {
        [System.Diagnostics.DebuggerStepThrough]
        public static void WriteHost(this object obj, string header = "")
        {
            WriteOutput(header);
            WriteOutput(obj);
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static void WriteOutput(this object obj)
        {
            System.Console.WriteLine(obj.ToString());
            System.Diagnostics.Debug.WriteLine(obj.ToString());
        }
    }
}
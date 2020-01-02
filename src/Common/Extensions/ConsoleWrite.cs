namespace Common.Extensions
{
    public static class WriterExtension
    {
        public static void WriteHost(this object tree, string header = "")
        {
            WriteOutput(header);
            WriteOutput(tree);
        }
        private static void WriteOutput(this object Value)
        {
            System.Console.WriteLine(Value.ToString());
            System.Diagnostics.Debug.WriteLine(Value.ToString());
        }
    }
}
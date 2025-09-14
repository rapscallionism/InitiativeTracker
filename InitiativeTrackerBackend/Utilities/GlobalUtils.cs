namespace InitiativeTrackerBackend.Utilities
{
    public static class GlobalUtils
    {
        public static string Sanitize(string input)
        {
            return input.Replace("\n", "").Replace("\t", "").Replace("\r", "");
        }
    }
}

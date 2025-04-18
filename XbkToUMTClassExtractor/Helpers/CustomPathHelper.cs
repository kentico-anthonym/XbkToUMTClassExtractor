namespace XbkToUMTClassExtractor.Helpers;

public static class CustomPathHelper
{
    public static string ProjectPath => AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")).TrimEnd('\\');
}

using Plugin.Logger.Abstractions;
using System;

namespace Plugin.Logger
{
  /// <summary>
  /// Cross platform Logger implemenations
  /// </summary>
  public class CrossLogger
  {
    static Lazy<ILogger> Implementation = new Lazy<ILogger>(() => CreateLogger(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static ILogger Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static ILogger CreateLogger()
    {
#if PORTABLE
        return null;
#else
        return new LoggerImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}

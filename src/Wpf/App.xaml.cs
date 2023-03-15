using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Locator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf
{
    class Program
    {
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();

            Build();
        }

        private static void Build()
        {
            var p = new BuildParameters
            {
                MaxNodeCount = 4,
                Loggers = new ILogger[] { new Microsoft.Build.Logging.ConsoleLogger(LoggerVerbosity.Normal) },
            };

            var req = new BuildRequestData("ProjectToBeBuilt.proj",
                new Dictionary<string, string>(),
                null,
                new[] { "Build" },
                null,
                BuildRequestDataFlags.None);

            var result = BuildManager.DefaultBuildManager.Build(p, req);
        }
    }
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}

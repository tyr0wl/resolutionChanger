using System.IO;
using System.Linq;
using ResolutionChanger.Win32;

namespace ResolutionChanger.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var setup = args.FirstOrDefault();

            if (string.IsNullOrEmpty(setup))
            {
                throw new InvalidDataException("missing profile name to load");
            }
            
            var configuration = ScreenConfigurationService.Get(setup);
            if (configuration == null)
            {
                var current = ScreenConfigurationService.GetCurrent(setup);
                ScreenConfigurationService.SaveOrUpdate(current);
                return;
            }
            
            if (Win32ApiWrapper.TestConfig(configuration.Paths, configuration.Modes) == Win32Status.ErrorSuccess)
            {
                Win32ApiWrapper.SetConfig(configuration.Paths, configuration.Modes);
            }
        }
    }
}
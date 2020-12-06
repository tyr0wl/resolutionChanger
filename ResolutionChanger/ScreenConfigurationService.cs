using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ResolutionChanger.Data;

namespace ResolutionChanger
{
    public class ScreenConfigurationService
    {
        /// <summary>
        ///     Reads the screen configuration stored under the provided <paramref name="name" />.
        ///     Note that
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ScreenConfiguration Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("cannot be null or empty", nameof(name));
            }

            var filePath = $"profiles/{name}.json";
            if (!File.Exists(filePath))
            {
                return null;
            }

            var serializedScreenConfiguration = File.ReadAllText($"profiles/{name}.json");

            return JsonConvert.DeserializeObject<ScreenConfiguration>(serializedScreenConfiguration, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }

        /// <summary>
        ///     Stores the given screen configuration in the profiles folder of the application's execution path.
        /// </summary>
        /// <param name="screenConfiguration">screen configuration to save</param>
        /// <exception cref="ArgumentException">
        ///     Thrown when <see cref="ScreenConfiguration.Name" /> of
        ///     <paramref name="screenConfiguration" /> is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="screenConfiguration" /> is null.</exception>
        public static void SaveOrUpdate(ScreenConfiguration screenConfiguration)
        {
            if (screenConfiguration == null)
            {
                throw new ArgumentNullException(nameof(screenConfiguration));
            }

            if (string.IsNullOrEmpty(screenConfiguration.Name))
            {
                throw new ArgumentException($"{nameof(screenConfiguration.Name)} property of the parameter {screenConfiguration} cannot be null or empty", nameof(screenConfiguration));
            }

            if (!Directory.Exists("profiles"))
            {
                Directory.CreateDirectory("profiles");
            }

            var serializedScreenConfiguration = JsonConvert.SerializeObject(screenConfiguration, Formatting.Indented, new JsonSerializerSettings { Converters = { new StringEnumConverter() }, TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText($"profiles/{screenConfiguration.Name}.json", serializedScreenConfiguration);
        }
    }
}
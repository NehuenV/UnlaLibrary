using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace UnlaLibrary.Data.Utils
{
    internal static class MigrationUtils
    {
        public static string GetScript(this Assembly assembly, string resourceName)
        {
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}

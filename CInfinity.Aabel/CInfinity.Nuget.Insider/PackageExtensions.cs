namespace CInfinity.Nuget
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.Versioning;

    using NuGet;

    /// <summary>
    /// Extensds the <see cref="IPackage"/> interface and collection of <see cref="IPackage"/> instance.
    /// </summary>
    public static class PackageExtensions
    {
        #region Constants
        /// <summary>
        /// The name of the .NET framework.
        /// </summary>
        internal const string DotNetFramework = ".NETFramework";
        #endregion

        #region Public methods
        /// <summary>
        /// Determines if a given package can run on a given .NET framework.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <param name="version">
        /// The version of the .NET framework.
        /// </param>
        /// <returns>
        /// Flag indicating whether the package can run of a given version of the .NET framework.
        /// </returns>
        public static bool CanRunOnNetFramework(this IPackage package, string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentNullException(nameof(version));

            return package.CanRunOnNetFrameworkImpl(version);
        }
        #endregion

        #region Helper methods
        private static bool CanRunOnNetFrameworkImpl(this IPackage package, string version) =>
            package.CanRunOnNetFrameworkImpl(new Version(version));

        private static bool CanRunOnNetFrameworkImpl(this IPackage package, Version version) =>
            package.CanRunOnNetFrameworkImpl(new FrameworkName(DotNetFramework, version));

        internal static bool CanRunOnNetFrameworkImpl(this IPackage package, FrameworkName frameworkName) =>
            VersionUtility.IsCompatible(frameworkName, package.GetSupportedFrameworks());
        #endregion
    }
}

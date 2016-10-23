namespace CInfinity.Nuget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Versioning;

    using NuGet;

    public static class EnumerableExtensions
    {
        #region Public methods
        /// <summary>
        /// Determines if a collection of packages can run of a given version of the .NET framework.
        /// </summary>
        /// <param name="packages">
        /// The collection of packages.
        /// </param>
        /// <param name="version">
        /// The version of the .NET framework.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PackageCheckResult"/> class, containing the result of the check.
        /// </returns>
        public static PackageCheckResult CanRunOnNetFramework(this IEnumerable<IPackage> packages, string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentNullException(nameof(version));

            return packages.CanRunOnNetFrameworkImpl(version);
        }

        /// <summary>
        /// Determines if there are conflicts in the versions used by the packages that are in the
        /// chain of dependencies.
        /// </summary>
        /// <param name="packages">
        /// The collection of packages.
        /// </param>
        /// <param name="comparer">
        /// The equality comparer for the <see cref="IPackage"/> instances.
        /// </param>
        /// <returns>
        /// The result of the check.
        /// </returns>
        public static PackageCheckResult CheckVersions(this IEnumerable<IPackage> packages, IEqualityComparer<IPackage> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return packages.CheckVersionsImpl(comparer);
        }
        #endregion

        #region Helper methods
        private static PackageCheckResult CanRunOnNetFrameworkImpl(this IEnumerable<IPackage> packages, string version) =>
            packages.CanRunOnNetFrameworkImpl(new Version(version));

        private static PackageCheckResult CanRunOnNetFrameworkImpl(this IEnumerable<IPackage> packages, Version version) =>
            packages.CanRunOnNetFrameworkImpl(new FrameworkName(PackageExtensions.DotNetFramework, version));

        private static PackageCheckResult CanRunOnNetFrameworkImpl(this IEnumerable<IPackage> packages, FrameworkName frameworkName) =>
            packages.CheckCondition(p => p.CanRunOnNetFrameworkImpl(frameworkName));

        private static PackageCheckResult CheckCondition(this IEnumerable<IPackage> packages, Func<IPackage, bool> condition) =>
            PackageCheckResult.CreateFromColl(packages.Where(p => !condition(p)));

        private static PackageCheckResult CreateResult(this IEnumerable<IPackage> packages) =>
            PackageCheckResult.CreateFromColl(packages);

        private static PackageCheckResult CheckVersionsImpl(this IEnumerable<IPackage> packages, IEqualityComparer<IPackage> comparer) =>
            packages
                .Distinct(comparer)
                .GroupBy(p => p.Id)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.ToArray())
                .CreateResult();
        #endregion
    }
}

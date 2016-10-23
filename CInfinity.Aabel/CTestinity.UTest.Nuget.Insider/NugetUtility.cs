namespace CTestinity.UTest.Nuget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NuGet;

    internal static class NugetUtility
    {
        #region Constants
        /// <summary>
        /// The location for the Nuget org repository.
        /// </summary>
        private const string NugetOrgRepositoryLocation = "https://www.nuget.org/api/v2/";
        #endregion

        #region Public methods
        /// <summary>
        /// Retrieves the packages from a given repository location.
        /// </summary>
        /// <param name="localRepository">
        /// The path to the repository.
        /// </param>
        /// <returns>
        /// The collection of packages.
        /// </returns>
        public static IEnumerable<IPackage> GetPackages(string localRepository) =>
            PackageRepositoryFactory.Default
                                    .CreateRepository(localRepository)
                                    .GetPackages();

        /// <summary>
        /// Retriesves the packages with a given name.
        /// </summary>
        /// <param name="title">
        /// The title of the package.
        /// </param>
        /// <param name="repository">
        /// The locationn of the repository.
        /// </param>
        /// <returns>
        /// The collection of the packages.
        /// </returns>
        public static IEnumerable<IPackage> GetPackages(string title, string repository) =>
            GetPackages(repository).Where(p => p.Id == title);
        #endregion
    }
}

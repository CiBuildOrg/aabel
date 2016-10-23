namespace CInfinity.Nuget
{
    using System.Collections.Generic;
    using System.Linq;

    using NuGet;

    /// <summary>
    /// Wrapper for the package check results..
    /// </summary>
    public class PackageCheckResult
    {
        #region Constructors
        private PackageCheckResult(bool error, IEnumerable<IPackage> packages)
        {
            IsError = error;
            Packages = packages;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a flag that indicates whether the result is an error.
        /// </summary>
        public bool IsError { get; }

        /// <summary>
        /// Gets the collection of packages.
        /// </summary>
        public IEnumerable<IPackage> Packages { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Creates a success result from a collection of packages.
        /// </summary>
        /// <param name="packages">
        /// The collection of packages.
        /// </param>
        /// <returns>
        /// The <see cref="PackageCheckResult"/> instance.
        /// </returns>
        public static PackageCheckResult CreateSuccess(IEnumerable<IPackage> packages) =>
            new PackageCheckResult(false, packages);

        /// <summary>
        /// Creates an error result.
        /// </summary>
        /// <param name="packages">
        /// The collection of packages.
        /// </param>
        /// <returns>
        /// The <see cref="PackageCheckResult"/> instance.
        /// </returns>
        public static PackageCheckResult CreateError(IEnumerable<IPackage> packages) =>
            new PackageCheckResult(true, packages);

        /// <summary>
        /// Creates a result based on the number of packages in the collection.
        /// </summary>
        /// <param name="packages">
        /// The collection of packages.
        /// </param>
        /// <returns>
        /// The new <see cref="PackageCheckResult"/> instance.
        /// </returns>
        public static PackageCheckResult CreateFromColl(IEnumerable<IPackage> packages) =>
            packages.Count() == 0 ?
                PackageCheckResult.CreateSuccess(packages) :
                PackageCheckResult.CreateError(packages);
        #endregion
    }
}

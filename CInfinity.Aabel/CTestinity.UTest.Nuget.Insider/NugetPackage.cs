namespace CTestinity.UTest.Nuget
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.Versioning;
    using NuGet;


    [DebuggerDisplay("{Id} - {Version}")]
    internal class NugetPackage : IPackage
    {
        #region Constructors
        public NugetPackage(string id, string version)
        {
            Id = id;
            Version = new SemanticVersion(version);
        }
        #endregion

        #region Properties
        public IEnumerable<IPackageAssemblyReference> AssemblyReferences { get; }

        public IEnumerable<string> Authors { get; }

        public string Copyright { get; }

        public IEnumerable<PackageDependencySet> DependencySets { get; }

        public string Description { get; }

        public bool DevelopmentDependency { get; }

        public int DownloadCount { get; }

        public IEnumerable<FrameworkAssemblyReference> FrameworkAssemblies { get; }

        public Uri IconUrl { get; }

        public string Id { get; }

        public bool IsAbsoluteLatestVersion { get; }

        public bool IsLatestVersion { get; }

        public string Language { get; }

        public Uri LicenseUrl { get; }

        public bool Listed { get; }

        public Version MinClientVersion { get; }

        public IEnumerable<string> Owners { get; }

        public ICollection<PackageReferenceSet> PackageAssemblyReferences { get; }

        public Uri ProjectUrl { get; }

        public DateTimeOffset? Published { get; }

        public string ReleaseNotes { get; }

        public Uri ReportAbuseUrl { get; }

        public bool RequireLicenseAcceptance { get; }

        public string Summary { get; }

        public string Tags { get; }

        public string Title { get; }

        public SemanticVersion Version { get; }
        #endregion

        #region Public methods
        public void ExtractContents(IFileSystem fileSystem, string extractPath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPackageFile> GetFiles()
        {
            throw new NotImplementedException();
        }

        public Stream GetStream()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FrameworkName> GetSupportedFrameworks()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    internal class NugetPackageComparer : IEqualityComparer<IPackage>
    {
        public bool Equals(IPackage x, IPackage y) =>
            x.Id == y.Id && x.Version.ToString() == y.Version.ToString();

        public int GetHashCode(IPackage obj) =>
            obj.Id.GetHashCode() + obj.Version.GetHashCode();
    }
}

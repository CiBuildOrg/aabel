namespace CTestinity.UTest.Nuget
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using CInfinity.Nuget;

    using NuGet;

    /// <summary>
    /// Unit tests for the <see cref="EnumerableExtensions"/> class.
    /// </summary>
    [TestClass]
    public class UTestEnumerableExtensions
    {
        #region Test methods
        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void EnumPackage_CanRunOnFramework_Yes()
        {
            var source = @"c:\vx\source\packages_test";
            var packages = NugetUtility.GetPackages(source);

            var netVersion = "4.6.2";
            var res = packages.CanRunOnNetFramework(netVersion);

            Assert.IsFalse(res.IsError, "The operation should have succeeded");
        }

        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void EnumPackage_CanRunOnFramework_No()
        {
            var source = @"c:\vx\source\packages_test";
            var packages = NugetUtility.GetPackages(source);

            var netVersion = "4.5.2";
            var res = packages.CanRunOnNetFramework(netVersion);

            Assert.IsTrue(res.IsError, "The operation should have failed");
            Assert.AreEqual(1, res.Packages.Count(), "There is one packages which does not run on the given net framework");
        }

        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void EnumPackage_CanRunOnFramework_EmptyVersion()
        {
            var source = @"c:\vx\source\packages_test";
            var packages = NugetUtility.GetPackages(source);

            Action action = () => packages.CanRunOnNetFramework(string.Empty);

            action.CheckException<ArgumentNullException>();
        }

        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void EnumPackage_CheckVersion_DiffVersions()
        {
            var packages = new NugetPackage[]
            {
                new NugetPackage("A", "1.0.0.0"),
                new NugetPackage("B", "1.0.0.0"),
                new NugetPackage("C", "1.0.0.0"),
                new NugetPackage("D", "1.0.0.1"),
                new NugetPackage("D", "1.0.0.2"),
                new NugetPackage("B", "1.0.0.0")
            } as IEnumerable<IPackage>;

            var comparer = new NugetPackageComparer() as IEqualityComparer<IPackage>;
            var res = packages.CheckVersions(comparer);

            Assert.IsTrue(res.IsError, "We have a package with different versions");
        }

        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void EnumPackage_CheckVersion_SameVersions()
        {
            var packages = new NugetPackage[]
            {
                new NugetPackage("A", "1.0.0.0"),
                new NugetPackage("B", "1.0.0.0"),
                new NugetPackage("C", "1.0.0.0"),
                new NugetPackage("D", "1.0.0.1"),
                new NugetPackage("D", "1.0.0.1"),
                new NugetPackage("B", "1.0.0.0")
            } as IEnumerable<IPackage>;

            var comparer = new NugetPackageComparer() as IEqualityComparer<IPackage>;
            var res = packages.CheckVersions(comparer);

            Assert.IsFalse(res.IsError, "We have a packages with same versions");
        }

        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void EnumPackage_CheckVersion_NullComparer()
        {
            var packages = new NugetPackage[]
            {
                new NugetPackage("A", "1.0.0.0"),
                new NugetPackage("B", "1.0.0.0"),
                new NugetPackage("C", "1.0.0.0"),
                new NugetPackage("D", "1.0.0.1"),
                new NugetPackage("D", "1.0.0.2"),
                new NugetPackage("B", "1.0.0.0")
            } as IEnumerable<IPackage>;

            Action action = () => packages.CheckVersions(null);
            action.CheckException<ArgumentNullException>();
        }
        #endregion
    }
}

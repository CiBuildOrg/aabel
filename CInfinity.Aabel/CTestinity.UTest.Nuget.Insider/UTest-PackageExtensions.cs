namespace CTestinity.UTest.Nuget
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using CInfinity.Nuget;

    /// <summary>
    /// Unit tests for the <see cref="PackageExtensions"/> class.
    /// </summary>
    [TestClass]
    public class UTestInsider
    {
        #region Test methods
        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void Package_CanRunOnFramework_Yes()
        {
            var source = @"c:\vx\source\packages_test";
            var title = "A.Id";
            var r = NugetUtility.GetPackages(source);
            var package = NugetUtility.GetPackages(title, source).First();

            var netVersion = "4.6.2";
            var res = package.CanRunOnNetFramework(netVersion);

            Assert.IsTrue(res, "The operation should have succeeded");
        }

        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void Package_CanRunOnFramework_No()
        {
            var source = @"c:\vx\source\packages_test";
            var title = "A.Id";
            var package = NugetUtility.GetPackages(title, source).First();

            var netVersion = "3.3.2";
            var res = package.CanRunOnNetFramework(netVersion);

            Assert.IsFalse(res, "The operation should have failed");
        }

        [TestMethod]
        [TestCategory("Nuget.Package")]
        public void Package_CanRunOnframework_EmptyVersion()
        {
            var source = @"c:\vx\source\packages_test";
            var title = "A.Id";
            var package = NugetUtility.GetPackages(title, source).First();

            Action action = () => package.CanRunOnNetFramework(string.Empty);
            action.CheckException<ArgumentNullException>();
        }
        #endregion
    }
}

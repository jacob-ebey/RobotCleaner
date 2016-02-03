using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobEbey.RobotCleaner.Tests
{
    /// <summary>
    /// The test fixture for the application's executable.
    /// </summary>
    [TestClass]
    public class ApplicationTest
    {
        // Ignore the ugly compile time check below.
        // It's a quick and dirty way for getting the exe.
#if DEBUG
        string configuration = "Debug";
#else
        string configuration = "Release";
#endif

        /// <summary>
        /// Test the application by writing to stdin and stdout.
        /// </summary>
        [TestMethod]
        public void TestApplication()
        {
            // Start the application.
            ProcessStartInfo psi = new ProcessStartInfo($@"..\..\..\JacobEbey.RobotCleaner.Applicaton\Bin\{configuration}\JacobEbey.RobotCleaner.Applicaton.exe");
            psi.UseShellExecute = false;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;

            Process p = Process.Start(psi);

            var stdin = p.StandardInput;
            
            // Write command count
            stdin?.WriteLine("2");
            // Write initial position
            stdin?.WriteLine("10 22");

            // Write the moves
            stdin?.WriteLine("E 2");
            stdin?.WriteLine("N 1");

            var stdout = p.StandardOutput;

            var line = stdout.ReadLine();
            Assert.AreEqual(
                "=> Cleaned: 4",
                line);
        }
    }
}

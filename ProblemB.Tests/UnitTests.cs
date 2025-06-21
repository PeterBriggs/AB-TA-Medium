using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProblemB;

namespace ProblemB.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SimpleExactMatches_Test()
        {
            // Arrange
            string searchSequence = "AGC";
            string targetSequence = "AGCAGC";

            // Act
            int type1Count = Program.CountType1(searchSequence, targetSequence);
            int type2Count = Program.CountType2(searchSequence, targetSequence);
            int type3Count = Program.CountType3(searchSequence, targetSequence);

            // Assert
            Assert.AreEqual(2, type1Count, "Type 1 count mismatch");
            Assert.AreEqual(4, type2Count, "Type 2 count mismatch");
            Assert.AreEqual(2, type3Count, "Type 3 count mismatch");
        }

        [TestMethod]
        public void OverlappingMatches_Test()
        {
            // Arrange
            string searchSequence = "AAA";
            string targetSequence = "AAAAA";

            // Act
            int type1Count = Program.CountType1(searchSequence, targetSequence);
            int type2Count = Program.CountType2(searchSequence, targetSequence);
            int type3Count = Program.CountType3(searchSequence, targetSequence);

            // Assert
            Assert.AreEqual(3, type1Count, "Type 1 count mismatch");
            Assert.AreEqual(4, type2Count, "Type 2 count mismatch");
            Assert.AreEqual(2, type3Count, "Type 3 count mismatch");
        }

        [TestMethod]
        public void SampleInputOutput_Test()
        {
            // Test case 1 - AGCT in AGCTAGCT
            Assert.AreEqual(2, Program.CountType1("AGCT", "AGCTAGCT"), "Sample 1 Type 1");
            Assert.AreEqual(4, Program.CountType2("AGCT", "AGCTAGCT"), "Sample 1 Type 2");
            Assert.AreEqual(2, Program.CountType3("AGCT", "AGCTAGCT"), "Sample 1 Type 3");

            // Test case 2 - AAA in AAAAAAAAAA
            Assert.AreEqual(8, Program.CountType1("AAA", "AAAAAAAAAA"), "Sample 2 Type 1");
            Assert.AreEqual(9, Program.CountType2("AAA", "AAAAAAAAAA"), "Sample 2 Type 2");
            Assert.AreEqual(7, Program.CountType3("AAA", "AAAAAAAAAA"), "Sample 2 Type 3");

            // Test case 3 - AGC in TTTTGT
            Assert.AreEqual(0, Program.CountType1("AGC", "TTTTGT"), "Sample 3 Type 1");
            Assert.AreEqual(0, Program.CountType2("AGC", "TTTTGT"), "Sample 3 Type 2");
            Assert.AreEqual(0, Program.CountType3("AGC", "TTTTGT"), "Sample 3 Type 3");
        }
    }
}

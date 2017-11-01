using System;
using NUnit.Framework;

namespace FileComparer.Tests {
    [TestFixture]
    public class ComparerTests {
        [Test]
        public void GetTest() {
            foreach(FileFormats fileFormat in Enum.GetValues(typeof(FileFormats))) {
                Comparer.Get(fileFormat);
            }
        }
    }
}
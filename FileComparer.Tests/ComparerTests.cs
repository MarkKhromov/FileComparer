using System;
using NUnit.Framework;

namespace FileComparer.Tests {
    [TestFixture]
    public class ComparerTests {
        #region Inner classes
        struct TestObject {
            public TestObject(FileFormats fileFormat, object value1, object value2, bool expectedResult) {
                FileFormat = fileFormat;
                Value1 = value1;
                Value2 = value2;
                ExpectedResult = expectedResult;
            }

            public readonly FileFormats FileFormat;
            public readonly object Value1;
            public readonly object Value2;
            public readonly bool ExpectedResult;
        }
        #endregion

        [Test]
        public void GetTest() {
            foreach(FileFormats fileFormat in Enum.GetValues(typeof(FileFormats))) {
                Comparer.Get(fileFormat);
            }
        }

        [Test]
        public void CompareTest() {
            var testObjects = new[] {
                new TestObject(FileFormats.Txt, "test1", "test1", true),
                new TestObject(FileFormats.Txt, "test1", "test2", false),
                new TestObject(FileFormats.All, new[] { (byte)5, (byte)7, (byte)9 }, new[] { (byte)5, (byte)7, (byte)9 }, true),
                new TestObject(FileFormats.All, new[] { (byte)4, (byte)7, (byte)9 }, new[] { (byte)5, (byte)7, (byte)9 }, false)
            };
            foreach(var testObject in testObjects) {
                var comparer = Comparer.Get(testObject.FileFormat);
                Assert.AreEqual(testObject.ExpectedResult, comparer.Compare(testObject.Value1, testObject.Value2));
            }
        }
    }
}
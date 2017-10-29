using NUnit.Framework;

namespace FileComparer.Tests {
    [TestFixture]
    public class CommandTests {
        [Test]
        public void ExecuteTest() {
            var testInt = 0;
            var command = new Command(() => testInt = 5, () => true);
            Assert.AreEqual(0, testInt);
            command.Execute(null);
            Assert.AreEqual(5, testInt);
        }

        [Test]
        public void CanExecuteTest() {
            var command = new Command(() => { }, () => true);
            Assert.IsTrue(command.CanExecute(null));
            command = new Command(() => { }, () => false);
            Assert.IsFalse(command.CanExecute(null));
        }
    }
}
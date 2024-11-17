using Zadanie;

namespace TestProject3
{
    [TestClass]
    public class ChangeMailTests
    {
        [TestMethod]
        public void ReadFromNotExistingFileTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string actual = mail.ReadFromFile("notExistedFile");
            string expected = "Файл notExistedFile не найден!";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckRightInputTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string input = "6,2\nHello\nas";
            (int, int, string[]) actual= mail.GetSeparatedValues(input);
            string[] expectedArray = input.Split('\n');
            (int, int, string[]) expected = (6, 2, expectedArray);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.AreEqual(expected.Item2, actual.Item2);
            Assert.AreEqual(string.Join(",", expected.Item3), string.Join(",", actual.Item3));

        }

        [TestMethod]
        public void CheckWrongKInputTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string input = "2,2\nHello\nas";
            (int, int, string[]) actual = mail.GetSeparatedValues(input);
            string[] expectedArray = input.Split('\n');
            (int, int, string[]) expected = (2, 2, expectedArray);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.AreEqual(expected.Item2, actual.Item2);
            Assert.AreEqual("Impossible", string.Join(",", actual.Item3));

        }

        [TestMethod]
        public void CheckWrongNInputTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string input = "6,3\nHello\nas";
            (int, int, string[]) actual = mail.GetSeparatedValues(input);
            string[] expectedArray = input.Split('\n');
            (int, int, string[]) expected = (6, 3, expectedArray);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.AreEqual(expected.Item2, actual.Item2);
            Assert.AreEqual("Impossible", string.Join(",", actual.Item3));

        }

        [TestMethod]
        public void ChangeTextWithEvenKTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string actual = mail.ChangeText((8, 3, ["8,3", "Hello", "World", "!"]));
            string expected = "+Hello++\n+World++\n+++!++++";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeTextWithOddKTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string actual = mail.ChangeText((7, 3, ["7,3", "Hello", "World", "!"]));
            string expected = "+Hello+\n+World+\n+++!+++";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WriteToNotExistedFileTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            bool actual = mail.WriteToFile("notExistedFile", "");
            Assert.IsFalse(actual);
        }

    }
}
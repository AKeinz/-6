using Zadanie;

namespace TestProject3
{
    [TestClass]
    public class ChangeMailTests
    {
        [TestMethod]
        public void ReadFromFileTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string actual = mail.ReadFromFile("");
            Assert.AreEqual(actual, "Файл  не найден!");
        }

        [TestMethod]
        public void CheckTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string actual= mail.GetSeparatedValues("").text;
            Assert.AreEqual(actual, "Impossible");

        }

        [TestMethod]
        public void ChangeTextTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            string actual = mail.ChangeText((1, 1, ""));
            Assert.AreEqual(actual, "Impossible");
        }

        [TestMethod]
        public void WriteToFileTestMethod()
        {
            ChangeMail mail = new ChangeMail();
            bool actual = mail.WriteToFile("");
            Assert.IsTrue(actual);
        }
    }
}
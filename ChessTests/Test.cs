using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestCase1()
        {
            Account account = new Account(new AccountInfo { Email = "newuser@mail.ru", Password = "1234", AccessLevel = 0 });

            ApplicationManager.InitializeAccount(account);

            Account getAcc = ApplicationManager.GetCurrentAccount();

            Assert.AreEqual(account, getAcc);

        }
    }
}

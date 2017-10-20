using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSE;

namespace UnitTests
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void ParsingRegistrationTest1()
        {
            var user = new User("name", "surname", "email@.com", "password");
            var csv = new CSV();
            csv.WriteToFileRegistration(user);

            bool expected = true;
            bool actual = csv.ParsingRegistration("email@.com", "password");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmailTest1()
        {
            Email userEmail = new Email();
            string email = "email@gmail.com";

            bool expected = true;
            bool actual = userEmail.IsValid(email);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmailTest2()
        {
            Email userEmail = new Email();
            string email = "email.com";

            bool expected = false;
            bool actual = userEmail.IsValid(email);

            Assert.AreEqual(expected, actual);
        }
    }
}
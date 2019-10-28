using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExhaustiveFluentBuilderPattern.Test {
    [TestClass]
    public class UserBuilderTest {
        [TestMethod]
        public void ConstructionWithOptionalFieldsExample() {
            var user = UserBuilder.NewUser
                                  .WithFirstName("John")
                                  .WithMiddleName("Mc")
                                  .WithLastName("Doe")
                                  .WithEmail("johndoe@gmail.com")
                                  .WithMobile("+4512345678")
                                  .WithLandline("+4570123456")
                                  .Build();

            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Mc", user.MiddleName);
            Assert.AreEqual("Doe", user.LastName);
            Assert.AreEqual("johndoe@gmail.com", user.Email);
            Assert.AreEqual("+4512345678", user.Mobile);
            Assert.AreEqual("+4570123456", user.Landline);
        }

        [TestMethod]
        public void ConstructionWithoutOptionalFieldsExample() {
            var user = UserBuilder.NewUser
                                  .WithFirstName("John")
                                  .WithLastName("Doe")
                                  .WithEmail("johndoe@gmail.com")
                                  .WithMobile("+4512345678")
                                  .Build();

            Assert.AreEqual("John", user.FirstName);
            Assert.IsNull(user.MiddleName);
            Assert.AreEqual("Doe", user.LastName);
            Assert.AreEqual("johndoe@gmail.com", user.Email);
            Assert.AreEqual("+4512345678", user.Mobile);
            Assert.IsNull(user.Landline);
        }
    }
}

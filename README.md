# Exhaustive Fluent Builder Pattern
Goal: Finding a pattern to avoid polluted constructors with a lot of parameters.  
  
Background: How many times you have found yourself staring at a class constructor with tens of parameters or creating one yourself. I found myself in such situations time and again.  
  
Applications: First of all one must ask himself/herself, why do I have so many parameters in the constructor. Could this be the result of a bad design. If that is the case, go re-visit the design. If there is no way to avoid it then this pattern could be your helper.  
  
Problem: Create a user with mandatory and optional properties.  
  
Solution: Create a builder that provides methods for mandatory and optional fields in an ordered (exhaustive) manner so that mandatory fields must be forced however optional fields can be left unassigned.  

```csharp
namespace ExhaustiveFluentBuilderPattern {
    public interface IUser {
        string FirstName { get; } // Mandatory
        string MiddleName { get; } // Optional
        string LastName { get; } // Mandatory
        string Email { get; } // Mandatory
        string Mobile { get; } // Mandatory
        string Landline { get; } // Optional

        string FullName { get; }
        bool IsFromDenmark();
    }
}  
```  
  
```csharp
namespace ExhaustiveFluentBuilderPattern {
    internal interface IUserBuilder :
        IExpectFirstName, IExpectMiddleName, IExpectLastName,
        IExpectEmail, IExpectMobile, IExpectLandline, IExpectBuild {
    }
    
    public interface IExpectFirstName{
        /// <summary>
        /// Mandatory FirstName
        /// </summary>
        IExpectMiddleName WithFirstName(string firstName);
    }
    
    public interface IExpectMiddleName : IExpectLastName {
        /// <summary>
        /// Optional MiddleName, you may skip calling this method to leave MiddleName unassigned
        /// </summary>
        IExpectLastName WithMiddleName(string middleName);
    }
    
    public interface IExpectLastName {
        /// <summary>
        /// Mandatory LastName
        /// </summary>
        IExpectEmail WithLastName(string lastName);
    }
    
    public interface IExpectEmail {
        /// <summary>
        /// Mandatory Email
        /// </summary>
        IExpectMobile WithEmail(string email);
    }
    
    public interface IExpectMobile {
        /// <summary>
        /// Mandatory Mobile
        /// </summary>
        IExpectLandline WithMobile(string mobile);
    }
    
    public interface IExpectLandline : IExpectBuild {
        /// <summary>
        /// Optional Landline, you may skip calling this method to leave Landline unassigned
        /// </summary>
        IExpectBuild WithLandline(string landline);
    }
    
    public interface IExpectBuild {
        /// <summary>
        /// Mandatory Build method, returns <see cref="IUser"/>
        /// </summary>
        IUser Build();
    }
}
```  
We are nesting our User class so that it can only be instantiated from the UserBuilder class  
```csharp
using System.Text;

namespace ExhaustiveFluentBuilderPattern {
    public partial class UserBuilder {
        private class User : IUser {
            public string FirstName { get; set; } // Mandatory
            public string MiddleName { get; set; } // Optional
            public string LastName { get; set; } // Mandatory
            public string Email { get; set; } // Mandatory
            public string Mobile { get; set; } // Mandatory
            public string Landline { get; set; } // Optional

            public string FullName {
                get {
                    var fullName = new StringBuilder();
                    fullName.Append(FirstName).Append(" ");

                    if (MiddleName != null) {
                        fullName.Append(MiddleName).Append(" ");
                    }

                    fullName.Append(LastName);
                    return fullName.ToString();
                }
            }

            public bool IsFromDenmark() {
                return Mobile.StartsWith("+45");
            }
        }
    }
}
```  
  
```csharp
using System;

namespace ExhaustiveFluentBuilderPattern {
    public partial class UserBuilder : IUserBuilder {

        private User user = new User();

        public static IExpectFirstName NewUser => new UserBuilder();

        /// <inheritdoc />
        public IExpectMiddleName WithFirstName(string firstName) {
            user.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            return this;
        }

        /// <inheritdoc />
        public IExpectLastName WithMiddleName(string middleName) {
            user.MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            return this;
        }

        /// <inheritdoc />
        public IExpectEmail WithLastName(string lastName) {
            user.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            return this;
        }

        /// <inheritdoc />
        public IExpectMobile WithEmail(string email) {
            user.Email = email ?? throw new ArgumentNullException(nameof(email));
            return this;
        }

        /// <inheritdoc />
        public IExpectLandline WithMobile(string mobile) {
            user.Mobile = mobile ?? throw new ArgumentNullException(nameof(mobile));
            return this;
        }

        /// <inheritdoc />
        public IExpectBuild WithLandline(string landline) {
            user.Landline = landline ?? throw new ArgumentNullException(nameof(landline));
            return this;
        }

        /// <inheritdoc />
        public IUser Build() {
            return user;
        }
    }
}
```  
  
Now we can use our UserBuilder class to instantiate new User instances.
```csharp
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
```

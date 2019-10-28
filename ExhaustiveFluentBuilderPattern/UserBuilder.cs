using System;

namespace ExhaustiveFluentBuilderPattern {
    public partial class UserBuilder : IUserBuilder {

        private User user = new User();

        public static IExpectFirstName NewUser => new UserBuilder();

        public IExpectMiddleName WithFirstName(string firstName) {
            user.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            return this;
        }

        public IExpectLastName WithMiddleName(string middleName) {
            user.MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            return this;
        }

        public IExpectEmail WithLastName(string lastName) {
            user.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            return this;
        }

        public IExpectMobile WithEmail(string email) {
            user.Email = email ?? throw new ArgumentNullException(nameof(email));
            return this;
        }

        public IExpectLandline WithMobile(string mobile) {
            user.Mobile = mobile ?? throw new ArgumentNullException(nameof(mobile));
            return this;
        }

        public IExpectBuild WithLandline(string landline) {
            user.Landline = landline ?? throw new ArgumentNullException(nameof(landline));
            return this;
        }

        public IUser Build() {
            return user;
        }
    }
}

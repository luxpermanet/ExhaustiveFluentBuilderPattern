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

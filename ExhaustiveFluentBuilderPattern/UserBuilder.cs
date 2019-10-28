using System;

namespace ExhaustiveFluentBuilderPattern {
    public partial class UserBuilder : 
        IExpectFirstName, IExpectMiddleName, IExpectLastName, 
        IExpectEmail, IExpectMobile, IExpectLandline, IExpectBuild {

        private User user = new User();

        public static IExpectFirstName NewUser => new UserBuilder();

        public IExpectMiddleName WithFirstName(string firstName) {
            if (firstName == null) { throw new ArgumentNullException(nameof(firstName)); }
            user.FirstName = firstName;
            return this;
        }

        public IExpectLastName WithMiddleName(string middleName) {
            if (middleName == null) { throw new ArgumentNullException(nameof(middleName)); }
            user.MiddleName = middleName;
            return this;
        }

        public IExpectEmail WithLastName(string lastName) {
            if (lastName == null) { throw new ArgumentNullException(nameof(lastName)); }
            user.LastName = lastName;
            return this;
        }

        public IExpectMobile WithEmail(string email) {
            if (email == null) { throw new ArgumentNullException(nameof(email)); }
            user.Email = email;
            return this;
        }

        public IExpectLandline WithMobile(string mobile) {
            if (mobile == null) { throw new ArgumentNullException(nameof(mobile)); }
            user.Mobile = mobile;
            return this;
        }

        public IExpectBuild WithLandline(string landline) {
            if (landline == null) { throw new ArgumentNullException(nameof(landline)); }
            user.Landline = landline;
            return this;
        }

        public IUser Build() {
            return user;
        }
    }
}

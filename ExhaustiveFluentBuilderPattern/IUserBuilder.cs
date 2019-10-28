namespace ExhaustiveFluentBuilderPattern {
    // Mandatory FirstName
    public interface IExpectFirstName{
        IExpectMiddleName WithFirstName(string firstName);
    }

    // Optional MiddleName
    public interface IExpectMiddleName : IExpectLastName {
        IExpectLastName WithMiddleName(string middleName);
    }

    // Mandatory LastName
    public interface IExpectLastName {
        IExpectEmail WithLastName(string lastName);
    }

    // Mandatory Email
    public interface IExpectEmail {
        IExpectMobile WithEmail(string email);
    }

    // Mandatory Mobile
    public interface IExpectMobile {
        IExpectLandline WithMobile(string mobile);
    }

    // Optional Landline
    public interface IExpectLandline : IExpectBuild {
        IExpectBuild WithLandline(string landline);
    }

    // Mandatory Build method
    public interface IExpectBuild {
        IUser Build();
    }
}

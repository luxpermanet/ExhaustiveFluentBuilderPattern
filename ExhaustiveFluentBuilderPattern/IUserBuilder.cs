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

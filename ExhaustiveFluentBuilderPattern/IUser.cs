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

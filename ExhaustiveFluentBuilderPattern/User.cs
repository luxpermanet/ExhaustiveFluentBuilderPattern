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

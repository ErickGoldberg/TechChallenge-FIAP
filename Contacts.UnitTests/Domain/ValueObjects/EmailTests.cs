using Contacts.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Contacts.UnitTests.Domain.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void Email_Should_Create_Email_With_Valid_Address()
        {
            // Arrange
            var emailAddress = "test@example.com";

            // Act
            var email = new Email(emailAddress);

            // Assert
            Assert.Equal(emailAddress, email.Endereco);
        }

        [Fact]
        public void Email_Should_Return_Error_If_Address_Is_Invalid()
        {
            // Arrange
            var invalidEmail = "invalid_email";

            // Act
            var email = new Email(invalidEmail);
            var validationContext = new ValidationContext(email);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(email, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "O endereço de email não é valido");
        }

        [Fact]
        public void Emails_With_Same_Address_Should_Be_Equal()
        {
            // Arrange
            var email1 = new Email("test@example.com");
            var email2 = new Email("test@example.com");

            // Act & Assert
            Assert.Equal(email1, email2);
            Assert.True(email1.Equals(email2));
            Assert.Equal(email1.GetHashCode(), email2.GetHashCode());
        }

        [Fact]
        public void Emails_With_Different_Addresses_Should_Not_Be_Equal()
        {
            // Arrange
            var email1 = new Email("test@example.com");
            var email2 = new Email("other@example.com");

            // Act & Assert
            Assert.NotEqual(email1, email2);
            Assert.False(email1.Equals(email2));
            Assert.NotEqual(email1.GetHashCode(), email2.GetHashCode());
        }

        [Fact]
        public void Email_Should_Return_False_If_Compared_To_Null()
        {
            // Arrange
            var email = new Email("test@example.com");

            // Act & Assert
            Assert.False(email.Equals(null));
        }

        [Fact]
        public void Email_Should_Return_False_If_Compared_To_Different_Type()
        {
            // Arrange
            var email = new Email("test@example.com");
            var otherObject = new object();

            // Act & Assert
            Assert.False(email.Equals(otherObject));
        }
    }

}

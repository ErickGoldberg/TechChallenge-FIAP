using Contacts.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Contacts.UnitTests.Domain.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void Name_Should_Create_Name_With_Valid_First_And_LastName()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";

            // Act
            var name = new Name(firstName, lastName);

            // Assert
            Assert.Equal(firstName, name.FirstName);
            Assert.Equal(lastName, name.LastName);
        }

        [Fact]
        public void Name_Should_Return_Error_If_FirstName_Is_Null()
        {
            // Arrange
            var lastName = "Doe";

            // Act
            var name = new Name(null, lastName);
            var validationContext = new ValidationContext(name);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(name, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage.Contains("The FirstName field is required"));
        }

        [Fact]
        public void Name_Should_Return_Error_If_LastName_Is_Null()
        {
            // Arrange
            var firstName = "John";

            // Act
            var name = new Name(firstName, null);
            var validationContext = new ValidationContext(name);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(name, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage.Contains("The LastName field is required"));
        }

        [Fact]
        public void Names_With_Same_FirstName_And_LastName_Should_Be_Equal()
        {
            // Arrange
            var name1 = new Name("John", "Doe");
            var name2 = new Name("John", "Doe");

            // Act & Assert
            Assert.Equal(name1, name2);
            Assert.True(name1.Equals(name2));
            Assert.Equal(name1.GetHashCode(), name2.GetHashCode());
        }

        [Fact]
        public void Names_With_Different_FirstName_Or_LastName_Should_Not_Be_Equal()
        {
            // Arrange
            var name1 = new Name("John", "Doe");
            var name2 = new Name("Jane", "Doe");
            var name3 = new Name("John", "Smith");

            // Act & Assert
            Assert.NotEqual(name1, name2);
            Assert.NotEqual(name1, name3);
            Assert.False(name1.Equals(name2));
            Assert.False(name1.Equals(name3));
        }

        [Fact]
        public void Name_Should_Return_False_If_Compared_To_Null()
        {
            // Arrange
            var name = new Name("John", "Doe");

            // Act & Assert
            Assert.False(name.Equals(null));
        }

        [Fact]
        public void Name_Should_Return_False_If_Compared_To_Different_Type()
        {
            // Arrange
            var name = new Name("John", "Doe");
            var otherObject = new object();

            // Act & Assert
            Assert.False(name.Equals(otherObject));
        }

        [Fact]
        public void Name_ToString_Should_Return_FullName()
        {
            // Arrange
            var name = new Name("John", "Doe");

            // Act
            var result = name.ToString();

            // Assert
            Assert.Equal("John Doe", result);
        }
    }
}

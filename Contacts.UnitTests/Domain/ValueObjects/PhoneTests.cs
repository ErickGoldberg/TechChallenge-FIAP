using Contacts.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Contacts.UnitTests.Domain.ValueObjects
{
    public class PhoneTests
    {
        [Fact]
        public void Phone_Should_Create_Phone_With_Valid_DDD_And_Number()
        {
            // Arrange
            var ddd = 21;
            var number = 987654321;

            // Act
            var phone = new Phone(ddd, number);

            // Assert
            Assert.Equal(ddd, phone.DDD);
            Assert.Equal(number, phone.Number);
        }

        [Fact]
        public void Phone_Should_Return_Error_If_DDD_Is_Invalid()
        {
            // Arrange
            var invalidDDD = 101; // DDD must be between 11 and 99
            var number = 987654321;

            // Act
            var phone = new Phone(invalidDDD, number);
            var validationContext = new ValidationContext(phone);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(phone, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "DDD inválido - O DDD deve estar entre 11 ou 99");
        }

        [Fact]
        public void Phone_Should_Return_Error_If_Number_Length_Is_Invalid()
        {
            // Arrange
            var ddd = 21;
            var invalidNumber = 123456; // Number should be between 8 and 9 digits

            // Act
            var phone = new Phone(ddd, invalidNumber);
            var validationContext = new ValidationContext(phone);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(phone, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "O tamanho do telefone deve ser de 8 a 9 dígitos");
        }

        [Fact]
        public void Phones_With_Same_DDD_And_Number_Should_Be_Equal()
        {
            // Arrange
            var phone1 = new Phone(21, 987654321);
            var phone2 = new Phone(21, 987654321);

            // Act & Assert
            Assert.Equal(phone1, phone2);
            Assert.True(phone1.Equals(phone2));
            Assert.Equal(phone1.GetHashCode(), phone2.GetHashCode());
        }

        [Fact]
        public void Phones_With_Different_DDD_Or_Number_Should_Not_Be_Equal()
        {
            // Arrange
            var phone1 = new Phone(21, 987654321);
            var phone2 = new Phone(11, 987654321); // Different DDD
            var phone3 = new Phone(21, 12345678);  // Different Number

            // Act & Assert
            Assert.NotEqual(phone1, phone2);
            Assert.NotEqual(phone1, phone3);
            Assert.False(phone1.Equals(phone2));
            Assert.False(phone1.Equals(phone3));
        }

        [Fact]
        public void Phone_Should_Return_False_If_Compared_To_Null()
        {
            // Arrange
            var phone = new Phone(21, 987654321);

            // Act & Assert
            Assert.False(phone.Equals(null));
        }

        [Fact]
        public void Phone_Should_Return_False_If_Compared_To_Different_Type()
        {
            // Arrange
            var phone = new Phone(21, 987654321);
            var otherObject = new object();

            // Act & Assert
            Assert.False(phone.Equals(otherObject));
        }

        [Fact]
        public void Phone_ToString_Should_Return_Formatted_Phone()
        {
            // Arrange
            var phone = new Phone(21, 987654321);

            // Act
            var result = phone.ToString();

            // Assert
            Assert.Equal("(21) 987654321", result);
        }
    }
}

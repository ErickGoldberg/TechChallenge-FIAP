using Contacts.Domain.Entities;
using Contacts.Domain.ValueObjects;

namespace Contacts.UnitTests.Domain.Entities
{
    public class ContactTests
    {
        [Fact]
        public void Contact_Should_Create_Contact_With_Valid_Name_Email_And_Phone()
        {
            // Arrange
            var name = new Name("John", "Doe");
            var email = new Email("john.doe@example.com");
            var phone = new Phone(21, 987654321);

            // Act
            var contact = new Contact(name, email, phone);

            // Assert
            Assert.Equal(name, contact.Name);
            Assert.Equal(email, contact.Email);
            Assert.Equal(phone, contact.Phone);
            Assert.NotEqual(Guid.Empty, contact.Id); // Check if the Id is initialized properly
        }

        [Fact]
        public void Contact_Should_Throw_Exception_If_Name_Is_Null()
        {
            // Arrange
            var email = new Email("john.doe@example.com");
            var phone = new Phone(21, 987654321);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Contact(null, email, phone));
        }

        [Fact]
        public void Contact_Should_Throw_Exception_If_Email_Is_Null()
        {
            // Arrange
            var name = new Name("John", "Doe");
            var phone = new Phone(21, 987654321);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Contact(name, null, phone));
        }

        [Fact]
        public void Contact_Should_Throw_Exception_If_Phone_Is_Null()
        {
            // Arrange
            var name = new Name("John", "Doe");
            var email = new Email("john.doe@example.com");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Contact(name, email, null));
        }

        [Fact]
        public void UpdateName_Should_Update_The_Name_Of_Contact()
        {
            // Arrange
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(21, 987654321));
            var newName = new Name("Jane", "Doe");

            // Act
            contact.UpdateName(newName);

            // Assert
            Assert.Equal(newName, contact.Name);
        }

        [Fact]
        public void UpdateName_Should_Throw_Exception_If_NewName_Is_Null()
        {
            // Arrange
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(21, 987654321));

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => contact.UpdateName(null));
            Assert.Contains("O nome não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void UpdateEmail_Should_Update_The_Email_Of_Contact()
        {
            // Arrange
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(21, 987654321));
            var newEmail = new Email("jane.doe@example.com");

            // Act
            contact.UpdateEmail(newEmail);

            // Assert
            Assert.Equal(newEmail, contact.Email);
        }

        [Fact]
        public void UpdateEmail_Should_Throw_Exception_If_NewEmail_Is_Null()
        {
            // Arrange
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(21, 987654321));

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => contact.UpdateEmail(null));
            Assert.Contains("O email não pode ser vazio.", exception.Message);
        }

        [Fact]
        public void UpdatePhone_Should_Update_The_Phone_Of_Contact()
        {
            // Arrange
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(21, 987654321));
            var newPhone = new Phone(11, 12345678);

            // Act
            contact.UpdatePhone(newPhone);

            // Assert
            Assert.Equal(newPhone, contact.Phone);
        }

        [Fact]
        public void UpdatePhone_Should_Throw_Exception_If_NewPhone_Is_Null()
        {
            // Arrange
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(21, 987654321));

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => contact.UpdatePhone(null));
            Assert.Contains("O telefone não pode ser vazio.", exception.Message);
        }
    }
}

using Contacts.Application.InputModels;
using Contacts.Application.Services;
using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using Contacts.Domain.ValueObjects;
using Moq;

namespace Contacts.UnitTests.Application
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactsRepository> _mockRepository;
        private readonly ContactService _contactService;

        public ContactServiceTests()
        {
            _mockRepository = new Mock<IContactsRepository>();
            _contactService = new ContactService(_mockRepository.Object);
        }

        [Fact]
        public async Task CreateContactAsync_ShouldReturnSuccess_WhenContactIsCreated()
        {
            // Arrange
            var inputModel = new CreateOrEditContactInputModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DDD = 11,
                Number = 987654321
            };

            _mockRepository.Setup(r => r.CreateContactAsync(It.IsAny<Contact>()))
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _contactService.CreateContactAsync(inputModel);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepository.Verify(r => r.CreateContactAsync(It.IsAny<Contact>()), Times.Once);
        }

        [Fact]
        public async Task DeleteContactAsync_ShouldReturnFailure_WhenContactDoesNotExist()
        {
            // Arrange
            var contactId = Guid.NewGuid();

            _mockRepository.Setup(r => r.GetContactByIdAsync(contactId))
                           .ReturnsAsync((Contact)null);

            // Act
            var result = await _contactService.DeleteContactAsync(contactId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Contact not found", result.Message);
        }

        [Fact]
        public async Task DeleteContactAsync_ShouldReturnSuccess_WhenContactExists()
        {
            // Arrange
            var contactId = Guid.NewGuid();
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(11, 987654321));

            _mockRepository.Setup(r => r.GetContactByIdAsync(contactId))
                           .ReturnsAsync(contact);
            _mockRepository.Setup(r => r.DeleteContactAsync(contactId))
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _contactService.DeleteContactAsync(contactId);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepository.Verify(r => r.DeleteContactAsync(contactId), Times.Once);
        }

        [Fact]
        public async Task GetContactByIdAsync_ShouldReturnNull_WhenContactDoesNotExist()
        {
            // Arrange
            var contactId = Guid.NewGuid();

            _mockRepository.Setup(r => r.GetContactByIdAsync(contactId))
                           .ReturnsAsync((Contact)null);

            // Act
            var result = await _contactService.GetContactByIdAsync(contactId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task GetContactByIdAsync_ShouldReturnContactDto_WhenContactExists()
        {
            // Arrange
            var contactId = Guid.NewGuid();
            var contact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(11, 987654321));

            _mockRepository.Setup(r => r.GetContactByIdAsync(contactId))
                           .ReturnsAsync(contact);

            // Act
            var result = await _contactService.GetContactByIdAsync(contactId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal("John", result.Data.Name.FirstName);
            Assert.Equal("Doe", result.Data.Name.LastName);
        }

        [Fact]
        public async Task GetContactsAsync_ShouldReturnListOfContacts()
        {
            // Arrange
            var contacts = new List<Contact>
        {
            new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(11, 987654321)),
            new Contact(new Name("Jane", "Doe"), new Email("jane.doe@example.com"), new Phone(12, 987654322))
        };

            _mockRepository.Setup(r => r.GetContactsAsync())
                           .ReturnsAsync(contacts);

            // Act
            var result = await _contactService.GetContactsAsync();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("John", result.Data[0].Name.FirstName);
            Assert.Equal("Jane", result.Data[1].Name.FirstName);
        }

        [Fact]
        public async Task GetContactsByDDDAsync_ShouldReturnContacts_WhenDDDMatches()
        {
            // Arrange
            int DDD = 11;
            var contacts = new List<Contact>
        {
            new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(11, 987654321))
        };

            _mockRepository.Setup(r => r.GetContactsByDDDAsync(DDD))
                           .ReturnsAsync(contacts);

            // Act
            var result = await _contactService.GetContactsByDDDAsync(DDD);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Single(result.Data);
            Assert.Equal(11, result.Data[0].Phone.DDD);
        }

        [Fact]
        public async Task UpdateContactAsync_ShouldReturnFailure_WhenContactDoesNotExist()
        {
            // Arrange
            var inputModel = new CreateOrEditContactInputModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DDD = 11,
                Number = 987654321
            };

            _mockRepository.Setup(r => r.GetContactByIdAsync(inputModel.Id))
                           .ReturnsAsync((Contact)null);

            // Act
            var result = await _contactService.UpdateContactAsync(inputModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Contact not found", result.Message);
        }

        [Fact]
        public async Task UpdateContactAsync_ShouldReturnSuccess_WhenContactExists()
        {
            // Arrange
            var contactId = Guid.NewGuid();
            var existingContact = new Contact(new Name("John", "Doe"), new Email("john.doe@example.com"), new Phone(11, 987654321));

            var inputModel = new CreateOrEditContactInputModel
            {
                Id = contactId,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                DDD = 12,
                Number = 987654322
            };

            _mockRepository.Setup(r => r.GetContactByIdAsync(contactId))
                           .ReturnsAsync(existingContact);
            _mockRepository.Setup(r => r.UpdateContactAsync(It.IsAny<Contact>()))
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _contactService.UpdateContactAsync(inputModel);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepository.Verify(r => r.UpdateContactAsync(It.IsAny<Contact>()), Times.Once);
        }
    }
}

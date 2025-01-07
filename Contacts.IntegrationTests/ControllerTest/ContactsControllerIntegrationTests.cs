using System.Net;
using System.Net.Http.Json;
using Contacts.Application.Abstraction;
using Contacts.Application.Dtos;
using Contacts.Application.InputModels;
using Contacts.Application.Services;
using Contacts.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;

namespace Contacts.IntegrationTests.ControllerTest;

public class ContactsControllerIntegrationTests : IntegrationTestBase
{
    private readonly Mock<IContactService> _contactServiceMock;

    public ContactsControllerIntegrationTests(WebApplicationFactory<Program> factory)
        : base(factory)
    {
        _contactServiceMock = new Mock<IContactService>();
    }

    [Fact]
    public async Task GetAll_ReturnsOkWithData()
    {
        // Arrange
        var mockContacts = new List<ContactDto>
        {
            new ContactDto(Guid.NewGuid(), new Name("Macoratti", "Dev"), new Email("macoratti.dev@gmail.com"), new Phone(81, 123456789)),
            new ContactDto(Guid.NewGuid(), new Name("Danilo", "Aparecido"), new Email("danilo.aparecidoDev@hotmail.com"), new Phone(11, 987654321))
        };

        _contactServiceMock
            .Setup(service => service.GetContactsAsync())
            .ReturnsAsync(Result<List<ContactDto>>.Success(mockContacts));

        // Act
        var response = await Client.GetAsync("/api/v1/Contacts");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Contains("Macoratti", result);
        Assert.Contains("danilo.aparecidoDev@hotmail.com", result);
    }

    [Fact]
    public async Task GetById_ReturnsNotFoundForInvalidId()
    {
        // Arrange
        var invalidId = Guid.NewGuid();
        _contactServiceMock
            .Setup(service => service.GetContactByIdAsync(invalidId))
            .ReturnsAsync(Result<ContactDto>.Failure("Contact not found."));

        // Act
        var response = await Client.GetAsync($"/api/v1/Contacts/{invalidId}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByDdd_ReturnsOkWithContacts()
    {
        // Arrange
        var ddd = 81;
        var mockContacts = new List<ContactDto>
        {
            new ContactDto(Guid.NewGuid(), new Name("Macoratti", "Dev"), new Email("macoratti.dev@gmail.com"), new Phone(81, 123456789))
        };

        _contactServiceMock
            .Setup(service => service.GetContactsByDDDAsync(ddd))
            .ReturnsAsync(Result<List<ContactDto>>.Success(mockContacts));

        // Act
        var response = await Client.GetAsync($"/api/v1/Contacts/{ddd}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Contains("Macoratti", result);
    }

    [Fact]
    public async Task GetByDdd_ReturnsNotFoundForInvalidDdd()
    {
        // Arrange
        var invalidDdd = 99;
        _contactServiceMock
            .Setup(service => service.GetContactsByDDDAsync(invalidDdd))
            .ReturnsAsync(Result<List<ContactDto>>.Failure("No contacts found."));

        // Act
        var response = await Client.GetAsync($"/api/v1/Contacts/{invalidDdd}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Insert_ReturnsCreated()
    {
        // Arrange
        var newContact = new CreateOrEditContactInputModel
        {
            FirstName = "New",
            LastName = "Contact",
            Email = "new.contact@example.com",
            Number = 123456789,
            DDD = 11
        };

        _contactServiceMock
            .Setup(service => service.CreateContactAsync(newContact))
            .ReturnsAsync(Result.Success());

        // Act
        var response = await Client.PostAsJsonAsync("/api/v1/Contacts", newContact);
        
        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Insert_ReturnsBadRequestForInvalidData()
    {
        // Arrange
        var invalidContact = new CreateOrEditContactInputModel
        {
            FirstName = "",
            LastName = "",
            Email = "invalid-email",
            Number = 0,
            DDD = 0
        };

        _contactServiceMock
            .Setup(service => service.CreateContactAsync(invalidContact))
            .ReturnsAsync(Result.Failure("Invalid data."));

        // Act
        var response = await Client.PostAsJsonAsync("/api/v1/Contacts", invalidContact);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Delete_ReturnsNotFoundForInvalidId()
    {
        // Arrange
        var invalidId = Guid.NewGuid();

        _contactServiceMock
            .Setup(service => service.DeleteContactAsync(invalidId))
            .ReturnsAsync(Result.Failure("Contact not found."));

        // Act
        var response = await Client.DeleteAsync($"/api/v1/Contacts/{invalidId}");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
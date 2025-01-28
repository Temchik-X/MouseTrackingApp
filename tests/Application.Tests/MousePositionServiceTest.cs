using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Moq;
using System.Text.Json;

namespace Application.Tests;

public class MousePositionServiceTest
{
    [Fact]
    public async Task SaveAsync_ShouldSerializePositionsCorrectly()
    {
        // Arrange
        var mockRepo = new Mock<IMousePositionRepository>();
        var service = new MousePositionService(mockRepo.Object);

        var positions = new List<MousePositionDto>
    {
        new MousePositionDto(10, 20, "123456789")
    };

        var expectedData = JsonSerializer.Serialize(positions);

        // Act
        await service.SaveAsync(positions);

        // Assert
        mockRepo.Verify(r => r.AddAsync(It.Is<MousePosition>(p =>
            p.Data == expectedData &&
            p.CreatedAt <= DateTime.Now &&
            p.CreatedAt >= DateTime.Now.AddSeconds(-1)
        )), Times.Once);
    }
    [Fact]
    public async Task SaveAsync_ShouldSerializeMultiplePositionsCorrectly()
    {
        // Arrange
        var mockRepo = new Mock<IMousePositionRepository>();
        var service = new MousePositionService(mockRepo.Object);

        var positions = new List<MousePositionDto>
    {
        new MousePositionDto(10, 20, "123456789"),
        new MousePositionDto(30, 40, "987654321"),
        new MousePositionDto(50, 60, "987654321")
    };
        var expectedData = JsonSerializer.Serialize(positions);

        // Act
        await service.SaveAsync(positions);

        // Assert
        // Assert
        mockRepo.Verify(r => r.AddAsync(It.Is<MousePosition>(p =>
            p.Data == expectedData &&
            p.CreatedAt <= DateTime.Now &&
            p.CreatedAt >= DateTime.Now.AddSeconds(-1)
        )), Times.Once);
    }

    [Fact]
    public async Task SaveAsync_ShouldNotCallRepositoryAndThrowException_WhenListIsEmpty()
    {
        // Arrange
        var mockRepo = new Mock<IMousePositionRepository>();
        var service = new MousePositionService(mockRepo.Object);

        var emptyList = new List<MousePositionDto>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.SaveAsync(emptyList));

        Assert.Equal("The list of positions cannot be empty.", exception.Message);

        mockRepo.Verify(r => r.AddAsync(It.IsAny<MousePosition>()), Times.Never);
    }
}




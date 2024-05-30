using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RatePlate.Data;
using RatePlate.Dto;
using RatePlate.Models;
using RatePlate.Services;
using Moq;
using Xunit;

public class UserServicesTests2
{
    private Mock<DataContext> mockContext;
    private Mock<IMapper> mockMapper;
    private UserServices userServices;

    public UserServicesTests2()
    {
        mockContext = new Mock<DataContext>();
        mockMapper = new Mock<IMapper>();

        userServices = new UserServices(mockContext.Object, mockMapper.Object);
    }

    [Fact]
    public void AddUser_WithValidInput_ShouldAddUserAndReturnCorrectUserDto()
    {
        // Arrange
        var userSignupDto = new UserSignupDto { Username = "newUser", Password = "password", Redopassword = "password" };
        var expectedUserDto = new UserDto { Username = "newUser" };

        var users = new List<User>();
        mockContext.Setup(c => c.Users).ReturnsDbSet(users);
        mockContext.Setup(c => c.SaveChanges()).Verifiable();
        mockMapper.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(expectedUserDto);

        // Act
        var result = userServices.AddUser(userSignupDto);

        // Assert
        mockContext.Verify(c => c.Users.Add(It.IsAny<User>()), Times.Once);
        mockContext.Verify(c => c.SaveChanges(), Times.Once);
        mockMapper.Verify(m => m.Map<UserDto>(It.IsAny<User>()), Times.Once);
        Assert.Equal(expectedUserDto.Username, result.Username);
    }
}
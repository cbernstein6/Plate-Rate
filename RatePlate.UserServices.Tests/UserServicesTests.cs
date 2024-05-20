using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RatePlate.Data;
using RatePlate.Dto;
using RatePlate.Models;
using RatePlate.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq; 
using System.Linq.Expressions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;



[TestClass]
public class UserServicesTests
{
    private Mock<DbSet<User>> mockUsers;
    private Mock<DataContext> mockContext;
    private Mock<IMapper> mockMapper;
    private UserServices userServices;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUsers = new Mock<DbSet<User>>();
        mockContext = new Mock<DataContext>();
        mockMapper = new Mock<IMapper>();

        mockContext.Setup(c => c.Users).Returns(mockUsers.Object);

        userServices = new UserServices(mockContext.Object, mockMapper.Object);
    }

    [TestMethod]
    public void GetUser_ReturnsUserDto_WhenUserExists()
    {
        var userId = 1;
        var expectedUser = new User { UserId = userId, Username = "myUserName", HashedPassword = "myPassword", NumRatings = 0 };
        UserDto expectedUserDto = new UserDto { UserId = userId, Username = "myUserName", NumRatings = 0 };

        mockUsers.Setup(u => u.Find(It.IsAny<Expression<Func<User, bool>>>())).Returns(expectedUser);
        mockMapper.Setup(m => m.Map<UserDto>(expectedUser)).Returns(expectedUserDto);

        // Act
        var result = userServices.GetUser(userId);

        // Assert
        Assert.AreEqual(expectedUserDto.UserId, result.UserId);
        Assert.AreEqual(expectedUserDto.Username, result.Username);
        Assert.AreEqual(expectedUserDto.NumRatings, result.NumRatings);

    }
}
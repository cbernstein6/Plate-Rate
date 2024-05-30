using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RatePlate.Data;
using RatePlate.Dto;
using RatePlate.Models;
using RatePlate.Services;
using Moq; 
using System.Linq.Expressions;
using Xunit;

namespace RatePlate.UserServices.Tests
{
    public class RatingServicesTests
    {
        // private Mock<DbSet<Rating>> mockRatings;
        // private Mock<DataContext> mockContext;
        // private Mock<IMapper> mockMapper;
        // private RatingServices ratingServices;

        // public RatingServicesTests()
        // {
        //     mockRatings = new Mock<DbSet<Ratings>>();
        //     mockContext = new Mock<DataContext>();
        //     mockMapper = new Mock<IMapper>();

        //     mockContext.Setup(c => c.Ratings).Returns(mockRatings.Object);
        //     ratingServices = new UserServices(mockContext.Object, mockMapper.Object);
        // }

        // [Fact]
        // public async Task GetRatingByCollege_ReturnsRating_WhenValidInput()
        // {
        //     // assign
        //     var collegeId = 2;
        //     var expectedRating = new List<Rating> {new Rating { RatingId = 1, UserId = 1, HallId = 1, Taste = 1, Atmosphere = 1, Location = 1, Service = 1, Cleanliness = 1, Menu = 1, Price = 1 }, new Rating { RatingId = 2, UserId = 2, HallId = 2, Taste = 2, Atmosphere = 2}};
        //     var expectedRatingDto = new List<RatingDto> {new RatingDto { RatingId = 1, UserId = 1, HallId = 1, Taste = 1, Atmosphere = 1, Location = 1, Service = 1, Cleanliness = 1, Menu = 1, Price = 1 }, new RatingDto { RatingId = 2, UserId = 2, HallId = 2, Taste = 2, Atmosphere = 2}};

        //     mockRatings.Setup(r => r.Where(r => r.RatingId == collegeId)).Returns(expectedRating);
        //     mockMapper.Setup(m => m.Map<RatingDto>(expectedRating)).Returns(expectedRatingDto);

        //     // act
        //     var result = await ratingServices.GetRatingByCollege(collegeId);

        //     // assert
        //     Assert.Equal(expectedRatingDto.RatingId, result.RatingId);
        //     Assert.Equal(expectedRatingDto.UserId, result.UserId);
        //     Assert.Equal(expectedRatingDto.HallId, result.HallId);
        //     Assert.Equal(expectedRatingDto.Taste, result.Taste);
        //     Assert.Equal(expectedRatingDto.Atmosphere, result.Atmosphere);
        //     Assert.Equal(expectedRatingDto.Location, result.Location);
        //     Assert.Equal(expectedRatingDto.Service, result.Service);
        //     Assert.Equal(expectedRatingDto.Cleanliness, result.Cleanliness);
        //     Assert.Equal(expectedRatingDto.Menu, result.Menu);
        //     Assert.Equal(expectedRatingDto.Price, result.Price);
        // }
    }
}
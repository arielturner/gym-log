using GymLog.BLL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.BLL.UnitTests.Services
{
    [TestClass]
    public class BodyPartsServiceTests
    {
        private GymLogContext _context;
        private BodyPartsService _service;
        private Mock<IMemoryCache> _mockCache;

        [TestInitialize]
        public void Setup()
        {
            // Configure the in-memory database
            var options = new DbContextOptionsBuilder<GymLogContext>()
                .UseInMemoryDatabase(databaseName: "GymLogTestDb")
                .Options;

            _context = new GymLogContext(options);

            // Seed the database with test data
            _context.BodyParts.Add(new BodyPart { BodyPartId = 1, BodyPartName = "Chest", CreatedBy = "Unit test", UpdatedBy = "Unit test" });
            _context.BodyParts.Add(new BodyPart { BodyPartId = 2, BodyPartName = "Back", CreatedBy = "Unit test", UpdatedBy = "Unit test" });
            _context.SaveChanges();

            // Mock the memory cache
            _mockCache = new Mock<IMemoryCache>();
            var cacheEntry = Mock.Of<ICacheEntry>();
            _mockCache.Setup(x => x.CreateEntry(It.IsAny<string>())).Returns(cacheEntry);

            // Initialize the service
            _service = new BodyPartsService(_context, _mockCache.Object);
        }

        [TestMethod]
        public async Task GetAllBodyParts_ShouldReturnAllBodyParts()
        {
            // Act
            var result = await _service.GetAllBodyPartsAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetBodyPartById_ShouldReturnCorrectBodyPart()
        {
            // Act
            var result = await _service.GetBodyPartByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Chest", result.BodyPartName);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Body part with id 3 not found.")]
        public async Task GetBodyPartById_ShouldThrowExceptionForBodyPartNotFound()
        {
            // Act
            var result = await _service.GetBodyPartByIdAsync(3);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
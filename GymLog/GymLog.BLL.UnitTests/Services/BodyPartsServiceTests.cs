using GymLog.BLL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            // Initialize the service
            _service = new BodyPartsService(_context);
        }

        [TestMethod]
        public void GetAllBodyParts_ShouldReturnAllBodyParts()
        {
            // Act
            var result = _service.GetAllBodyParts();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetBodyPartById_ShouldReturnCorrectBodyPart()
        {
            // Act
            var result = _service.GetBodyPartById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Chest", result.BodyPartName);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Body part with id 3 not found.")]
        public void GetBodyPartById_ShouldThrowExceptionForBodyPartNotFound()
        {
            // Act
            var result = _service.GetBodyPartById(3);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
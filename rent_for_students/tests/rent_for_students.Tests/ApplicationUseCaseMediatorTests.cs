using rent_for_students.Application.Common;
using rent_for_students.Application.UseCases;
using rent_for_students.Domain.Entities;
using rent_for_students.Domain.Services;
using rent_for_students.Tests.TestDoubles;

namespace rent_for_students.Tests
{
    public class ApplicationUseCaseMediatorTests
    {
        [Fact]
        public async Task ApplyAsync_ActiveListing_CreatesApprovedApplication()
        {
            var housingRepo = new InMemoryHousingRepository();
            var appRepo = new InMemoryRentalApplicationRepository();
            var notifications = new TestNotificationService();
            var housingService = new HousingService(housingRepo);

            var listing = new HousingListing
            {
                Id = Guid.NewGuid(),
                Title = "Listing A",
                City = "Kyiv",
                PricePerMonth = 1000,
                RoomType = RoomType.Studio,
                AreaSqm = 30,
                IsActive = true
            };
            await housingRepo.AddAsync(listing);

            var sut = new ApplicationUseCaseMediator(housingService, appRepo, notifications);

            var applicant = new RentalApplication
            {
                ApplicantName = "John Doe",
                Phone = "+380501234567",
                Email = "john@example.com"
            };

            var result = await sut.ApplyAsync(listing.Id, applicant);

            Assert.True(result.IsSuccess);
            var applicationId = result.Value;
            Assert.NotEqual(Guid.Empty, applicationId);

            var saved = await appRepo.GetByIdAsync(applicationId);
            Assert.NotNull(saved);
            Assert.Equal(ApplicationStatus.Approved, saved!.Status);
            Assert.Contains(notifications.Messages, m => m.Contains("Rental application created"));
        }

        [Fact]
        public async Task ApplyAsync_InactiveListing_ReturnsListingNotAvailable()
        {
            var housingRepo = new InMemoryHousingRepository();
            var appRepo = new InMemoryRentalApplicationRepository();
            var notifications = new TestNotificationService();
            var housingService = new HousingService(housingRepo);

            var listing = new HousingListing
            {
                Id = Guid.NewGuid(),
                Title = "Listing B",
                City = "Lviv",
                PricePerMonth = 850,
                RoomType = RoomType.OneBedroom,
                AreaSqm = 35,
                IsActive = false
            };
            await housingRepo.AddAsync(listing);

            var sut = new ApplicationUseCaseMediator(housingService, appRepo, notifications);

            var applicant = new RentalApplication
            {
                ApplicantName = "Jane Doe",
                Phone = "+380509999999",
                Email = "jane@example.com"
            };

            var result = await sut.ApplyAsync(listing.Id, applicant);

            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorCodes.ListingNotAvailable, result.ErrorCode);
        }
    }
}

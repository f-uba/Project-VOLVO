using Application.Commands;
using Application.Handlers;
using Application.Interfaces;
using Application.Mapper;
using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Enums;
using FluentAssertions;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace xUnitTests
{
    public sealed class CommandHandlersUnitTest
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public DbContextOptions<AppDbContext> contextOptions { get; }

        public CommandHandlersUnitTest()
        {
            contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=:memory:")
                .Options;

            var context = new AppDbContext(contextOptions);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            _mapper = config.CreateMapper();

            _uof = new UnitOfWork(context);

            DBUnitTestsMockInitializer db = new(context);
            db.Seed();
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenGetVehiclesList()
        {
            // Arrange
            var command = new GetVehiclesCommand();
            var handler = new GetVehiclesCommandHandler(_uof, _mapper);

            // Act
            ICollection<VehicleDto>? result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenGetVehicleById()
        {
            // Arrange
            var command = new GetVehicleBySeriesNumberCommand
            {
                Series = "B",
                Number = 2
            };
            var handler = new GetVehicleBySeriesNumberCommandHandler(_uof, _mapper);

            // Act
            VehicleDto? result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenGetVehicleById()
        {
            // Arrange
            var command = new GetVehicleBySeriesNumberCommand
            {
                Series = "B",
                Number = 0
            };
            var handler = new GetVehicleBySeriesNumberCommandHandler(_uof, _mapper);

            // Act
            VehicleDto? result = await handler.Handle(command, default);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResult_WhenCreateVehicle()
        {
            // Arrange
            var command = new CreateVehicleCommand
            {
                Color = "Yellow",
                Type = EnumVehicleType.Car,
                Series = "C",
                Number = 1
            };
            var handler = new CreateVehicleCommandHandler(_uof, _mapper);

            // Act
            VehicleDto? result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.NumberOfPassengers.Should().Be(4);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenCreateVehicle()
        {
            // Arrange
            var command = new CreateVehicleCommand
            {
                Color = "Yellow",
                Type = EnumVehicleType.Car,
                Series = "A",
                Number = 3
            };
            var handler = new CreateVehicleCommandHandler(_uof, _mapper);

            // Act
            Func<Task> act = async () => await handler.Handle(command, default);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenUpdateVehicle()
        {
            // Arrange
            var command = new UpdateVehicleCommand
            {
                Color = "Pink",
                Series = "D",
                Number = 2
            };
            var handler = new UpdateVehicleCommandHandler(_uof, _mapper);

            // Act
            VehicleDto? result = await handler.Handle(command, default);

            // Assert
            result.Should().BeNull();
        }
    }
}

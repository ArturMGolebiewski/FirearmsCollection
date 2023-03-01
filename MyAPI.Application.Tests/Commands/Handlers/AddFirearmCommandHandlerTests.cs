using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentResults;
using Moq;
using MyAPI.Application.Commands;
using MyAPI.Application.Commands.Handlers;
using MyAPI.Domain.Firearm.Entities;
using MyAPI.Infrastructure.Firearms;

namespace MyAPI.Application.Tests.Commands.Handlers;

[TestFixture]
public sealed class AddFirearmCommandHandlerTests
{
    private AddFirearmCommandHandler _addFirearmCommandHandler;
    private Mock<INewFirearmWriter> _firearmWriter;
    private Mock<IMapper> _mapper;
    private Mock<IFirearmsReader> _firearmsReader;

    [SetUp]
    public void Setup()
    {
        _firearmWriter = new Mock<INewFirearmWriter>();
        _mapper = new Mock<IMapper>();
        _firearmsReader = new Mock<IFirearmsReader>();
        _addFirearmCommandHandler = new AddFirearmCommandHandler(
            _firearmWriter.Object, _mapper.Object, _firearmsReader.Object);
    }

    [Test]
    public async Task Handle_Success_ReturnsOk()
    {
        var fixture = new Fixture();
        var request = fixture.Create<AddFirearmCommand>();
        var nameUnique = Result.Ok();
        var newFirearm = fixture.Create<Firearm>();

        _firearmsReader.Setup(x => x.CheckIfFirearmNameUnique(request.FirearmModelName))
            .ReturnsAsync(nameUnique).Verifiable();
        _mapper.Setup(x => x.Map<Firearm>(request)).Returns(newFirearm).Verifiable();
        _firearmWriter.Setup(x => x.WriteFirearmAsync(newFirearm, default)).ReturnsAsync(Result.Ok()).Verifiable();

        var testResult = await _addFirearmCommandHandler.Handle(request, default);

        testResult.IsSuccess.Should().BeTrue();
        Mock.Verify(_firearmsReader, _mapper, _firearmWriter);
    }

    [Test]
    public async Task Handle_CheckUniqueFail_ReturnsFail()
    {
        var fixture = new Fixture();
        var request = fixture.Create<AddFirearmCommand>();
        var nameUnique = Result.Fail("");
        var newFirearm = fixture.Create<Firearm>();

        _firearmsReader.Setup(x => x.CheckIfFirearmNameUnique(request.FirearmModelName))
            .ReturnsAsync(nameUnique).Verifiable();
        _mapper.Setup(x => x.Map<Firearm>(It.IsAny<AddFirearmCommand>())).Verifiable();
        _firearmWriter.Setup(x => x.WriteFirearmAsync(It.IsAny<Firearm>(), It.IsAny<CancellationToken>())).Verifiable();

        var testResult = await _addFirearmCommandHandler.Handle(request, default);

        testResult.IsSuccess.Should().BeFalse();
        _firearmsReader.Verify(x => x.CheckIfFirearmNameUnique(request.FirearmModelName), Times.Once);
        _firearmWriter.Verify(x => x.WriteFirearmAsync(It.IsAny<Firearm>(), It.IsAny<CancellationToken>()), Times.Never);
        _mapper.Verify(x => x.Map<Firearm>(It.IsAny<AddFirearmCommand>()), Times.Never);
    }

    [Test]
    public async Task Handle_CheckWriteFail_ReturnsFail()
    {
        var fixture = new Fixture();
        var request = fixture.Create<AddFirearmCommand>();
        var nameUnique = Result.Ok();
        var newFirearm = fixture.Create<Firearm>();

        _firearmsReader.Setup(x => x.CheckIfFirearmNameUnique(request.FirearmModelName))
            .ReturnsAsync(nameUnique).Verifiable();
        _mapper.Setup(x => x.Map<Firearm>(request)).Returns(newFirearm).Verifiable();
        _firearmWriter.Setup(x => x.WriteFirearmAsync(newFirearm, default)).ReturnsAsync(Result.Fail("")).Verifiable();

        var testResult = await _addFirearmCommandHandler.Handle(request, default);

        testResult.IsSuccess.Should().BeFalse();
        Mock.Verify(_firearmsReader, _firearmWriter, _mapper);
    }
}

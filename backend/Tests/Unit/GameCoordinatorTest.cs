using Application;
using Moq;
using Xunit;

namespace Tests;

public class GameCoordinatorTest
{
    private readonly Mock<IGameBridgeFactory> mockFactory;
    private readonly IGameCoordinator model;
    public GameCoordinatorTest()
    {
        mockFactory = new Mock<IGameBridgeFactory>();    
        model = new GameCoordinator(mockFactory.Object);
    }
    [Fact]
    public void Assing_Create_And_Returns_Bridge()
    {
        // Given
        var user = UserGenerator.Create();
        var mockBridge = new Mock<IGameBridge>();
        
        mockFactory.Setup(m => m.Create())
            .Returns(mockBridge.Object)
            .Verifiable();

        // When
        var bridge = model.Assign(user);
        
        // Then
        Assert.NotNull(bridge);
        Assert.Equal(bridge, mockBridge.Object);
        mockFactory.Verify();
    }

    [Fact]
    public void Get_Returns_Null_If_Not_Assigned()
    {
        var user = UserGenerator.Create();

        var bridge = model.Get(user);

        Assert.Null(bridge);
    }

    [Fact]
    public void Get_Returns_Bridge_If_Assigned()
    {
        // Given
        var user = UserGenerator.Create();
        
        mockFactory.Setup(m => m.Create())
            .Returns(Mock.Of<IGameBridge>());

        var assignedBridge = model.Assign(user);

        // When
        var bridge = model.Get(user);
        
        // Then
        Assert.Equal(assignedBridge, bridge);
    }

    [Fact]
    public void Get_Returns_Null_After_Drop()
    {
        // Given
        var user = UserGenerator.Create();

        mockFactory.Setup(m => m.Create())
            .Returns(Mock.Of<IGameBridge>());

        model.Assign(user);
        Assert.NotNull(model.Get(user));

        // When
        model.Drop(user);
        var bridge = model.Get(user);

        // Then
        Assert.Null(bridge);
    }
}
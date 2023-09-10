using System.Text.Json;
using Application;
using Xunit;

namespace Tests;

public class GameActionConverterTest
{
    private const string MOCK_KEY = "custom-type";

    [Fact]
    public void ShouldConvertSimpleAction()
    {
        // Given
        var expectedString = "string-value";
        var expectedInt = 7;

        var json = $$$"""
        {
            "$type": "{{{MOCK_KEY}}}",
            "action": {
                "{{{nameof(MockAction.StringProperty)}}}": "{{{expectedString}}}",
                "{{{nameof(MockAction.IntProperty)}}}": {{{expectedInt}}}
            }
        }
        """;

        // When
        var result = JsonSerializer.Deserialize<GameAction>(json, CreateOptions());

        // Then
        Assert.NotNull(result);
        Assert.IsType(typeof(MockAction), result);
        var action = (MockAction) result;
        Assert.Equal(expectedString, action.StringProperty);
        Assert.Equal(expectedInt, action.IntProperty);
    }

    private JsonSerializerOptions CreateOptions()
    {
        var dict = new Dictionary<string, Type>()
        {
            [MOCK_KEY] = typeof(MockAction),
        };

        var converter = new GameActionJsonConverter(dict);
        var options = new JsonSerializerOptions();
        options.Converters.Add(converter);
        return options;
    }

    private class MockBridge : IGameBridge
    {
        public Guid Id => Guid.Empty;
        public bool CanJoin => false;
        public bool IsEmpty => false;

        public object GetState() { return new {}; }
        public void Join(User user) { }
        public void Remove(User user) { }
    }

    private class MockAction : GameAction<MockBridge>
    {
        public string StringProperty { get; set; } = string.Empty;
        public int IntProperty { get; set; }
        public override void Execute(User user, MockBridge target) { }
    }
}
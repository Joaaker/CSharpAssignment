using Shared.Helpers;


namespace Shared.Tests.Helpers;

public class UniqueIdentifierGenerator_Tests
{
    [Fact]

    public void Generate_ShouldReturnStringOfTypeGuid()
    {
        //act
        string id = UniqueIdentifierGenerator.Generate();

        //Assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.Equal(8, id.Length);
        Assert.Matches("^[0-9A-Fa-f]{8}$", id);
    }
}
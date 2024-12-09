using Shared.Helpers;


namespace Shared.Tests.Helpers;

public class UniqueIdentifierGenerator_Tests
{
    [Fact]

    public void Generate_ShouldReturnStringOfTypeGuid()
    {
        //act
        string id = UniqueIdentifierGenerator.Generate();

    }
}

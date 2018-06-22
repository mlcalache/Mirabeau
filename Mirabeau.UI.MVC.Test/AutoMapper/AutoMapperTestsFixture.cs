using Xunit;

namespace Mirabeau.UI.MVC.Tests.AutoMapper
{
    [CollectionDefinition(nameof(AutoMapperCollection))]
    public class AutoMapperCollection : ICollectionFixture<AutoMapperTestsFixture>
    {
    }

    public class AutoMapperTestsFixture { }
}
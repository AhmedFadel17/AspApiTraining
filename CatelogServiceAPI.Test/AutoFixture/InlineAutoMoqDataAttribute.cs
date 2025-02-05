using AutoFixture.Xunit2;
using CatelogServiceAPI.Test.AutoFixture;

namespace CatalogServiceApi.Test.AutoFixture
{
    public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] objects) : base(new AutoMoqDataAttribute(), objects) { }
    }
}

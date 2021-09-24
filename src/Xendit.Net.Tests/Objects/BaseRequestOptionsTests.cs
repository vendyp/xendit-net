using System.Linq;
using Xunit;

namespace Xendit.Net.Tests.Objects
{
    public class BaseRequestOptionsTests
    {
        [Fact]
        public void BaseRequestOptions_Ctor_Ok()
        {
            new BaseRequestOptions();
        }

        [Fact]
        public void BaseRequestOptions_Set_Queries()
        {
            var options = new BaseRequestOptions();

            options.AddQueryParams("test", "test123");

            Assert.Equal("test123", options.Queries.FirstOrDefault(x => x.Key == "test").Value);
        }

        [Fact]
        public void BaseRequestOptions_Set_Headers()
        {
            var options = new BaseRequestOptions();

            options.AddHeaderParams("test", "test123");

            Assert.Equal("test123", options.Headers.FirstOrDefault(x => x.Key == "test").Value);
        }

        [Fact]
        public void BaseRequestOptions_Set_Headers_Will_Replaced_When_Passed_Same_Key()
        {
            var options = new BaseRequestOptions();

            options.AddHeaderParams("test", "test123");
            options.AddHeaderParams("test", "test1234");

            Assert.Equal("test1234", options.Headers.FirstOrDefault(x => x.Key == "test").Value);
        }

        [Fact]
        public void BaseRequestOptions_Set_Headers_Count_Still_One_When_Same_Key_Being_Inputted()
        {
            var options = new BaseRequestOptions();

            options.AddHeaderParams("test", "test123");
            options.AddHeaderParams("test", "test1234");

            Assert.Equal(1, options.Headers.Count);
        }
    }
}

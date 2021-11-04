using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Clients.Queries.GetClientDetails;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Clients.Queries
{
    [Collection("QueryCollection")]
    public class GetClientDetailsQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetClientDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetClientDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetClientDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetClientDetailsQuery 
            { 
                Id = YogaStudioContextFactory.UserBId 
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ClientDetailsVm>();
            result.FirstName.ShouldBe("FirstName2");
            result.LastName.ShouldBe("LastName2");
            result.PhoneNumber.ShouldBe("PhoneNumber2");
        }
    }
}

using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionsList;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Subscriptions.Queries
{
    [Collection("QueryCollection")]
    public class GetSubscriptionsListQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetSubscriptionsListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetSubscriptionsListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetSubscriptionsListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetSubscriptionsListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<SubscriptionsListVm>();
            result.Subscriptions.Count.ShouldBe(2);
        }
    }
}

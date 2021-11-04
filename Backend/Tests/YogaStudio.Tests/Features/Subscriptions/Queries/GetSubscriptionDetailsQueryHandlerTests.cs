using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionDetails;
using YogaStudio.Domain.Enums;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Subscriptions.Queries
{
    [Collection("QueryCollection")]
    public class GetSubscriptionDetailsQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetSubscriptionDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetSubscriptionDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetSubscriptionDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetSubscriptionDetailsQuery
            {
                Id = YogaStudioContextFactory.ItemIdForUpdate
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<SubscriptionDetailsVm>();
            result.ClientId.ShouldBe(YogaStudioContextFactory.UserBId);
            result.Status.ShouldBe(SubscriptionStatus.Expired);
            result.NumberOfClasses.ShouldBe(0);
        }
    }
}

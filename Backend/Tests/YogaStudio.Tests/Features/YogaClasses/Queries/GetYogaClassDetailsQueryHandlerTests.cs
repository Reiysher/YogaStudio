using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassDetails;
using YogaStudio.Domain.Enums;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.YogaClasses.Queries
{
    [Collection("QueryCollection")]
    public class GetYogaClassDetailsQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetYogaClassDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetYogaClassDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetYogaClassDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetYogaClassDetailsQuery
            {
                Id = YogaStudioContextFactory.ItemIdForUpdate
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<YogaClassDetailsVm>();
            result.MentorId.ShouldBe(YogaStudioContextFactory.UserBId);
            result.Status.ShouldBe(YogaClassStatus.Finished);
            result.MaxClients.ShouldBe(12);
        }
    }
}

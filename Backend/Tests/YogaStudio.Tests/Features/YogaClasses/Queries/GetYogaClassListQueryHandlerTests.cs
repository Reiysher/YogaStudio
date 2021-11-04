using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassList;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.YogaClasses.Queries
{
    [Collection("QueryCollection")]
    public class GetYogaClassListQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetYogaClassListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetSubscriptionsListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetYogaClassListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetYogaClassListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<YogaClassListVm>();
            result.Classes.Count.ShouldBe(2);
        }
    }
}

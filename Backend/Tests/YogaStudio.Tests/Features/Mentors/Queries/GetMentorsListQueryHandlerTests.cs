using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Mentors.Queries.GetMentorsList;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Mentors.Queries
{
    [Collection("QueryCollection")]
    public class GetMentorsListQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetMentorsListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMentorsListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetMentorsListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetMentorsListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<MentorsListVm>();
            result.Mentors.Count.ShouldBe(3); // +1 in DbContext initialize
        }
    }
}

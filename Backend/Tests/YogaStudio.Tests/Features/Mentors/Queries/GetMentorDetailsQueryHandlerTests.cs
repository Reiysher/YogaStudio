using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Mentors.Queries.GetMentorDetails;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Mentors.Queries
{
    [Collection("QueryCollection")]
    public class GetMentorDetailsQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetMentorDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMentorDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetMentorDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetMentorDetailsQuery
            {
                Id = YogaStudioContextFactory.UserBId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<MentorDetailsVm>();
            result.FirstName.ShouldBe("FirstName2");
            result.LastName.ShouldBe("LastName2");
            result.PhoneNumber.ShouldBe("PhoneNumber2");
        }
    }
}

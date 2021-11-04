using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Clients.Queries.GetClientsList;
using YogaStudio.Persistence;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Clients.Queries
{
    [Collection("QueryCollection")]
    public class GetClientsListQueryHandlerTests
    {
        private readonly YogaStudioDbContext Context;
        private readonly IMapper Mapper;

        public GetClientsListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetClientsListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetClientsListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetClientsListQuery(), 
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ClientsListVm>();
            result.Clients.Count.ShouldBe(2);
        }
    }
}

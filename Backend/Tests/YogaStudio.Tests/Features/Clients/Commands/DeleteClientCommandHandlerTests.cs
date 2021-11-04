using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.Clients.Commands.DeleteClient;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Clients.Commands
{
    public class DeleteClientCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteClientCommand_Success()
        {
            // Arrange
            var handler = new DeleteClientCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteClientCommand
            {
                Id = YogaStudioContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Clients.SingleOrDefault(client =>
            client.Id == YogaStudioContextFactory.UserAId));
        }

        [Fact]
        public async Task DeleteClientCommand_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteClientCommandHandler(Context);
            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteClientCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

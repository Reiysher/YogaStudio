using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.Subscriptions.Commands.DeleteSubscription;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Subscriptions.Commands
{
    public class DeleteSubscriptionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteClientCommand_Success()
        {
            // Arrange
            var handler = new DeleteSubscriptionCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteSubscriptionCommand
            {
                Id = YogaStudioContextFactory.ItemIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Subscriptions.SingleOrDefault(subscription =>
            subscription.Id == YogaStudioContextFactory.ItemIdForDelete));
        }

        [Fact]
        public async Task DeleteSubscriptionCommand_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteSubscriptionCommandHandler(Context);
            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteSubscriptionCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

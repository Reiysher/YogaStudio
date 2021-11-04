using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.Subscriptions.Commands.UpdateSubscription;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Subscriptions.Commands
{
    public class UpdateSubscriptionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateSubscriptionCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateSubscriptionCommandHandler(Context);
            var numberOfClasses = 20;
            var updatedClasses = new List<YogaClass> { new YogaClass() };

            // Act
            await handler.Handle(new UpdateSubscriptionCommand
            {
                Id = YogaStudioContextFactory.ItemIdForUpdate,
                ClientId = YogaStudioContextFactory.UserBId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),
                NumberOfClasses = numberOfClasses,
                Type = SubscriptionType.Offline,
                Status = SubscriptionStatus.Expired,
                Classes = updatedClasses
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Subscriptions.SingleOrDefaultAsync(subscription =>
            subscription.Id == YogaStudioContextFactory.ItemIdForUpdate &&
            subscription.ClientId == YogaStudioContextFactory.UserBId &&
            subscription.Type == SubscriptionType.Offline &&
            subscription.Status == SubscriptionStatus.Expired &&
            subscription.Classes.Any()));
        }

        [Fact]
        public async Task UpdateSubscriptionCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateSubscriptionCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateSubscriptionCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

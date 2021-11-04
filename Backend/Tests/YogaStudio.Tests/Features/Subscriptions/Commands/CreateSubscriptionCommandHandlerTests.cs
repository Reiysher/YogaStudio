using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Subscriptions.Commands.CreateSubscription;
using YogaStudio.Domain.Enums;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Subscriptions.Commands
{
    public class CreateSubscriptionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateSubscriptionCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateSubscriptionCommandHandler(Context);
            var numberOfClasses = 20;

            // Act
            var subscriptionId = await handler.Handle(
                new CreateSubscriptionCommand
                {
                    Id = Guid.NewGuid(),
                    ClientId = YogaStudioContextFactory.UserAId,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    NumberOfClasses = numberOfClasses,
                    Type = SubscriptionType.Online
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Subscriptions.SingleOrDefaultAsync(subscription =>
                subscription.Id == subscriptionId &&
                subscription.ClientId == YogaStudioContextFactory.UserAId &&
                subscription.NumberOfClasses == numberOfClasses &&
                subscription.Type == SubscriptionType.Online &&
                subscription.Status == SubscriptionStatus.Active &&
                subscription.Classes.Count() == 0));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.Clients.Commands.UpdateClient;
using YogaStudio.Domain;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Clients.Commands
{
    public class UpdateClientCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateClientCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateClientCommandHandler(Context);
            var updatedFirstName = "Updated FirstName";
            var updatedLastName = "Updated LastName";
            var updatedPhoneNumber = "Updated PhoneNumber";
            var updatedSubscriptions = new List<Subscription> { new Subscription() };

            // Act
            await handler.Handle(new UpdateClientCommand
            {
                Id = YogaStudioContextFactory.UserAId,
                FirstName = updatedFirstName,
                LastName = updatedLastName,
                PhoneNumber = updatedPhoneNumber,
                Subscriptions = updatedSubscriptions
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Clients.SingleOrDefaultAsync(client =>
            client.Id == YogaStudioContextFactory.UserAId &&
            client.FirstName == updatedFirstName &&
            client.LastName == updatedLastName &&
            client.PhoneNumber == updatedPhoneNumber &&
            client.Subscriptions.Any()));
        }

        [Fact]
        public async Task UpdateClientCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateClientCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateClientCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

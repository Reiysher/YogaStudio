using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Clients.Commands.CreateClient;
using YogaStudio.Domain;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Clients.Commands
{
    public class CreateClientCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateClientCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateClientCommandHandler(Context);
            var firstName = "fistName";
            var lastName = "lastName";
            var phoneNumber = "+79858598585";

            // Act
            var userId = await handler.Handle(
                new CreateClientCommand
                {
                    Id = YogaStudioContextFactory.UserAId,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Clients.SingleOrDefaultAsync(client =>
                client.Id == userId &&
                client.FirstName == firstName &&
                client.LastName == lastName &&
                client.PhoneNumber == phoneNumber &&
                client.Subscriptions.Count() == 0));
        }
    }
}

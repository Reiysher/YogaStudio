using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.YogaClasses.Commands.UpdateYogaClass;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.YogaClasses.Commands
{
    public class UpdateYogaClassCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateYogaClassCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateYogaClassCommandHandler(Context);
            var minClients = 3;
            var maxClients = 12;
            var title = "Title";
            var description = "Description";

            // Act
            await handler.Handle(new UpdateYogaClassCommand
            {
                Id = YogaStudioContextFactory.ItemIdForUpdate,
                MentorId = YogaStudioContextFactory.UserBId,
                Title = title,
                Date = DateTime.Now,
                Description = description,
                MinClients = minClients,
                MaxClients = maxClients,
                Type = YogaClassType.Online,
                Status = YogaClassStatus.Finished,
                Subscriptions = new List<Subscription> { new Subscription() }
            }, CancellationToken.None); ;

            // Assert
            Assert.NotNull(await Context.Classes.SingleOrDefaultAsync(yogaClass =>
            yogaClass.Id == YogaStudioContextFactory.ItemIdForUpdate &&
            yogaClass.MentorId == YogaStudioContextFactory.UserBId &&
            yogaClass.Title == title &&
            yogaClass.Description == description &&
            yogaClass.MinClients == minClients &&
            yogaClass.MaxClients == maxClients &&
            yogaClass.Type == YogaClassType.Online &&
            yogaClass.Status == YogaClassStatus.Finished &&
            yogaClass.Subscriptions.Any()));
        }

        [Fact]
        public async Task UpdateYogaClassCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateYogaClassCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateYogaClassCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

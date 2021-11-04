using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.YogaClasses.Commands.CreateYogaClass;
using YogaStudio.Domain.Enums;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.YogaClasses.Commands
{
    public class CreateYogaClassCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateYogaClassCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateYogaClassCommandHandler(Context);
            var minClients = 3;
            var maxClients = 12;
            var title = "Title";
            var description = "Description";

            // Act
            var yogaClassId = await handler.Handle(
                new CreateYogaClassCommand
                {
                    MentorId = YogaStudioContextFactory.UserAId,
                    Title = title,
                    Date = DateTime.Now,
                    Description = description,
                    MinClients = minClients,
                    MaxClients = maxClients,
                    Type = YogaClassType.Online
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Classes.SingleOrDefaultAsync(yogaClass =>
                yogaClass.Id == yogaClassId &&
                yogaClass.MentorId == YogaStudioContextFactory.UserAId &&
                yogaClass.MinClients == minClients &&
                yogaClass.MaxClients == maxClients &&
                yogaClass.Title == title &&
                yogaClass.Description == description &&
                yogaClass.Subscriptions.Count() == 0));
        }
    }
}

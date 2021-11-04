using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.Mentors.Commands.UpdateMentor;
using YogaStudio.Domain;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Mentors.Commands
{
    public class UpdateMentorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateMentorCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateMentorCommandHandler(Context);
            var updatedFirstName = "Updated FirstName";
            var updatedLastName = "Updated LastName";
            var updatedPhoneNumber = "Updated PhoneNumber";
            var updatedClasses = new List<YogaClass> { new YogaClass() };

            // Act
            await handler.Handle(new UpdateMentorCommand
            {
                Id = YogaStudioContextFactory.UserAId,
                FirstName = updatedFirstName,
                LastName = updatedLastName,
                PhoneNumber = updatedPhoneNumber,
                Classes = updatedClasses
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Mentors.SingleOrDefaultAsync(mentor =>
            mentor.Id == YogaStudioContextFactory.UserAId &&
            mentor.FirstName == updatedFirstName &&
            mentor.LastName == updatedLastName &&
            mentor.PhoneNumber == updatedPhoneNumber &&
            mentor.Classes.Any()));
        }

        [Fact]
        public async Task UpdateMentorCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateMentorCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new UpdateMentorCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

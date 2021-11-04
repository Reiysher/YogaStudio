using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.Mentors.Commands.DeleteMentor;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Mentors.Commands
{
    public class DeleteMentorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteMentorCommand_Success()
        {
            // Arrange
            var handler = new DeleteMentorCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteMentorCommand
            {
                Id = YogaStudioContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Mentors.SingleOrDefault(mentor =>
            mentor.Id == YogaStudioContextFactory.UserAId));
        }

        [Fact]
        public async Task DeleteMentorCommand_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteMentorCommandHandler(Context);
            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteMentorCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

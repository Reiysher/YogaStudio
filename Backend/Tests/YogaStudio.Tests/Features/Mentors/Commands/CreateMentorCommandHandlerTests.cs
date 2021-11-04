using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Features.Mentors.Commands.CreateMentor;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.Mentors.Commands
{
    public class CreateMentorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateMentorCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateMentorCommandHandler(Context);
            var firstName = "fistName";
            var lastName = "lastName";
            var phoneNumber = "+79858598585";

            // Act
            var mentorId = await handler.Handle(
                new CreateMentorCommand
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Mentors.SingleOrDefaultAsync(mentor =>
                mentor.Id == mentorId &&
                mentor.FirstName == firstName &&
                mentor.LastName == lastName &&
                mentor.PhoneNumber == phoneNumber &&
                mentor.Classes.Count() == 0));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Features.YogaClasses.Commands.DeleteYogaClass;
using YogaStudio.Tests.Common;

namespace YogaStudio.Tests.Features.YogaClasses.Commands
{
    public class DeleteYogaClassCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteClientCommand_Success()
        {
            // Arrange
            var handler = new DeleteYogaClassCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteYogaClassCommand
            {
                Id = YogaStudioContextFactory.ItemIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Classes.SingleOrDefault(yogaClass =>
            yogaClass.Id == YogaStudioContextFactory.ItemIdForDelete));
        }

        [Fact]
        public async Task DeleteYogaClassCommand_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteYogaClassCommandHandler(Context);
            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new DeleteYogaClassCommand
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None));
        }
    }
}

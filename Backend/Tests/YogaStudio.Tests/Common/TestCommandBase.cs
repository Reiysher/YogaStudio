using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Persistence;

namespace YogaStudio.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly YogaStudioDbContext Context;

        public TestCommandBase()
        {
            Context = YogaStudioContextFactory.Create();
        }

        public void Dispose()
        {
            YogaStudioContextFactory.Destroy(Context);
        }
    }
}

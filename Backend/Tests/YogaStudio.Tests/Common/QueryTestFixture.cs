using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YogaStudio.Application.Common.Mappings;
using YogaStudio.Application.Interfaces;
using YogaStudio.Persistence;

namespace YogaStudio.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public YogaStudioDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = YogaStudioContextFactory.Create();
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile(typeof(IYogaStudioDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            YogaStudioContextFactory.Destroy(Context);
        }
    }
    
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { } 
}

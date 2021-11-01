using System.Collections.Generic;

namespace YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassList
{
    public class YogaClassListVm
    {
        // TODO: Or List, IList, ICollection?
        public IList<YogaClassLookupDto> Classes { get; set; }
    }
}

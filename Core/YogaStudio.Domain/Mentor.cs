using System.Collections.Generic;

namespace YogaStudio.Domain
{
    public class Mentor : Person
    {
        public IEnumerable<YogaClass> Classes { get; set; }
    }
}

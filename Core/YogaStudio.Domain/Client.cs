using System.Collections.Generic;

namespace YogaStudio.Domain
{
    public class Client : Person
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
